using Lab1.Interfaces;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class CodesModel : PageModel
{
    
    private readonly IDiscountService _discountService;
    private readonly ApplicationDbContext _context;

    public List<Discount> AllCodes { get; set; } = new();

    
    public CodesModel(ApplicationDbContext context, IDiscountService discountService)
    {
        _context = context;
        _discountService = discountService;
    }

    public void OnGet()
    {
        
        AllCodes = _context.Discounts.OrderByDescending(d => d.Id).ToList();
    }

    
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _discountService.DeleteCodeAsync(id);
        return RedirectToPage();
    }
}