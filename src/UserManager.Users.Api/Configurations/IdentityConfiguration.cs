using Microsoft.AspNetCore.Identity;
using UserManager.Users.Api.Infrastructure.Data;

namespace UserManager.Users.Api.Configurations
{
    public static class IdentityConfiguration
    {
        public static void ConfigureIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization();

            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}
