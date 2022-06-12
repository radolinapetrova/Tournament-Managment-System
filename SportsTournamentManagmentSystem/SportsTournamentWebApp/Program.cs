using Microsoft.AspNetCore.Authentication.Cookies;
using DataAccessLayer;
using Entities;
using BusinessLogicLayer;
using BusinessLogic;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddTransient<ITournamentManager, TournamnentDBManager>();
builder.Services.AddTransient<ITournamentReader, TournamnentDBManager>();


builder.Services.AddTransient<IUser, UserDBManager>();
builder.Services.AddTransient<IAutoIncrement, UserDBManager>();

builder.Services.AddSingleton<TournamentManager>();


builder.Services.AddSingleton<UserManager>();





// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; ;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = "/LogIn";
        options.AccessDeniedPath = "/Index";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseSession();
app.Run();
