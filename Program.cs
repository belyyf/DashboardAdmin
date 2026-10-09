using DashboardAdmin.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DI: репозиторий дашборда (Singleton — данные в памяти живут всё время работы приложения)
builder.Services.AddSingleton<IDashboardRepository, InMemoryDashboardRepository>();

var app = builder.Build();

// ===== PIPELINE =====
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
