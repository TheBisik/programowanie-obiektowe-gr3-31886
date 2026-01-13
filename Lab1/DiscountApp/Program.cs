using Lab1.Interfaces;
using Lab1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 

Console.WriteLine("DISCOUNT APP IS STARTING...");




builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDiscountService, DiscountService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages(); 

Console.WriteLine("DISCOUNT APP IS RUNNING...!");

app.Run(); 



Console.WriteLine("DISCOUNT APP IS CLOSING...!");
    
