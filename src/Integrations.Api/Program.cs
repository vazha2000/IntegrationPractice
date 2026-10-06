
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Logger.LogInformation("Application environment: {EnvironmentName}", app.Environment.EnvironmentName);

var value = Environment.GetEnvironmentVariable("MY_SETTING");
System.Console.WriteLine(value);

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
