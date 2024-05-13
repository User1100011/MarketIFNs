using FluentValidation;
using Market.DbContexts;
using Market.Filters;
using Market.Interfaces;
using Market.Models;
using Market.Models.Entityes;
using Market.OtherScripts;
using Market.Services.EntityServices;
using Market.Validation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Market.OtherScripts.Extensions
{
    public static class ServicesConnectionExtension
    {
        public static WebApplicationBuilder ServicesConnect(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddJsonFile("Configurations/requirements.json");

            var userRequirements =
                builder.Configuration.GetRequiredSection("UserRequirements");

            builder.Services.AddMvc();
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());//глобаzльно и авт будут применяться токены против CSRF
            });

            builder.Services.AddDbContext<ApplicationDbContext>((optionsBuiider) =>
            {
                //var postgreeConnectionStr =
                //    builder.Configuration.GetConnectionString("PostgreSqlConnectionString");

                //optionsBuiider.UseNpgsql(postgreeConnectionStr);
                optionsBuiider.UseSqlite("Data Source=marketapp.db");
            });
            builder.Services.AddCookiePolicy(options => { });
            builder.Services.AddIdentity<UserEntity, UserRole>(opts =>
            {
                var passwordRequirements = userRequirements.GetRequiredSection("PasswordRequirements");

                opts.Password.RequiredLength = passwordRequirements.GetValue<int>("MaxLength");
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireDigit = true;

                opts.User.RequireUniqueEmail = true;

                opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
                {
                    opts.LoginPath = "/LoginController/Login";
                    opts.LogoutPath = "/LoginController/Logout";
                });
            builder.Services.AddAuthorization();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<IHashVerify, PasswordHasher>();
            builder.Services.AddScoped<IValidator<UserEntity>, UserValidator>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();


            //Add filters
            builder.Services.AddScoped<ValidationFilter>();
            builder.Services.AddScoped<UserValidationFilter>();

            return builder;
        }
    }
}