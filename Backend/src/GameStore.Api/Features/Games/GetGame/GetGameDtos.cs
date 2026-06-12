namespace GameStore.Api.Features.Games.GetGame;

public record class GetGameDtos
{
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
