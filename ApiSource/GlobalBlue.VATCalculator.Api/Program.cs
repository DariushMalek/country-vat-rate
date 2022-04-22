using GlobalBlue.VATCalculator.Data;
using GlobalBlue.VATCalculator.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("sqlite");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataServices(connectionString);
builder.Services.AddBusinessServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    using var seedDataService = scope.ServiceProvider.GetRequiredService<SeedDataService>();
    await seedDataService.SeedData();
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

public partial class Program { }