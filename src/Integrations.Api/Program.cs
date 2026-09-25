var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Logger.LogInformation("Application environment: {EnvironmentName}", app.Environment.EnvironmentName);

if(app.Environment.IsDevelopment())
{
    app.Logger.LogInformation("from if, Environment is {Name}", app.Environment.EnvironmentName);
}
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
