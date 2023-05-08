using VendingMachine.Business.Repository;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Api;
using VendingMachine.Business.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IVendingService, VendingService>();
builder.Services.AddSingleton<IVendingMachineRepository, VendingMachineRepository>();
builder.Services.AddCors(options => options.AddPolicy("AllowAll",
    builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    }));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRouting();
app.UseCors("AllowAll");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
