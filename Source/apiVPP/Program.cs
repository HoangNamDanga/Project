using apiVPP.Data;
using apiVPP.Models;
using apiVPP.Services;
using apiVPP.Services.Imp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IStationeryRequestService, StationeryRequestService>();
builder.Services.AddScoped<IStationeryItemService, StationeryItemService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IApprovalService, ApprovalService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddScoped<JWTService>(); // be able to inject JWTService class inside our Controllers.


//c?u h�nh d?ch v? Identity 
builder.Services.AddIdentity<Employee, Role>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<Role>()
.AddRoleManager<RoleManager<Role>>()
.AddEntityFrameworkStores<Context>()
.AddSignInManager<SignInManager<Employee>>()
.AddUserManager<UserManager<Employee>>()
.AddDefaultTokenProviders();

//JwtBearer is used to authenticate(x�c th?c) users using JWT -> 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateIssuer = true,
            ValidateAudience = false
        };
    });
//CORS l� m?t c? ch? cho ph�p c�c trang web t? c�c mi?n kh�c (origins) truy c?p t�i nguy�n c?a ?ng d?ng web.
builder.Services.AddCors();

// khi m?t request g?i l�n API v� ModelState kh�ng h?p l? (v� d?: d? li?u kh�ng ?�p ?ng c�c y�u c?u v? ki?u d? li?u, y�u c?u b?t bu?c, ...), th� InvalidModelStateResponseFactory s? ???c k�ch ho?t.

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
        .Where(x => x.Value.Errors.Count > 0)
        .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToArray();

        var toResult = new
        {
            Errors = errors
        };
        return new BadRequestObjectResult(toResult);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(builder.Configuration["JWT:ClientUrl"]);
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
