namespace Market.OtherScripts.Extensions
{
    public static class ControllerRouteConnectionExtension
    {
        public static WebApplication MapControllerRouteConnect(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}");
            app.MapControllerRoute(
                name: "registration",
                pattern: "{controller=LoginController}/{action=Registration}");
            app.MapControllerRoute(
                name: "login",
                pattern: "{controller=LoginController}/{action=Login}");
            app.MapControllerRoute(
                name: "logout",
                pattern: "{controller=LoginController}/{action=Logout}");
            app.MapControllerRoute(
                name: "registrationPost",
                pattern: "{controller=LoginController}/{action=RegistrationPostAsync}/{name}/{email}/{password}/{phoneNumber?}");
            app.MapControllerRoute(
                name: "loginPost",
                pattern: "{controller=LoginController}/{action=LoginPostAsync}/{email}/{password}");

            return app;
        }
    }
}
