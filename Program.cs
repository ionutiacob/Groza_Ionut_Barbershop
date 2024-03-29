using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Groza_Ionut_Barbershop.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Groza_Ionut_BarbershopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Groza_Ionut_BarbershopContext") ?? throw new InvalidOperationException("Connection string 'Groza_Ionut_BarbershopContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Groza_Ionut_BarbershopContext") ?? throw new InvalidOperationException("Connectionstring 'Groza_Ionut_BarbershopContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = false)
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Appointments");
    options.Conventions.AuthorizeFolder("/Barbers", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Customers", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Services", "AdminPolicy");
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
