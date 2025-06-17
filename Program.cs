using DungeonMentor.Data;
using DungeonMentor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Регистрация БД
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=dungeonmentor.db"));

// Регистрация Identity (ТОЛЬКО ОДИН ИЗ ВАРИАНТОВ!)

// Вариант 1: Используйте ЭТО (рекомендуется для стандартного UI)
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<AppDbContext>();

// ИЛИ Вариант 2: Если нужны роли и кастомизация
// builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//     .AddEntityFrameworkStores<AppDbContext>()
//     .AddDefaultTokenProviders();

// Настройки cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Обязательно для Identity UI

var app = builder.Build();

// Применение миграций (если БД не создана)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // или EnsureCreated()
}

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Training}/{action=Index}/{id?}");

app.MapRazorPages(); // Для Identity UI

app.Run();