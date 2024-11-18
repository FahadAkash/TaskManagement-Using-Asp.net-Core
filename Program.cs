using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WEBAPITEST.src.Application.Core.Models.StudentManagementSystemModels;
using WEBAPITEST.src.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<TaskModel, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;       
    var context = services.GetRequiredService<SchoolContext>();
    var userManager = services.GetRequiredService<userManager<User>>();
    var roleManager = services.GetRequiredService<roleManager<IdentityRole>>();
    context.Database.Migrate();
    SeedData.Initialize(context, userManager, roleManager).Wait();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public static class SeedData
{
    public static async Task Initialize(ApplicationDbContext context,
                                        UserManager<User> userManager,
                                        RoleManager<IdentityRole> roleManager)
    {
        string[] roles = new string[] { "Admin", "User" };
        foreach (string role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        var adminEmail = "admin@taskmanager.com";
        var adminPassword = "Admin@123";
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var adminUser = new User { UserName = adminEmail, Email = adminEmail };
            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
