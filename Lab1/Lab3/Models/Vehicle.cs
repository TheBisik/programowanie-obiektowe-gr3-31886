namespace Lab3.Models;

public abstract class Vehicle
{
    private double EngineCapacity { get; set; }
    private String Model { get; set; }
    private double Year {get; set; }

    public Vehicle(double engineCapacity, string model, double year)
    {
        EngineCapacity = engineCapacity;
        Model = model;
        Year = year;
    }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle started");
    }

    public virtual void Stop()
    {
        Console.WriteLine("Vehicle stopped");
    }

}