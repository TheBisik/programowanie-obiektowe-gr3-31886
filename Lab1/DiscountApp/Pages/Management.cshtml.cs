using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab1.Interfaces;

public class ManagementModel : PageModel
{
    private readonly IDiscountService _service;
    public string Message { get; set; }

    public ManagementModel(IDiscountService service) => _service = service;

    public async Task<IActionResult> OnPostAsync(string code, string description)
    {
        await _service.AddCodeAsync(code, description);
        Message = "Kod dodany pomyślnie!";
        return Page();
    }
}