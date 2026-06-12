using GameStore.Api.Data;
using GameStore.Api.Features.Games.CreateGame;
using GameStore.Api.Features.Games.DeleteGame;
using GameStore.Api.Features.Games.GetGame;
using GameStore.Api.Features.Games.GetGames;
using GameStore.Api.Features.Genres.GetGenres;
using GameStore.Api.Features.Games.UpdateGame;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

GameStoreData data = new();

// GET /games
app.MapGetGames(data);

// GET /games/{id}
app.MapGetGame(data);

// POST /games
app.MapCreateGame(data);

// PUT /games/{id}
app.MapUpdateGame(data);

// DELETE /games/{id}
app.MapDeleteGame(data);

// GET /genres
app.MapGetGenres(data);

app.Run();
