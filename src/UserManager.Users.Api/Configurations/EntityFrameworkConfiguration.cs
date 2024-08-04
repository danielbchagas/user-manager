using Microsoft.EntityFrameworkCore;
using UserManager.Users.Api.Infrastructure.Data;

namespace UserManager.Users.Api.Configurations
{
    public static class EntityFrameworkConfiguration
    {
        public static void ConfigureEntityFramework(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
                    r => r.EnableRetryOnFailure(maxRetryCount: 5));
            });
        }
    }
}
