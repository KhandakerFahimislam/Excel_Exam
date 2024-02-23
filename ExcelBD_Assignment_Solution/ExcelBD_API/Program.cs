using ExcelBD_API.HostedServices;
using ExcelBD_API.Repositories.Interfaces;
using ExcelBD_API.Repositories;
using ExcelBD_API.Services;
using ExelBD_Shared.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ExcelDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("db"), ma => ma.MigrationsAssembly("ExcelBD_API")));
builder.Services.AddScoped<DbMigrationAndSeederService>();
builder.Services.AddHostedService<DbMigrationAndSeederHostedService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
    settings =>
    {
        settings.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
        settings.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
    }
    );
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
