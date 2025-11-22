using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Workify.Application.Services;
using Workify.Core.Entities.User;
using Workify.Infrastructure.DBContext;
using Workify.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["access_token"];
            return Task.CompletedTask;
        }
    };
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:AccessKey"]!))
    };
});
builder.Services.AddAuthorization();

builder.Services.AddDbContext<MyDBContext>((options) => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<JobSeekerRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<TokenRepository>();
builder.Services.AddScoped<UserRoleRepository>();
builder.Services.AddScoped<JobSeekerRepository >();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<EmployerRepository>();
builder.Services.AddScoped<EmployerSettingsRepository>();
builder.Services.AddScoped<JobSeekerRepository>();
builder.Services.AddScoped<JobSeekerSettingsRepository>();
builder.Services.AddScoped<ResumeRepository>();

builder.Services.AddScoped<JwtTokenService>();
builder.Services.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<ResumeService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthService>();
 

var app = builder.Build();

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
