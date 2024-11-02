using BimboNicaragua.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Definir el context para vincular conexion a la base de datos
builder.Services.AddDbContext<PanPlusBimboContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectSQLBimbo")));

//builder.Services.AddDbContext<CMI_BimboContext>(options =>
 //   options.UseSqlServer(builder.Configuration.GetConnectionString("connectSQLCMI_Bimbo")));

// Agregar el servicio HttpClient
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
