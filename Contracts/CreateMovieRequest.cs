namespace MoviesApi.Contracts;

public sealed record CreateMovieRequest(int Id, string Title, int ReleaseYear, int Duration);