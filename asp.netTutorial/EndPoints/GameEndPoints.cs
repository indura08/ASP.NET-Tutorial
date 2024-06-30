using asp.netTutorial.Dtos;

namespace asp.netTutorial.EndPoints
{
    public static class GameEndPoints
    {
        private static string gameEndPoint = "getGames";

        private static readonly List<GameDto> games = new List<GameDto> {

            new GameDto(1,"street fighter 2" , "fighting", 19.99M, new DateOnly(1992,7,15)),
            new GameDto(2,"Final fantacy xvi" , "Role playing", 59.99M, new DateOnly(2010,10,20)),      //methna M daala thiynne decimal hinda
            new GameDto(3,"Fifa 23" , "sports", 129.99M, new DateOnly(2023,3,8)),

        };

        public static /*WebApplication*/ RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
        {
            var group = app.MapGroup("games").WithParameterValidation(); //emnna me wage withpramatervalidation method ek group ekt dunnama mulu grp ekema thiyna endpoint walt validation part ek add wenwa , mekn validation part eka hama endpoint ektm adlal wena widiyt dana eka lesi krnwa
            //methanin pahala group kiyla daala thiyna ewat app kiyla daala thibbe eka change krgtta group kiyl daala

            group.MapGet("/", () => games);

            //get games by id 
            group.MapGet("/{id}", (int id) => games.Find(game => game.Id == id)).WithName(gameEndPoint);

            //create new game POST method
            group.MapPost("/create", (CreateGameDto newGame) => {
                GameDto game = new GameDto(
                        games.Count + 1,
                        newGame.Name,
                        newGame.Genre,
                        newGame.Price,
                        newGame.ReleaseDate);

                games.Add(game);

                return Results.CreatedAtRoute(gameEndPoint, new { id = game.Id }, game);
            }).WithParameterValidation();       //me anthimt daala thiyna with parametervalidation scn eka awilla ara api install krgttu minimalapi.extension eke function ekk. meken wenne api dapu dataannotations tika (validation walt) ta dalwa createdto walin ganna dta valid da kiyl check krna ek
            //me withparametervalidation scn ek damma input validation error qualitytama denwa 

            //update method
            group.MapPut("/update/{id}", (int id, UpdateDto updateGame) => {

                var index = games.FindIndex(game => game.Id == id);

                games[index] = new GameDto(id, updateGame.name, updateGame.genre, updateGame.price, updateGame.releaseDate);

                return Results.NoContent();
            });

            //delete method
            group.MapDelete("/delete/{id}", (int id) =>
            {

                games.RemoveAll(game => game.Id == id);
                return (Results.Ok());
            });

            return group;
        }

        
    } 

    
}
