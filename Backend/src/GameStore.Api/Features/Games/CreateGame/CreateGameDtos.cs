using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Features.Games.CreateGame;

public record class CreateGameDtos
{
    // DTO for creating a new game, which includes GenreId instead of the full Genre object
    public record CreateGameDto(
        [Required][StringLength(50)] string Name,
        Guid GenreId,
        [Range(1, 100, ErrorMessage = "Price must be between 1 and 100.")] decimal Price,
        DateOnly ReleaseDate,
        [Required][StringLength(500)] string Description
    );

    // DTO for returning game details without exposing the Genre object
    public record GameDetailsDto(
        Guid Id,
        string Name,
        Guid GenreId,
        decimal Price,
        DateOnly ReleaseDate,
        string Description
    );
}
