using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o => {
        o.LoginPath = "/Usuario/Login";
        o.AccessDeniedPath = "/Usuario/AccesoDenegado";
        o.Cookie.Name = "ESFE.Acceso";
        o.Cookie.HttpOnly = true;
        o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        o.Cookie.SameSite = SameSiteMode.Lax;
        o.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        o.SlidingExpiration = false;
    });
builder.Services.AddAuthorization();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Usuario/Error");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute("default",
    "{controller=Usuario}/{action=Login}/{id?}");
app.Run();