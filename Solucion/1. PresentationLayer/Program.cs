using _2._BusinessLayer;
using _3._DataLayer;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();l
builder.Services.AddEndpointsApiExplorer(); // necesario para Swagger
builder.Services.AddSwaggerGen();

//variable que almacena la cadena conexión
var sqlString = builder.Configuration.GetConnectionString("sqlString");
builder.Services.AddScoped<ProductDL>(c => new ProductDL(sqlString!));
builder.Services.AddScoped<ProductBL>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
