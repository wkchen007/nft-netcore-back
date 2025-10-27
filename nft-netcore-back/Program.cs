using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using nft_netcore_back.Models;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<nftwebContext>(options =>
{
    var conn = $"Server=localhost;Database=nftweb;User ID={Env.GetString("DB_USER")};Password={Env.GetString("DB_PASSWORD")};TrustServerCertificate=true";
    options.UseSqlServer(conn);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
