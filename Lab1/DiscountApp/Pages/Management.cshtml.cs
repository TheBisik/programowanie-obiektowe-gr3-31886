using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab1.Interfaces;

public class ManagementModel : PageModel
{
    private readonly IDiscountService _service;
    public string Message { get; set; }

    public ManagementModel(IDiscountService service) => _service = service; // konstruktor

    // public ManagementModel(IDiscountService service)
    // {
    //     _service = service;
    // }

    public async Task<IActionResult> OnPostAsync(string code, string description) // Model Binding automatycznie wyciąga dane
    {
        await _service.AddCodeAsync(code, description); // dodaje asynchronicznie do bazy kod
        Message = "Kod dodany pomyślnie!";
        return Page(); //zwraca stronę z nowym kodem (odświerza)
    }
}