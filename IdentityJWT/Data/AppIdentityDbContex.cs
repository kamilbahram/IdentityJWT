using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityJWT.Data
{
    public class AppIdentityDbContex : IdentityDbContext<AplicationUser>
    {
        public AppIdentityDbContex(DbContextOptions<AppIdentityDbContex> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}
