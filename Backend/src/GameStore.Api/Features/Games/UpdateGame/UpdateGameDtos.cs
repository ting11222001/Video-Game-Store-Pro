using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Features.Games.UpdateGame;

public record class UpdateGameDtos
{
    // DTO for updating an existing game, which also includes GenreId instead of the full Genre object
    public record UpdateGameDto(
        [Required][StringLength(50)] string Name,
        Guid GenreId,
        [Range(1, 100, ErrorMessage = "Price must be between 1 and 100.")] decimal Price,
        DateOnly ReleaseDate,
        [Required][StringLength(500)] string Description
    );
}
