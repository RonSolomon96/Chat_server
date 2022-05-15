using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAppApi.Data;
using WebAppApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebAppApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppApiContext") ?? throw new InvalidOperationException("Connection string 'WebAppApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IService, Service>();

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
