using Lab1.Interfaces;
using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Services;

public class DiscountService : IDiscountService
{
    private readonly ApplicationDbContext _context;
    
    public DiscountService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> UseCodeAsync(string inputCode)
    {
        var discount = await _context.Discounts
            .FirstOrDefaultAsync(d => d.Code == inputCode);

        if (discount == null)
        {
            return "ERROR: Discount not found in system";
        }

        if (discount.Status == CodeStatus.USED)
        {
            return $"ERROR: Code {discount.Code} has already been used and cannot be used again.";
        }
        
        if (discount.Status == CodeStatus.EXPIRED)
        {
            return $"ERROR: Code {discount.Code} has expired.";
        }
        
        try
        {
            discount.MarkAsUsed();
            
            await _context.SaveChangesAsync();
            
            return $"Success! Code {discount.Code} has been used. New Status: {discount.Status}";
        }
        catch (InvalidOperationException ex)
        {
            return $"ERROR: {ex.Message}";
            // return $"Error! Code {discount.Code} has been used. Status: {discount.Status}";
        }
    }

    public async Task AddCodeAsync(string code, string description)
    {
        var newDiscount = new Discount
        {
            Code = code,
            Description = description,
            Status = CodeStatus.ACTIVE
        };
        
        _context.Discounts.Add(newDiscount);
        await _context.SaveChangesAsync();
        
    }
    
}