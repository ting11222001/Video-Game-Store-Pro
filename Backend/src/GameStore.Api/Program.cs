using System.ComponentModel.DataAnnotations;
using GameStore.Api.Data;
using GameStore.Api.Features.Games.CreateGame;
using GameStore.Api.Features.Games.GetGame;
using GameStore.Api.Features.Games.GetGames;
using GameStore.Api.Models;

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
app.MapPut("/games/{id}", (Guid id, UpdateGameDto gameDto) =>
{
    Game? existingGame = data.GetGame(id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }

    Genre? genre = data.GetGenre(gameDto.GenreId);

    if (genre is null)
    {
        return Results.BadRequest("Invalid genre ID.");
    }

    existingGame.Name = gameDto.Name;
    existingGame.Genre = genre;
    existingGame.Price = gameDto.Price;
    existingGame.ReleaseDate = gameDto.ReleaseDate;
    existingGame.Description = gameDto.Description;

    return Results.NoContent();
})
.WithParameterValidation();

// DELETE /games/{id}
app.MapDelete("/games/{id}", (Guid id) =>
{
    data.RemoveGame(id);
    return Results.NoContent();
});

// GET /genres
app.MapGet("/genres", () => data.GetGenres().Select(
    genre => new GenreDto(genre.Id, genre.Name)));

app.Run();


// DTO for updating an existing game, which also includes GenreId instead of the full Genre object
public record UpdateGameDto(
    [Required][StringLength(50)] string Name,
    Guid GenreId,
    [Range(1, 100, ErrorMessage = "Price must be between 1 and 100.")] decimal Price,
    DateOnly ReleaseDate,
    [Required][StringLength(500)] string Description
);

// DTO for returning genre information
public record GenreDto(Guid Id, string Name);