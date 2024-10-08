using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResolveJa.Infrastructure.Data.Persistence;
using ResolveJa.Web.MVC.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ResolveJa.Application.Mvc.Services.Implementations;
using ResolveJa.Application.Mvc.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Inje��o de servi�os
builder.Services.AddTransient<IEmpresaMvcService, EmpresaMvcServiceImpl>();
builder.Services.AddTransient<IUserMvcService, UserMvcServiceImpl>();
builder.Services.AddTransient<IFuncionarioMvcService, FuncionarioMvcServiceImpl>();
builder.Services.AddTransient<ITicketMvcService, TicketMvcServiceImpl>();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("LocalConnectionTest");
builder.Services.AddDbContext<ResolveJaDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ResolveJa.Infrastructure.Data")), ServiceLifetime.Singleton);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Adiciona seguran�a com User e Role
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)  
//builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ResolveJaDbContext>()
    .AddRoles<IdentityRole>()
    .AddDefaultUI()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider); 

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ResolveJaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ResolveJaDbContext") ?? throw new InvalidOperationException("Connection string 'ResolveJaDbContext' not found.")));


var app = builder.Build();

using (var scope = app.Services.CreateScope()) // Persist�ncia de dados default
{
    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>(); 
    if (!await roleManager.RoleExistsAsync(Roles.Gestor))  // Cria roles no banco, se n�o existirem
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.Gestor));
    }
    if (!await roleManager.RoleExistsAsync(Roles.Funcionario))
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.Funcionario));
    }
    if (!await roleManager.RoleExistsAsync(Roles.Admin))
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
    }

    var context = services.GetRequiredService<ResolveJaDbContext>(); 

    IdentityUser? user = context.Users.FirstOrDefault(u => u.Email == "admin@email.com"); // Adiciona usu�rio com email "admin..." na role Admin
    if (user is not null)
    {
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        if (!await userManager.IsInRoleAsync(user, Roles.Admin))
        {
            await userManager.AddToRoleAsync(user, Roles.Admin);
        }
    }
    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
