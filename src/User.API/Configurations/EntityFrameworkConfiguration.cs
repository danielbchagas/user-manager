using Microsoft.EntityFrameworkCore;
using User.API.Infrastructure.Data;

namespace User.API.Configurations
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
