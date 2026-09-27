using MoviesApi.Contracts;
using MoviesApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var movies = new List<Movie>
{
    new(1, "Iron Man", 2008, 126),
    new(2, "The Incredible Hulk", 2008, 112),
    new(3, "Iron Man 2", 2010, 124),
    new(4, "Thor", 2011, 115),
    new(5, "Captain America: The First Avenger", 2011, 124),
    new(6, "The Avengers", 2012, 143),
    new(7, "Iron Man 3", 2013, 130),
    new(8, "Thor: The Dark World", 2013, 112),
    new(9, "Captain America: The Winter Soldier", 2014, 136),
    new(10, "Guardians of the Galaxy", 2014, 121),
    new(11, "Avengers: Age of Ultron", 2015, 141),
    new(12, "Ant-Man", 2015, 117),
    new(13, "Captain America: Civil War", 2016, 147),
    new(14, "Doctor Strange", 2016, 115)
};

app.MapGet("/movies", () => Results.Ok(movies))
    .WithName("GetMovies");

app.MapPost("/movies", (CreateMovieRequest request) =>
{
    var nextId = movies.Count == 0 ? 1 : movies.Max(movie => movie.Id) + 1;
    var movie = new Movie(nextId, request.Title, request.ReleaseYear, request.Duration);

    movies.Add(movie);

    return Results.Created($"/movies/{movie.Id}", movie);
})
.WithName("CreateMovie");

app.Run();