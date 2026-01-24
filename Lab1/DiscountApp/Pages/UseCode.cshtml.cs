using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab1.Interfaces;

public class UseCodeModel : PageModel
{
    private readonly IDiscountService _discountService; // implementacja serwisu do odczytu

    public UseCodeModel(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [BindProperty] // binduje stringa dla c# i html
    public string ResultMessage { get; set; } 
    
    public bool IsSuccess { get; set; }

    public void OnGet()
    {
        // Strona po prostu się wyświetla
    }

    public async Task<IActionResult> OnPostAsync(string inputCode) // czeka na post formularza
    {
        if (string.IsNullOrEmpty(inputCode)) // jesli nie jest pusty i empty
        {
            ResultMessage = "Musisz wpisać kod!";
            IsSuccess = false;
            return Page(); // zwraca stronę
        }

        // Wywołujemy logikę z Twojego serwisu
        var response = await _discountService.UseCodeAsync(inputCode);
        
        ResultMessage = response;
        
        // Proste sprawdzenie dla koloru alertu
        IsSuccess = response.Contains("Success") || response.Contains("pomyślnie");

        return Page(); // zwraca stronę
    }
}