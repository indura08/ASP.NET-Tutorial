using asp.netTutorial.Data;
using asp.netTutorial.Dtos;
using asp.netTutorial.Entities;
using asp.netTutorial.Mapping;
using Microsoft.EntityFrameworkCore;

namespace asp.netTutorial.EndPoints
{
    public static class GameEndPoints
    {
        private static string gameEndPoint = "getGames";

        private static readonly List<GamesummeryDto> games = new List<GamesummeryDto> {

            new GamesummeryDto(1,"street fighter 2" , "fighting", 19.99M, new DateOnly(1992,7,15)),
            new GamesummeryDto(2,"Final fantacy xvi" , "Role playing", 59.99M, new DateOnly(2010,10,20)),      //methna M daala thiynne decimal hinda
            new GamesummeryDto(3,"Fifa 23" , "sports", 129.99M, new DateOnly(2023,3,8)),

        };

        public static /*WebApplication*/ RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
        {
            var group = app.MapGroup("games").WithParameterValidation(); //emnna me wage withpramatervalidation method ek group ekt dunnama mulu grp ekema thiyna endpoint walt validation part ek add wenwa , mekn validation part eka hama endpoint ektm adlal wena widiyt dana eka lesi krnwa
            //methanin pahala group kiyla daala thiyna ewat app kiyla daala thibbe eka change krgtta group kiyl daala

            group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Games.Include(game => game.Genre).Select(game => game.ToGameSummeryDto()).AsNoTracking().ToListAsync()); //as no tracking kiynne ksima widiykt track rkanna epa return data kiyna eki

            //get games by id 
            group.MapGet("/{id}", async (int id , GameStoreContext dbContext) => {

                Game? game = await dbContext.Games.FindAsync(id);

                return game is null ? Results.NotFound() : Results.Ok(game);

            }).WithName(gameEndPoint);

            //create new game POST method
            group.MapPost("/create", async (CreateGameDto newGame, GameStoreContext dbContext) => {
                /*GameDto game = new GameDto(
                        games.Count + 1,
                        newGame.Name,
                        newGame.Genre,
                        newGame.Price,
                        newGame.ReleaseDate);*/ //me kalin thibba widiyt e kiynne db eka sambnda nathuwa aluth game ekk hdaddi giya widiya
                Game game = new()   //methna game kiynne db ekat dapu gma ewaguwa hode ptlaganna epa aaye blddi
                {
                    Name = newGame.Name,
                    Genre = dbContext.Genres.Find(newGame.Genre), //,menna me wage thami database eke thiyna genre waguwen id ekt adla genre eka search krla eka assign krnne aluthing save krnna yna game ekt
                    GenreId = newGame.Genre,
                    //mama price daala thibbe nha Game class eke ehinda eka nah meke
                    ReleaseDate = newGame.ReleaseDate

                };

                //ToEntity method ekn ganna gameDto ekk game ekkatada game ekk gameDto ekktd convert krla apita data base ekt daanna th puluwan menna mehm

                Game gameToEntity = newGame.ToEntity();
                //meka one wenne nha - game.Genre = dbContext.Genres.Find(newGame.Genre);


                dbContext.Games.Add(gameToEntity);//menna mekn thami kiynne dbcontext eka hraha Games table ekt mem aluth game ek save krnna kiyla 
                await dbContext.SaveChangesAsync();  //menna me wage anthmat changes save krnna kiylth kiynna one 

                GamesummeryDto gameDto = new GamesummeryDto(
                    
                        Id: game.Id,
                        Name: game.Name,
                        genre: game.Genre!.Name,
                        Price: game.Name.Length,
                        RealseDate: game.ReleaseDate
                       

                    );
                return Results.CreatedAtRoute(gameEndPoint, new { id = game.Id }, gameToEntity.ToGameDetailsDto());
            }).WithParameterValidation();       //me anthimt daala thiyna with parametervalidation scn eka awilla ara api install krgttu minimalapi.extension eke function ekk. meken wenne api dapu dataannotations tika (validation walt) ta dalwa createdto walin ganna dta valid da kiyl check krna ek
            //me withparametervalidation scn ek damma input validation error qualitytama denwa 

            //update method
            group.MapPut("/update/{id}", async (int id, UpdateDto updateGame, GameStoreContext dbContext) => {

                var existingGame = await dbContext.Games.FindAsync(id);

                /*if (existingGame == null) {
                    return Results.NotFound();
                }*/

                dbContext.Entry(existingGame).CurrentValues.SetValues(updateGame.ToEntity(id));
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            //delete method
            group.MapDelete("/delete/{id}", async (int id , GameStoreContext dbContext) =>
            {

                await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync(); 
                return (Results.Ok());
            });

            return group;
        }

        
    } 

    
}
