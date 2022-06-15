using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProySoft.Data;
using Microsoft.AspNetCore.Identity;
using ProySoft.Areas.Identity.Data;
using ProySoft.Helper;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<Usuarios>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();;


builder.Services.AddDbContext<ProySoftContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProySoftContext") ?? throw new InvalidOperationException("Connection string 'ProySoftContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddMvc();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedDataCombos.Initialize(services);

    SeedDataSucursal.Initialize(services);

    SeedDataTipoProducto.Initialize(services);

    SeedDataBurger.Initialize(services);

    SeedDataUser.Initialize(services);
}

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
