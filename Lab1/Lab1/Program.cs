//zad 0 dodaj warunek if dla 14 latków
const int requiredAge = 14;
const string accessDenied = "Musisz mieć 18 lat.";
const string accessAllowed = "Witamy w naszym sklepie";

int age;

do
{
    Console.WriteLine("Podaj swój wiek: ");

    string input = Console.ReadLine();

    bool success = int.TryParse(input, out age);

    if (!success)
    {
        Console.WriteLine("Podaj poprawną wartość!");
    }
    else
    {
        if (age >= requiredAge && age < 18)
        {
            Console.WriteLine("Osoby, które mają 14 lat mają dostęp do sklepu, ale nie mogą kupić i zarejestrować karty SIM");
        }
        else if (age >= 18)
        {
            Console.WriteLine(accessAllowed);
        }
        else
        {
            Console.WriteLine(accessDenied);
        }
    }
} while (age < 14);


//zad 1
//Napisz program, który pyta użytkownika o hasło, dopóki nie wpisze poprawnego („admin123”).

string password;
do
{
    Console.Write("Podaj hasło: ");
    password = Console.ReadLine();
}
while (password != "admin123");
Console.WriteLine("Zalogowano pomyślnie!");



// zad 2
// Poproś użytkownika o podanie liczby większej od zera. Jeśli poda liczbę ujemną lub 0 — zapytaj ponownie.


int userNumber;


do
{
    Console.WriteLine("Podaj Liczbę: ");

    string input = Console.ReadLine();

    bool success = int.TryParse(input, out userNumber);

    if (!success)
    {
        Console.WriteLine("Podaj poprawną wartość! Liczbę wiekszą od 0!");
    }

} while (userNumber < 0);



//zad 3
//Zadanie 3: Utwórz tablicę z 5 nazwami miast i wypisz każde miasto w osobnej linii

string[] cityList = { "Grudziądz", "Nowe", "Poznań", "Gdańsk", "Kraków" };
foreach (string city in cityList)
{
    Console.WriteLine(($"Miasto: {city}"));
}
