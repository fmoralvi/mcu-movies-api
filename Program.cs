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
    new(1, "Iron Man", 2008),
    new(2, "The Incredible Hulk", 2008),
    new(3, "Iron Man 2", 2010),
    new(4, "Thor", 2011),
    new(5, "Captain America: The First Avenger", 2011),
    new(6, "The Avengers", 2012),
    new(7, "Iron Man 3", 2013),
    new(8, "Thor: The Dark World", 2013),
    new(9, "Captain America: The Winter Soldier", 2014),
    new(10, "Guardians of the Galaxy", 2014),
    new(11, "Avengers: Age of Ultron", 2015),
    new(12, "Ant-Man", 2015),
    new(13, "Captain America: Civil War", 2016),
    new(14, "Doctor Strange", 2016)
};

app.MapGet("/movies", () => Results.Ok(movies))
    .WithName("GetMovies");

app.Run();