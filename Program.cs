using Microsoft.EntityFrameworkCore;
using CartoMongo.Models;
using MongoDB.Driver;
using CartoMongo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddDbContext<CartoDbContext>(opt =>
//    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CartoDbSettings>(
    builder.Configuration.GetSection("CartoDb"));

builder.Services.AddSingleton<ActifsService>();
builder.Services.AddSingleton<TypeElementsService>();
builder.Services.AddSingleton<FluxService>();
builder.Services.AddSingleton<EnvironnementsService>();
builder.Services.AddSingleton<IconesService>();
builder.Services.AddSingleton<RolesService>();
builder.Services.AddSingleton<DAsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
<<<<<<< HEAD
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
=======
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
>>>>>>> bdb7a1ac6a2bb452098173ce94631ecb80a4f915

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

<<<<<<< HEAD
app.MapGet("/", () => "OK");


=======
>>>>>>> bdb7a1ac6a2bb452098173ce94631ecb80a4f915
app.Run();
