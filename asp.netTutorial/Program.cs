using asp.netTutorial.Data;
using asp.netTutorial.Dtos;
using asp.netTutorial.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");    //me connection string eka sambnda dewal tika daala tiynne appsettings.json file eka thule , ekt giyoth blagnna puluwan connection string ek daala thiyn widiy 
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndPoints();

app.Run();
