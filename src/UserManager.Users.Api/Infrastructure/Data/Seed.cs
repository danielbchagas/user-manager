using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace UserManager.Users.Api.Infrastructure.Data
{
    internal class Seed
    {
        public void Run(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            var admin = new IdentityUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                UserName = "admin@contoso.com",
                NormalizedUserName = "ADMIN@CONTOSO.COM",
                Email = "admin@contoso.com",
                NormalizedEmail = "ADMIN@CONTOSO.COM",
            };

            admin.PasswordHash = hasher.HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(
                admin
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );
        }
    }
}
