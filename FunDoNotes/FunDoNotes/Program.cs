using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Context;
using RepoLayer.Interfaces;
using RepoLayer.Services;
using ManagerLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FunDoContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddTransient<IUserRepo, UserServices>();
builder.Services.AddTransient<IuserManager, UserManager>();
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
