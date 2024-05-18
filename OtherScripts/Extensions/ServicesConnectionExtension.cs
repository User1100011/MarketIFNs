using FluentValidation;
using Market.DbContexts;
using Market.Filters;
using Market.Interfaces.AuthInterfaces;
using Market.Interfaces.HashingInterfaces;
using Market.Interfaces.FileInterfaces;
using Market.Models;
using Market.Models.Entityes;
using Market.Services.OtherServices;
using Market.Services.AuthServices;
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

            #region Dependencies Add

            //Add Other Services:
            builder.Services.AddScoped<IPasswordHasher, PasswordHasherService>();
            builder.Services.AddScoped<IHashVerify, PasswordHasherService>();
            builder.Services.AddScoped<IValidator<UserEntity>, UserValidator>();
            builder.Services.AddScoped<IEmailSender, EmailSenderService>();


            //Add Entity Services:
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<IFileCreateAsync, FileService>();
            // =======f43f34=========== Result.FailureIf<FileEntity>(true, null, $"Type {formFile.ContentType} is not a picture"); можно так кстатиЛДОФЛДВжофывофылвоф

            //Add Auth Services:
            builder.Services.AddScoped<ILoginAsync, UserAuthService>();
            builder.Services.AddScoped<IRegistrationAsync, UserAuthService>();
            builder.Services.AddScoped<ILogoutAsync, UserAuthService>();

            // builder.Services.AddScoped<ISalesmanLoginAsync, SalesmanAuthService>();
            // builder.Services.AddScoped<ISalesmanRegistrationAsync, SalesmanAuthService>();
            // builder.Services.AddScoped<ISalesmanLogoutAsync, SalesmanAuthService>();


            //Add Filter services:
            builder.Services.AddScoped<ValidationFilter>();
            builder.Services.AddScoped<UserValidationFilter>();


            //Add Other Services:

            #endregion

            return builder;
        }
    }
}