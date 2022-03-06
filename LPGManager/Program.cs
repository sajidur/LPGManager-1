global using LPGManager.Data;
using LPGManager.Data.Services.PurchaseService;
using LPGManager.Data.Services.SupplierService;
using LPGManager.Interfaces.PurchasesInterface;
using LPGManager.Interfaces.SupplierInterface;
using LPGManager.Interfaces.UnitOfWorkInterface;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppsDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IPurchaseDetailsService, PurchaseDetailsService>();
builder.Services.AddScoped<IPurchaseMasterService, PurchaseMasterService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
