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



Console.WriteLine("Hello, World!");