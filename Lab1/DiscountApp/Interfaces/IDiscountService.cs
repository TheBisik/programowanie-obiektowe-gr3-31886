namespace Lab1.Interfaces;

public interface IDiscountService //Interfejs serwisu wymuszajacy użycie metod poniżej
{
    //wprowadzam pojęcie asynchroniczności i mówię .net, że ma wykonać zadanie aby nie czekać na baze danych
    Task<string> UseCodeAsync(string code);  // metoda: asynchronicznie zużyj kod
    
    Task AddCodeAsync(string code, string description); // metoda: Dodaj rabat do DB
    
    Task DeleteCodeAsync(int id); // metoda: usuń rabat z DB
}