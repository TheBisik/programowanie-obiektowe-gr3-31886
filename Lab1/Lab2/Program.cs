// See https://aka.ms/new-console-template for more information


//zad 6 i 7


//zad 6 Zadanie 6: Dodaj klasę Kot, która również dziedziczy po Zwierze i ma metodę Miaucz().

var animalList = new Zwierze[] { new Kot(), new Pies() };

foreach (var Zwierzak in animalList)
{
    Zwierzak.DajGlos();
}


public abstract class Zwierze
{
    public void Jedz() => Console.WriteLine("Zwierzę je");
    public abstract void DajGlos();
}

//zad 7
// Utwórz tablicę Zwierze[] z obiektami różnych zwierząt i wywołaj DajGlos() w
//     pętli foreach


public class Pies : Zwierze
{
    String typeOfAnimal = "Pies: ";
    public void Szczekaj() => Console.WriteLine($"{typeOfAnimal}Hau hau!");
    public override void DajGlos() => Szczekaj();
}


public class Kot : Zwierze
{
    String typeOfAnimal = "Kot: ";
    public void Miaucz()  => Console.WriteLine($"{typeOfAnimal}Miał, Miał!");
    public override void DajGlos() => Miaucz();
}


