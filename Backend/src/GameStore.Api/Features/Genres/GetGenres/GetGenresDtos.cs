namespace GameStore.Api.Features.Genres.GetGenres;

public record class GetGenresDtos
{
    // DTO for returning genre information
    public record GenreDto(Guid Id, string Name);
}
