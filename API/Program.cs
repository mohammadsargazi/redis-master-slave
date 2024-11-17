using API.Extensions;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var redisConfig = builder.Configuration.GetSection("Redis");
var master = redisConfig["Master"];
var slaves = redisConfig.GetSection("Slaves").Get<string[]>();

builder.Services.AddRedis(builder.Configuration);

builder.Services.AddScoped<IRedisService, RedisService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
