using Business;
using DataAccess;
using DataAccess.Repository;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



////mapper tanýmý
//builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddScoped<IBaseService<User>, BaseService<User>>();


builder.Services.AddScoped<IBaseRepository<FCurrency>, BaseRepository<FCurrency>>();
builder.Services.AddScoped<IBaseService<FCurrency>, BaseService<FCurrency>>();


builder.Services.AddScoped<IBaseRepository<ExchangeRate>, BaseRepository<ExchangeRate>>();
builder.Services.AddScoped<IBaseService<ExchangeRate>, BaseService<ExchangeRate>>();



builder.Services.AddDbContext<DataContext>(x =>
    x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(DataContext))?.GetName().Name);
        }
    ));
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}

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
