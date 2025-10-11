using System;

public class Bike : Vehicle
{

    public Bike(double engineCapacity, string model, int year) : base(engineCapacity, model, year)
    {
        this.Type = "Bike";

    }


    public Bike(String type, double engineCapacity, string model, int year) : base(type, engineCapacity, model, year)
    {

    }
}