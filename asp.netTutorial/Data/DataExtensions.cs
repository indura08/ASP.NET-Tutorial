using Microsoft.EntityFrameworkCore;

namespace asp.netTutorial.Data
{
    public static class DataExtensions
    {
        public static void MigrateDb(this WebApplication app) {

            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
            dbContext.Database.Migrate();

            //meken wenne app ek patn gddima database ek hdnwa automa apita migrate walin hnna one nha 
        }
    }
}
