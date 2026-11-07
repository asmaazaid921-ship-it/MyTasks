using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Store.Data;
using Store.Models;
using Store.Repository;
using Store.Utilisite;
using Store.Utilisite.DbSeeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository<ApplicationUserOTP>, Repository<ApplicationUserOTP>>();
//builder.Services.AddTransient<IEmailSender,EmailSender >();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddTransient< IEmailSender,EmailSender>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opption =>
{
    opption.User.RequireUniqueEmail = true;
    opption.SignIn.RequireConfirmedEmail = true;
}
).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddTransient< IDbInitilizer,DbInitilizer>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbInitilizer = scope.ServiceProvider.GetRequiredService<IDbInitilizer>();
    await dbInitilizer.InitializeAsync();

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
