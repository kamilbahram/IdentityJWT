using Microsoft.AspNetCore.Identity;

namespace IdentityJWT.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var contex = serviceProvider.GetRequiredService<AppIdentityDbContex>();
            var userManeger = serviceProvider.GetRequiredService<UserManager<AplicationUser>>();
            contex.Database.EnsureCreated(); //Database oluşturuluyor.

            if (!contex.Users.Any())
            {   
                AplicationUser user = new AplicationUser()
                {
                    UserName = "Kamil",
                    Email = "kamil@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString()                
                };
                userManeger.CreateAsync(user, "@Password135");
            }
        }
    }
}
