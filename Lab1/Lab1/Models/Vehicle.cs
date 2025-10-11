using System;

public abstract class Vehicle
{

    protected String Type {get; set;}
    protected double EngineCapacity { get; set; }
    protected String Model { get; set; }
    protected int Year {get; set;} // Rok jest INT


    public Vehicle(double engineCapacity, string model, int year)
    {
        this.EngineCapacity = engineCapacity;
        this.Model = model;
        this.Year = year;
    }
    

    public Vehicle(String type, double engineCapacity, string model, int year)
    {
        this.Type = type;
        this.EngineCapacity = engineCapacity;
        this.Model = model;
        this.Year = year;
    }


    public String CheckTypeOfVehicle()
    {
        return Type;
    }

    public double CheckEngineCapacity()
    {
        return EngineCapacity;
    }

    public String CheckModel()
    {
        return Model;
    }

    public int CheckYear()
    {
        return Year;
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