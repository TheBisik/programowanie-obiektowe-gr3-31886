using System;
using System.Collections.Generic;

namespace Lab1.ProgramRepository;

public class ProgramDatabase
{
    private List<Vehicle> Vehicles { get; set; } =
    [
        
        new Bike(9.9, "Cross", 2025),
        new Bike(9.9, "Yamaha", 2004),
        new Car(2.0, "Audi", 2005),
        new Car(2.0, "BMW", 2012)
    ];

    public void AddVehicle(Vehicle vehicle)
    {
        this.Vehicles.Add(vehicle);
    }

    public Vehicle GetVehicle(int x)
    {
        return this.Vehicles[x];
    }

    public int GetVehicleDatabaseCount()
    {
        return this.Vehicles.Count;
    }
    
    
    public List<Vehicle> GetVehiclesByYear(int year)
    {
        return this.Vehicles.FindAll(vehicle => vehicle.CheckYear() == year);
    }

    public List<Vehicle> GetVehiclesByEngineCapacity(double engineCapacity)
    {
        return this.Vehicles.FindAll(vehicle => vehicle.CheckEngineCapacity() == engineCapacity);
    }

    public List<Vehicle> GetVehiclesByModel(string model)
    {
        
        return this.Vehicles.FindAll(vehicle => vehicle.CheckModel().Equals(model, StringComparison.OrdinalIgnoreCase));
    }
}