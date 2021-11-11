using crudExample.Application;
using crudExample.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");
var services = builder.Services;

services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
services.AddSwaggerGen();
services.AddRouting();
services.AddControllers();
services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(e =>  e.MapControllers());
app.Run();

