using Integrations.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Logger.LogInformation("Application environment: {EnvironmentName}", app.Environment.EnvironmentName);

var jwtIssuer = app.Configuration["Jwt:Issuer"];
var jwtAudience = app.Configuration["Jwt:Audience"];
var jwtExpirationMinutes = app.Configuration.GetValue<int>("Jwt:ExpirationMinutes");

app.Logger.LogInformation(
    "JWT settings: Issuer={Issuer}, Audience={Audience}, ExpirationMinutes={ExpirationMinutes}",
    jwtIssuer,
    jwtAudience,
    jwtExpirationMinutes);

var value = Environment.GetEnvironmentVariable("MY_SETTING");
System.Console.WriteLine(value);
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
