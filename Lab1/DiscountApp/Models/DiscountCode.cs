using System;

namespace Lab1.Models;

public abstract class DiscountCode
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public CodeStatus Status { get; set; } = CodeStatus.ACTIVE;

    public virtual string GetCode()
    {
        return Code;
    }

    public virtual string GetStatus()
    {
        return Status.ToString();
    }

    public virtual void MarkAsUsed()
    {
        if (Status == CodeStatus.USED)
        {
            Status = CodeStatus.EXPIRED;
        }
        else
        {
            throw new InvalidOperationException("Code is already used");
        }
    }
    
    
    
}