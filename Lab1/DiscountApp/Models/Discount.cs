using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models;

[Table("DiscountTable")] // Data Annotation dla EF Core mapująca nazwe tabeli
public class Discount : DiscountCode // klasa z dziedziczeniem po DiscountCode
{
    public string Description { get; set; } // pole string z opisem
    
    
}