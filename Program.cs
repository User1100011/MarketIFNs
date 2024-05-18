using Market.OtherScripts.Extensions;

namespace Market
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //https://www.youtube.com/@Excalib/videos
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //https://yandex.kz/video/preview/17005841421177129475 ef core
            builder.ServicesConnect();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                //https://tproger.ru/articles/pochemu-my-ispolzuem-kafka-vmesto-rabbitmq-sravnenie-i-preimushhestva
                //https://www.youtube.com/watch?v=i8H0y9dz3uk

                //https://metanit.com/sharp/mvc5/23.7.phpz
                //AutoMapper, Mapster, xUnit, NUnit, NLog, Seq, Serilog, FluentValidation, Swagger, SignalR.
                //DTO, POCO, ValueObject

                //authenticaiton and authorizatiion:
                //https://www.youtube.com/watch?v=sMe3T6rFkXo
                //https://metanit.com/sharp/aspnet5/15.2.php
                //https://metanit.com/sharp/aspnet6/13.7.php 
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy(new CookiePolicyOptions()
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            //https://www.youtube.com/watch?v=RAcpAc0EYV0
            //https://metanit.com/sharp/aspnetmvc/3.9.php
        }
    }
}
