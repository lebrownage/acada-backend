using Acada.Business.DTOs;
using Acada.Business.Interfaces;
using Acada.Business.Services;
using Acada.Data;
using Acada.Data.Repositories;
using Acada.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection")));

builder.Services.AddAutoMapper(services => services.AddProfile(new MapProfiles()));

//Business Layer
builder.Services.AddScoped<IProductService, ProductService>();

//Domain and Data Layer
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
