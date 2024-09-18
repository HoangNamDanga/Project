using apiVPP.Data;
using apiVPP.DTOs.Account;
using apiVPP.Models;
using apiVPP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace apiVPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JWTService _jwtService;
        private readonly SignInManager<Employee> _signInManager;
        private readonly UserManager<Employee> _employeeManager;
        private readonly Context _context;

        public AccountController(JWTService jwtService, SignInManager<Employee> signInManager, UserManager<Employee> employeeManager, Context context)
        {
            _jwtService = jwtService;
            _signInManager = signInManager;
            _employeeManager = employeeManager;
            _context = context;
        }

        [Authorize]
        [HttpGet("refresh-employee-token")]
        public async Task<ActionResult<DTOs.Account.EmployeeDto>> RefeshEmployeeoken()
        {

            var employee = await _employeeManager.FindByNameAsync(User.FindFirst(ClaimTypes.Email)?.Value);
            return CreateApplicationEmployeeDto(employee);
        }

        [HttpPost("login")]
        public async Task<ActionResult<EmployeeDto>> Login(LoginDto model)
        {
            var employee = await _employeeManager.FindByNameAsync(model.UserName);
            if(employee == null)  return Unauthorized("Invalid username or password"); 

            if (employee.EmailConfirmed == false) return Unauthorized("Please confirm you email.");

            var result = await _signInManager.CheckPasswordSignInAsync(employee, model.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid user or password");

            return CreateApplicationEmployeeDto(employee);
        }
        [HttpPost("register")]

        public async Task<IActionResult> Register(RegisterDto model)
        {
            if(await CheckEmailExistsAsync(model.Email))
            {
                return BadRequest($"An existing account is using {model.Email}, email address. Please try with another email address");
            }

            var employeeToAdd = new Employee
            {
                FirstName = model.FirstName.ToLower(),  
                LastName = model.LastName.ToLower(),
                UserName = model.UserName.ToLower(),
                Email = model.Email.ToLower(),
                SuperiorID = model.SuperiorID,
                RoleId = model.RoleId,
                EmailConfirmed = true,                 
            };
            //Create Account with password
            var result = await _employeeManager.CreateAsync(employeeToAdd, model.Password);

            if(!result.Succeeded) return BadRequest(result.Errors);

            return Ok(new JsonResult(new { title = "Account Created", message = "Your account has been created, you can login" }));
        }



        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            var employee = await _employeeManager.GetUserAsync(User); // xác minh ng dùng hiện tại
            if (employee == null) return Unauthorized("Employee is not Exists");
            var checkPassword = await _signInManager.CheckPasswordSignInAsync(employee, model.CurrentPassword, false); // tham số false nghĩa là tài khoản sẽ ko bị khóa nếu việc xác minh mật khẩu thất bại

            if (!checkPassword.Succeeded) return BadRequest("Current password is incorrect");

            var auditLog = new AuditLog
            {
                Id = employee.Id,
                FieldChanged = "Password",
                OldValue = "[REDACTED]",
                NewValue = "[REDACTED]",
                ChangedBy = employee.Id,
                ChangeDate = DateTime.UtcNow,
            };

            _context.AuditLogs.Add(auditLog);
            await _context.SaveChangesAsync();

            return Ok("Password has been changed successfully.");
        }


        #region Private Helper Methods
        private EmployeeDto CreateApplicationEmployeeDto(Employee employee)
        {
            var a =  new EmployeeDto
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                JWT = _jwtService.CreateJWT(employee),
            };

            return a;
        }


        private async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await _employeeManager.Users.AnyAsync(x => x.Email == email.ToLower()); // kieerm tra xem email co ton tai hay khong
        }
        #endregion
    }
}
