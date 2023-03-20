using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProyectoMongoRuben.Models;
using ProyectoMongoRuben.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<TerrariaStoreDatabaseSettings>(
            builder.Configuration.GetSection(nameof(TerrariaStoreDatabaseSettings)));

builder.Services.AddSingleton<ITerrariaStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<TerrariaStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("TerrariaStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IJugadorService, JugadorService>();
builder.Services.AddScoped<IJefesService, JefesService>();
builder.Services.AddScoped<IRarezaService, RarezaService>();
builder.Services.AddScoped<IArmasService, ArmasService>();
builder.Services.AddScoped<IClaseService, ClaseService>();
//
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
