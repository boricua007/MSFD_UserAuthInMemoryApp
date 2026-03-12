using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure in-memory database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryUserAuthApp"));

// Add Identity
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();



// Moved this line down to allow for the configuration of services before building the app.
var app = builder.Build();


// Create new roles and claims for demonstration purposes
RoleManager<IdentityRole>? roleManager = app.Services.GetService<RoleManager<IdentityRole>>();

if (roleManager is null)
{
    throw new InvalidOperationException("RoleManager<IdentityRole> is not registered. Ensure Identity services are configured.");
}

string[] roleNames = { "Admin", "User", "HR" };

foreach (var roleName in roleNames)
{
    if (!await roleManager.RoleExistsAsync(roleName))
    {
        await roleManager.CreateAsync(new IdentityRole(roleName));
    }
}

Claim claim = new Claim("Permission", "ManageEmployeeRecords");
IdentityRole? hrRole = await roleManager.FindByNameAsync("HR");
if (hrRole is not null)
{
    await roleManager.AddClaimAsync(hrRole, claim);
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
