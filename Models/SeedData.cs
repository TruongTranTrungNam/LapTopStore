using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace LapTopStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            LapTopStoreDbContext context =
           app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService <LapTopStoreDbContext> ();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Laptops.Any())
            {
                
                context.SaveChanges();
            }
        }
    }


}
