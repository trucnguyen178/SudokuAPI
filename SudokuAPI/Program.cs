using Microsoft.EntityFrameworkCore;
using SudokuAPI.Models;
using SudokuAPI.Services.Implementations;
using SudokuAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with a connection string
builder.Services.AddDbContext<SudokuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SudokuDBConnection")));

// DI
builder.Services.AddTransient<ISudokuService, SudokuService>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:5500")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
