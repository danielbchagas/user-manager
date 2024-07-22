using Microsoft.AspNetCore.Identity;
using User.API.Infrastructure.Data;

namespace User.API.Configurations
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
