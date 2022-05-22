global using LPGManager.Data;
using LPGManager;
using LPGManager.Data.Services;
using LPGManager.Data.Services.CompanyService;
using LPGManager.Data.Services.CustomerService;
using LPGManager.Data.Services.ExchangeService;
using LPGManager.Data.Services.InventoryService;
using LPGManager.Data.Services.PurchaseService;
using LPGManager.Data.Services.RoleService;
using LPGManager.Data.Services.SellService;
using LPGManager.Data.Services.SettingsService;
using LPGManager.Data.Services.SupplierService;
using LPGManager.Interfaces.CompanyInterface;
using LPGManager.Interfaces.ExchangeInterface;
using LPGManager.Interfaces.InventoryInterface;
using LPGManager.Interfaces.PurchasesInterface;
using LPGManager.Interfaces.RoleInterface;
using LPGManager.Interfaces.SellsInterface;
using LPGManager.Interfaces.SettingsInterface;
using LPGManager.Interfaces.SupplierInterface;
using LPGManager.Interfaces.UnitOfWorkInterface;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
         .ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder.UseUrls("http://0.0.0.0:3000", "https://0.0.0.0:3000");
         });
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppsDbContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("PostgreConnection")));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IPurchaseDetailsService, PurchaseDetailsService>();
builder.Services.AddScoped<IPurchaseMasterService, PurchaseMasterService>();
builder.Services.AddScoped<ISellDetailsService, SellDetailsService>();
builder.Services.AddScoped<ISellMasterService, SellMasterService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IExchangeService, ExchangeService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISizeService, SizeService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
builder.Services.AddScoped<IReturnMasterService, ReturnMasterService>();
builder.Services.AddScoped<ITenantService, TenantService>();

// Adding Jwt Bearer

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
var app = builder.Build();
//app.UseMiddleware<AuthMiddleware>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});
if (app.Environment.IsDevelopment())
{
    app.Run();
}
else
{
    app.Run("http://0.0.0.0:3000");
}