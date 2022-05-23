using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAppApi.Data;
using WebAppApi.Hubs;
using WebAppApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebAppApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppApiContext") ?? throw new InvalidOperationException("Connection string 'WebAppApiContext' not found.")));

builder.Services.AddCors(option =>
{
    option.AddPolicy("Allow All",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        }
        );
});


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
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
app.UseEndpoints(endpoints => { endpoints.MapHub<MyHub>("http://localhost:5019/contactHub" ); }); 

app.UseCors("Allow All");

app.UseAuthorization();

app.MapControllers();

app.Run();
