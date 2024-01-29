using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DataLayer.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new NullReferenceException("No connection!");

builder.Services.AddDbContextFactory<ApplicationDbContext>((DbContextOptionsBuilder options) =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<UtilizadorService>();
builder.Services.AddTransient<LicitacaoService>();
builder.Services.AddTransient<LeilaoService>();
builder.Services.AddTransient<FotoService>();
builder.Services.AddTransient<ClassificacaoService>();
builder.Services.AddTransient<CategoriaService>();
builder.Services.AddTransient<CarregamentoService>();
builder.Services.AddControllersWithViews();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


