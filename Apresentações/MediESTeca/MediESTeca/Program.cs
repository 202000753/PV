using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediESTeca.Data;
using Microsoft.AspNetCore.Identity;
using MediESTeca.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using MediESTeca.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<MediESTecaContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MediESTecaContext")));

var connectionString = builder.Configuration.GetConnectionString("MediESTecaComIdentityContextConnection");
builder.Services.AddDbContext<MediESTecaComIdentityContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Utente>(options =>
    {
        // Password settings 
        options.Password.RequireDigit = false; 
        options.Password.RequiredLength = 6; 
        options.Password.RequireNonAlphanumeric = false; 
        options.Password.RequireUppercase = false; 
        options.Password.RequireLowercase = false;

        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MediESTecaComIdentityContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<IEmailSender, EmailSender>();


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
app.MapRazorPages();

app.Run();

public partial class Program { }