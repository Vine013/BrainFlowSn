using BrainFlow.Data;
using BrainFlow.Repository;
using BrainFlow.Repository.Interfaces;
using BrainFlow.Service;
using BrainFlow.Service.Interfaces;
using BrainFlow.UI.Web.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/EfetuarLogin";
        options.AccessDeniedPath = "/Home/AcessoNegado";
    });

// Registro dos Repositórios
builder.Services.AddScoped<IUsuarioREP, UsuarioREP>();
builder.Services.AddScoped<IUsuarioLoginREP, UsuarioLoginREP>();
builder.Services.AddScoped<IStatusGeralREP, StatusGeralREP>();
builder.Services.AddScoped<IUsuarioTipoREP, UsuarioTipoREP>();
builder.Services.AddScoped<IAfiliadoREP, AfiliadoREP>();

// Registro dos Serviços
builder.Services.AddScoped<IAutenticacaoService, AutenticacaoService>();
builder.Services.AddScoped<IAfiliadoService, AfiliadoService>();

// Registro dos Helpers e outras classes
builder.Services.AddScoped<AcessaDados>();
builder.Services.AddScoped<EmailSender>();
builder.Services.AddScoped<HttpClient>();

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

app.MapAreaControllerRoute(
    name: "AdminArea",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "AFiliadoArea",
    areaName: "Afiliado",
    pattern: "Afiliado/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
