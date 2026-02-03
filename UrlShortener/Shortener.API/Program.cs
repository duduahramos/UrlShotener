using Shortener.API.Infrastructure.Services;
using StackExchange.Redis;
using UrlShortener.API.Application.Interfaces;
using UrlShortener.API.Application.Services;
using UrlShortener.API.Application.UseCases;
using UrlShortener.API.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    
    var options = ConfigurationOptions.Parse(
        configuration["Redis:ConnectionString"]!
    );
    
    options.Password = configuration["Redis:Password"];
    options.AbortOnConnectFail = false;
    
    return ConnectionMultiplexer.Connect(options);
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

builder.Services.AddSingleton<IHashManager, XxHashManager>();
builder.Services.AddSingleton<ICacheService, RedisCacheService>();
builder.Services.AddSingleton<IUrlManagerService, UrlManagerService>();
builder.Services.AddSingleton<CreateShorterURL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();