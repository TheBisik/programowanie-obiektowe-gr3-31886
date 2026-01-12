using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models;

[Table("DiscountTable")]
public class Discount : DiscountCode
{
    public string Description { get; set; }
    
    
}