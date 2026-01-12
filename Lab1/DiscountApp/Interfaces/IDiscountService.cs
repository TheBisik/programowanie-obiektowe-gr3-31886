namespace Lab1.Interfaces;

public interface IDiscountService
{
    Task<string> UseCodeAsync(string code);
    
    Task AddCodeAsync(string code, string description);
}