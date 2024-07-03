using Microsoft.EntityFrameworkCore;

namespace asp.netTutorial.Data
{
    public static class DataExtensions
    {
        public static async Task MigrateDbAsync(this WebApplication app) {

            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
            await dbContext.Database.MigrateAsync();

            //meken wenne app ek patn gddima database ek hdnwa automa apita migrate walin hnna one nha 
        }
    }
}
