using GameStore.Api.Data;
using GameStore.Api.Features.Games;
using GameStore.Api.Features.Genres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext into a scoped lifetime
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

// Optional services, added for practice (start)
builder.Services.AddTransient<GameDataLogger>();
builder.Services.AddSingleton<GameStoreData>();
// Optional services, added for practice (end)

var app = builder.Build();

app.MapGames();
app.MapGenres();
app.InitialiseDb();

app.Run();
