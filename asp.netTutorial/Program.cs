using asp.netTutorial.Dtos;
using asp.netTutorial.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGamesEndPoints();

app.Run();
