using Lab1.Interfaces;
using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Services;

public class DiscountService : IDiscountService // implementacja interfejsu
{
    private readonly ApplicationDbContext _context; // Dependency injection
    
    public DiscountService(ApplicationDbContext context) // połączenie z bazą
    {
        _context = context;
    }

    public async Task<string> UseCodeAsync(string inputCode) //metoda interfejsu
    {
        var discount = await _context.Discounts // zawieszenie metody zwalniając wątek oczekując na bazę
            .FirstOrDefaultAsync(d => d.Code == inputCode); //znajdź w bazie pierwszy rekord pasujacy do warunku lub zwórć null
                                    //Delegat po przez lambdę w innym wypadku trzeba użyć boola który zwraca true/false // mniej pisania ten sam efekt
                                    
                                    // Tak musiałaby wyglądać zwykła metoda
                                    // public bool CheckCode(Discount d)
                                    // {
                                    //     return d.Code == inputCode;
                                    // }
                                    
        if (discount == null) // sprawdzamy czy obiekt jest pusty -> znaczy to, że nie ma go w bazie danych
        {
            return "ERROR: Discount not found in system";
        }

        if (discount.Status == CodeStatus.USED) // jesli status obiektu jest użyty wyświetl kod z informacją o użyciu.
        {
            return $"ERROR: Code {discount.Code} has already been used and cannot be used again.";
        }
        
        if (discount.Status == CodeStatus.EXPIRED) // jesli status obiektu jest wygasły wyświetl, kod i informacje o wygaśnięciu
        {
            return $"ERROR: Code {discount.Code} has expired.";
        }
        
        try //spróbuj
        {
            discount.MarkAsUsed(); //zmienić stan obiektu na użyty według metody obiektu
            
            await _context.SaveChangesAsync(); //zapisz go do bazy danych
            
            return $"Success! Code {discount.Code} has been used. New Status: {discount.Status}"; // zwórc informacje o sukcesie użytego kodu i wyświetl nowy satus kodu
        }
        catch (InvalidOperationException ex) // wyłap wyjątek
        {
            return $"ERROR: {ex.Message}"; // zwórć error wyjątku
            // return $"Error! Code {discount.Code} has been used. Status: {discount.Status}";
        }
    }

    public async Task AddCodeAsync(string code, string description) // metoda intefejsu dodwania kodu
    {
        var newDiscount = new Discount // wytwarzamy nowy obiekt
        {
            Code = code,
            Description = description,      // przypisujemy wartości do obiektu
            Status = CodeStatus.ACTIVE
        };
        
        _context.Discounts.Add(newDiscount); // dodajemy do bazy danych nowy rabat
        await _context.SaveChangesAsync(); // zapisujemy do bazy danych zwalniając wątek
        
    }
    
    public async Task DeleteCodeAsync(int id) // metoda intefejsu -> Usuwamy rabat
    {
        var code = await _context.Discounts.FindAsync(id); //zmiena code która przechowuje obiekt Discount, przypisuje do niej id z bazy danych
        if (code != null) // jesli nie jest pusty
        {
            _context.Discounts.Remove(code); // usuń z db kod
            await _context.SaveChangesAsync(); // zapisz zmiany do db zwalniając wątek
        }
    }
    
}