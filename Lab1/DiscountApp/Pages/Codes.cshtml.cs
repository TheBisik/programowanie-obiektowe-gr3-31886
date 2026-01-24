using Lab1.Interfaces;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


public class CodesModel : PageModel
{
    
    private readonly IDiscountService _discountService;   //import serwisu
    private readonly ApplicationDbContext _context; //import repo

    public List<Discount> AllCodes { get; set; } = new();  // lista kodów

    
    public CodesModel(ApplicationDbContext context, IDiscountService discountService) //konstruktor
    {
        _context = context;
        _discountService = discountService;
    }

    public void OnGet() // metoda która 
    {
        
        AllCodes = _context.Discounts.OrderByDescending(d => d.Id).ToList(); // z db Przypisujemy rekordy do allcodes z tabeli Discounts segregowane po id zamieniając na listę
    }

    
    public async Task<IActionResult> OnPostDeleteAsync(int id)  // metoda która czeka na POST
    {
        await _discountService.DeleteCodeAsync(id); // wykonaj metode deleetecodeasync z serwisu
        return RedirectToPage(); // odświerza stronę
    }
}