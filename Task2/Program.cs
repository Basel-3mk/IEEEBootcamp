using Microsoft.EntityFrameworkCore;
using System;
using Task2.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Server=db40612.public.databaseasp.net; Database=db40612; User Id=db40612; Password=t?3L7cX=#4mC; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
builder.Services.AddDbContext<AppDbContext> (options => options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
