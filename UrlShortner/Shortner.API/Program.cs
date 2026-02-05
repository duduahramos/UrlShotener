using Shortner.API.Infrastructure.Services;
using StackExchange.Redis;
using Shortner.API.Application.Interfaces;
using Shortner.API.Application.Services;
using Shortner.API.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ========================================
// ADICIONAR: Configurar CORS
// ========================================
var frontEndOrigin = builder.Configuration["Cors:FrontEndOrigin"];

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", angularPolicy =>
    {
        angularPolicy
            .WithOrigins(frontEndOrigin)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
// ========================================


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
builder.Services.AddSingleton<GetShorterURL>();
builder.Services.AddSingleton<CreateShorterURL>();

var app = builder.Build();

app.UseCors("AllowAngular");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();