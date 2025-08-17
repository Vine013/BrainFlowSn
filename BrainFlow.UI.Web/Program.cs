using BrainFlow.Data;
using BrainFlow.Repository.Interfaces;
using BrainFlow.Repository;
using BrainFlow.UI.Web.Helpers;
using BrainFlow.Service.Interfaces;
using BrainFlow.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<AcessaDados>();
builder.Services.AddScoped<EmailSender>();

// Registrando as interfaces e suas implementações dos Repositórios
builder.Services.AddScoped<IUsuarioREP, UsuarioREP>();
builder.Services.AddScoped<IUsuarioLoginREP, UsuarioLoginREP>();

// Registrando o serviço de autenticação
builder.Services.AddScoped<IAutenticacaoService, AutenticacaoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

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
