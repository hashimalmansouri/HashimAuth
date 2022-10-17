using HashimAuth.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace HashimAuth.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HashimContext>();
                context.Database.EnsureCreated();

                var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<HashimUser>>();
                var _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!context.Users.Any(usr => usr.UserName == "admin"))
                {
                    var user = new HashimUser()
                    {
                        UserName = "admin",
                        Email = "admin@test.com",
                        EmailConfirmed = true,
                        RefreshToken = string.Empty,
                        RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(1)
                    };

                    try
                    {
                        var userResult = _userManager.CreateAsync(user, "123456").Result;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                //context.SaveChanges();
            }
        }
    }
}
