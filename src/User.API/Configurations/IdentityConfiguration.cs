using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User.API.Domain.Entities;
using User.API.Infrastructure.Data;

namespace User.API.Configurations
{
    public static class IdentityConfiguration
    {
        public static void ConfigureIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), r => r.EnableRetryOnFailure(maxRetryCount: 5));
            });

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
