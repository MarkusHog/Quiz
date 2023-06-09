using QuizAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

List<Question> questions = new List<Question>()
{
    new Question()
    {
        Id = Guid.NewGuid(),
        QuizQuestion = "Vilken är världens största öken?",
        CorrectAnswer = "Sahara",
        IncorrectAnswer1 = "Arabiska öknen",
        IncorrectAnswer2 = "Gobiöknen",
        IncorrectAnswer3 = "Kalahariöknen",
        IncorrectAnswer4 = "Patagoniska öknen",
        Correct = false,
        ChoosenAnswer = "",
        NumberOfCorrectAnswer = 0
    },
    new Question()
    {
        Id = Guid.NewGuid(),
        QuizQuestion = "Vad heter Europas högsta berg?",
        CorrectAnswer = "Elbrus",
        IncorrectAnswer1 = "Dent Blanche",
        IncorrectAnswer2 = "Matterhorn",
        IncorrectAnswer3 = "Weisshorn",
        IncorrectAnswer4 = "Lyskamm",
        Correct = false,
        ChoosenAnswer = "",
        NumberOfCorrectAnswer = 0
    },
    new Question()
    {
        Id = Guid.NewGuid(),
        QuizQuestion = "Vad är världens största djur?",
        CorrectAnswer = "Blåval",
        IncorrectAnswer1 = "Stillahavsnordkapare",
        IncorrectAnswer2 = "Kolossbläckfisk",
        IncorrectAnswer3 = "Späckhuggare",
        IncorrectAnswer4 = "Elefant",
        Correct = false,
        ChoosenAnswer = "",
        NumberOfCorrectAnswer = 0
    }
};

app.MapGet("/questions", () =>
{
    return questions;
});

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
