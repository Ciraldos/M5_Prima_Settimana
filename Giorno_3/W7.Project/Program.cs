using Microsoft.AspNetCore.Authentication.Cookies;
using W7.Project.DataLayer;
using W7.Project.DataLayer.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt => opt.LoginPath = "/Account/Login")
    ;

// ***** Servizi di Applicazione *****
builder.Services
    .RegisterDAOs() // in W7.Project.DataLayer.SqlServer.Helpers
    .AddDbContext() // in W7.Project.DataLayer.Helpers
    ;
// ***** Fine configurazione servizi di applicazione *****

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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

app.Run();
