using Lab1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CodesModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public List<Discount> AllCodes { get; set; }

    public CodesModel(ApplicationDbContext context) => _context = context;

    public void OnGet()
    {
        
        AllCodes = _context.Discounts.OrderByDescending(d => d.Id).ToList();
    }
}