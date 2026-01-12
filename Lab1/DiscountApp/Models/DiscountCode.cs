namespace Lab1.Models;

public abstract class DiscountCode
{
    private int Id { get; set; }
    private string Code { get; set; }
    private CodeStatus Status { get; set; }
}