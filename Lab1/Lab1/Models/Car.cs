using System;

public class Car : Vehicle
{

    public Car(double engineCapacity, string model, int year) : base(engineCapacity, model, year)
    {
        this.Type = "Car"; 
    }
    

    public Car(String type, double engineCapacity, string model, int year) : base(type, engineCapacity, model, year)
    {
        
    }

    public override void Start()
    {
        Console.WriteLine("Engine Start");
    }

    public override void Stop()
    {
        Console.WriteLine("Engine Stop");
    }
}