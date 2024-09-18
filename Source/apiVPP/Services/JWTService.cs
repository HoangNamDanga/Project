using apiVPP.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace apiVPP.Services
{
    public class JWTService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _jwtKey;

        public JWTService(IConfiguration config)
        {
            _config = config;
            //SymmetricSecurityKey là một lớp trong thư viện Microsoft.IdentityModel.Tokens đại diện cho một khóa bảo mật được sử dụng để ký và xác thực token JWT. Nó sử dụng cùng một khóa để ký và xác thực (đối xứng).
            _jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            //_jwtKey là một biến thành viên của lớp, dùng để lưu trữ khóa bảo mật đã được tạo ra. Biến này sau đó sẽ được sử dụng trong quá trình tạo và xác thực JWT.
        }

        //function create JSON Web Token (JWT)
        public string CreateJWT(Employee employee)
        {
            var employeeClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                new Claim(ClaimTypes.Email, employee.Email),
                new Claim(ClaimTypes.GivenName, employee.FirstName),
                new Claim(ClaimTypes.Surname, employee.LastName),
                new Claim("my own claim name", "this is the value")
            };
            var creadentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha512Signature); //Đối tượng này chứa thông tin cần thiết để ký token và thuật toán dùng để ký token, đảm bảo tính toàn vẹn và xác thực token
            var tokenDescriptor = new SecurityTokenDescriptor //đối tượng chứa các thông tin cấu hình cho token JWT:
            {
                Subject = new ClaimsIdentity(employeeClaims), // đại diện cho danh sách các claims của ng dùng
                Expires = DateTime.UtcNow.AddDays(int.Parse(_config["JWT:ExpiresInDays"])), //Thời điểm token hết hạn.
                SigningCredentials = creadentials, //Cung cấp khóa và thuật toán ký token.
                Issuer = _config["JWT:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler(); //Đối tượng này chịu trách nhiệm tạo và viết token JWT.
            var jwt = tokenHandler.CreateToken(tokenDescriptor); //Tạo một token JWT mới dựa trên cấu hình trong SecurityTokenDescriptor.
            return tokenHandler.WriteToken(jwt); //Chuyển đổi đối tượng JwtSecurityToken thành chuỗi JWT để có thể gửi đến client.
        }
    }
}
