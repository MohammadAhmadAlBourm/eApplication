using eApplication.Database;
using eApplication.Extensions;
using eApplication.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMapster();
TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly);

builder.Services.AddEndpoints(typeof(Program).Assembly);


builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapEndpoints();

app.Run();