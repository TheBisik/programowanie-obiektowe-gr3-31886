using Lab1.Interfaces;
using Lab1.Services;
using Microsoft.EntityFrameworkCore;

//tworzymy builder
var builder = WebApplication.CreateBuilder(args); 

Console.WriteLine("DISCOUNT APP IS STARTING...");



//dodanie razorPages
builder.Services.AddRazorPages();

//dodanie konfiguracji postgresql
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//dodanie Dependency Injection
builder.Services.AddScoped<IDiscountService, DiscountService>();

//dodanie do apk buildera
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles(); // pozwala na pobieranie CSS i JS
app.UseRouting(); //Przekierowanie na dane strony
// app.UseAuthorization(); //mechnizm autoryzacji stron //todo - obecnie brak implementacji

app.MapRazorPages(); //"połączenie"/mapowanie nazw z linkami razora 

Console.WriteLine("DISCOUNT APP IS RUNNING...!");


//start aplikacji
app.Run(); 



Console.WriteLine("DISCOUNT APP IS CLOSING...!");
return 0;
    
