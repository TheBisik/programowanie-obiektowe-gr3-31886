using System;

namespace Lab1.Models;

public abstract class DiscountCode //klasa obstakcyjna
{
    public int Id { get; set; } // int Id
    public string Code { get; set; } = string.Empty; // string Code standardowo jako pusty by uniknąć błędu
    public CodeStatus Status { get; set; } = CodeStatus.ACTIVE; //  enum CodeStatus domyślnie jako aktynwy gdy tworzymy nowy kod

    public virtual string GetCode() //metoda wirtualna zwracajaca string Code
    {
        return Code;
    }

    public virtual string GetStatus() //metoda wirtualna zwracająca Enum w postaci stringa
    {
        return Status.ToString();
    }

    public virtual void MarkAsUsed() // (maszyna stanów) metoda wirtualna pozwalająca na zmiane statusu jesli kod został użyty
    {
        if (Status == CodeStatus.ACTIVE)
        {
            Status = CodeStatus.USED;
        }
        else
        {
            throw new InvalidOperationException("Code is already used"); // Wyjątek dla reguły :?
        }
    }
    
    
    
}