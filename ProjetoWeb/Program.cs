

using Application.Services;
using Domain.Entities;
using Domain.Options;
using Domain.Requests;
using Domain.Validators;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using TokenOptions = Domain.Options.TokenOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TokenOptions>(
    builder.Configuration.GetSection(TokenOptions.Section));

builder.Services.Configure<PasswordHasherOptions>(
    builder.Configuration.GetSection(PasswordHashOptions.Section));

builder.Services.AddCors(config =>
{
    config.AddPolicy("AllowOrigin", options => options
    .AllowAnyOrigin()
    .AllowAnyMethod());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


////builder.Services.AddScoped<ICarService, CarService>();
//builder.Services.AddScoped<IValidator<BaseCarRequest>, CarValidator>();
builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IValidator<BaseUserRequest>,UserValidator>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IHashingService, HashingService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
