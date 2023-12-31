using Microsoft.EntityFrameworkCore;
using ParkingAPI.Data;
using ParkingAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IControlRepository, ControlRepository>();
builder.Services.AddTransient<IPricesRepository, PricesRepository>();

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
