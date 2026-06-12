namespace GameStore.Api.Features.Games.GetGames;

public record class GetGamesDtos
{
    // DTO for returning game summaries in the list endpoint
    public record GameSummaryDto(
        Guid Id,
        string Name,
        string Genre,
        decimal Price,
        DateOnly ReleaseDate
    );
}
