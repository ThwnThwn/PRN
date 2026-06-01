using Microsoft.AspNetCore.Authentication.Cookies;
using sealHkthon.Services.ThuanVCT;
using sealHkthon.WebMVCApp.ThuanVCT.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddScoped<IEventsThuanVctService, EventsThuanVctSerrvice>();
builder.Services.AddScoped<IRoundsThuanVctService, RoundsThuanVctService>();
builder.Services.AddScoped<ISystemUserAccountService, SystemUserAccountService>();


builder.Services.AddAuthentication()
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Forbidden");
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    });

var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed the database with mock data
using (var context = new sealHkthon.Repositories.ThuanVCT.DBContext.PRN222_HACKATHONContext())
{
    try
    {
        sealHkthon.WebMVCApp.ThuanVCT.Models.DbInitializer.Seed(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database seeding failed: {ex.Message}");
    }
}

app.MapHub<EventHub>("/eventHub");

app.Run();
