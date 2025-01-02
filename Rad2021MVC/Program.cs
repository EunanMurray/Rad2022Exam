using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rad2021MVC.Data;
using Rad2021ConsoleApp.Data;
using Rad2021MVC.Models;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add logging configuration
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Configure DbContexts
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<Rad2022Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure Identity with roles
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Initialize Database and Roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Create roles
        var roles = new[] { "Committee Admin", "Employee" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                logger.LogInformation($"Created role: {role}");
            }
        }

        // Create users
        var users = new[]
        {
            new { Email = "admin@terenurecc.ie", FirstName = "Paul", LastName = "Dalton", Password = "Admin$1", Roles = new[] { "Committee Admin", "Employee" } },
            new { Email = "bloggsb@terenurecc.ie", FirstName = "Bill", LastName = "Bloggs", Password = "Employee$1", Roles = new[] { "Committee Admin", "Employee" } },
            new { Email = "blighb@terenurecc.ie", FirstName = "Mary", LastName = "Bligh", Password = "Employee$2", Roles = new[] { "Employee" } },
            new { Email = "rotterm@terenurecc.ie", FirstName = "Martha", LastName = "Rotter", Password = "Employee$3", Roles = new[] { "Employee" } }
        };

        foreach (var userData in users)
        {
            var user = await userManager.FindByEmailAsync(userData.Email);
            if (user == null)
            {
                var newUser = new ApplicationUser
                {
                    UserName = userData.Email,
                    Email = userData.Email,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName
                };

                var result = await userManager.CreateAsync(newUser, userData.Password);
                if (result.Succeeded)
                {
                    logger.LogInformation($"Created user: {userData.Email}");
                    foreach (var role in userData.Roles)
                    {
                        await userManager.AddToRoleAsync(newUser, role);
                        logger.LogInformation($"Added {userData.Email} to role: {role}");
                    }
                }
                else
                {
                    logger.LogWarning($"Failed to create user {userData.Email}: {string.Join(", ", result.Errors)}");
                }
            }
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred during database initialization");
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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