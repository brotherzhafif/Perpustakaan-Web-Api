using Microsoft.EntityFrameworkCore;
using Perpustakaan_Web_Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserAPIDbContext>(options => options.UseInMemoryDatabase("Library_Database"));
builder.Services.AddDbContext<BukuAPIDbContext>(options => options.UseInMemoryDatabase("Library_Database"));
builder.Services.AddDbContext<PeminjamanAPIDbContext>(options => options.UseInMemoryDatabase("Library_Database"));
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
