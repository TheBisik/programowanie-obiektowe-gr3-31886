
using System;
using Lab1.ProgramRepository;

namespace Lab1.Services;

public class ProgramService
{
    private bool running = true;
    private static ProgramService programService = null;
    private ProgramDatabase database = new ProgramDatabase();

    private ProgramService()
    {
        
    }
    public static ProgramService StartInstance()
    {
        if (programService == null) 
        {
            programService = new ProgramService();
            programService.run();
            
        }
        return programService;
    }
    
    private void run()
    {
        
        do
        {
            Console.WriteLine("[1] Show all, [2] Search by year, [3] Search by model, [4] Search by engine capacity, [5] Add car, [0] Exit\n");
            var input = Console.ReadKey().KeyChar;
            
            Console.WriteLine("\n");

            switch (input)
            {
                case '1':
                    getVehicles();
                    break;
                case '2':
                    getVehiclesByYearFromUser();
                    break;
                case '3':
                    getVehiclesByModelFromUser();
                    break;
                case '4':
                    getVehiclesByEngineCapacity();
                    break;
                case '5':
                    addVehicleCarToDatabase();
                    break;
                case '0':
                    Console.WriteLine("Program stopped");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            
        } while (running);
    }



    private void getVehicles()
    {
        var count = database.GetVehicleDatabaseCount();
        Console.WriteLine("Count of Vehicles in database:" + (count+1) + "\n");
        for (int i = 0; i <  count; i++)
        {
            var Vehicle = database.GetVehicle(i);
            Console.WriteLine(i + ". " + $"Type: {Vehicle.CheckTypeOfVehicle()}, Model: {Vehicle.CheckModel()}, Year: " + Vehicle.CheckYear() +", EngineCapacity: " + Vehicle.CheckEngineCapacity());
        }
        
    }

    private void getVehiclesByYear(int year)
    {
        int i = 0;
        Console.WriteLine("Vehicles By year:" + year +"\n");
        foreach (var Vehicle in database.GetVehiclesByYear(year))
        {
            Console.WriteLine(++i + ". " + $"Type: {Vehicle.CheckTypeOfVehicle()}, Model: {Vehicle.CheckModel()}, Year: " + Vehicle.CheckYear() +", EngineCapacity: " + Vehicle.CheckEngineCapacity());

        }
    }

    private void getVehiclesByModel(string model)
    {
        String lowerCaseInput = model.ToLower();
        string translateModel = char.ToUpper(lowerCaseInput[0]) + lowerCaseInput.Substring(1);
            
        int i = 0;
        Console.WriteLine("Pojazdy o modelu:" + translateModel +"\n");
        foreach (var Vehicle in database.GetVehiclesByModel(translateModel))
        {
            Console.WriteLine(++i + ". " + $"Type: {Vehicle.CheckTypeOfVehicle()}, Model: {Vehicle.CheckModel()}, Year: " + Vehicle.CheckYear() +", EngineCapacity: " + Vehicle.CheckEngineCapacity());

        }
    }

    private void getVehiclesByEngineCapacity(double engineCapacity)
    {
        int i = 0;
        Console.WriteLine("Vehicles by Engine Capacity:" + engineCapacity +"\n");
        foreach (var Vehicle in database.GetVehiclesByEngineCapacity(engineCapacity))
        {
            Console.WriteLine(++i + ". " + $"Type: {Vehicle.CheckTypeOfVehicle()}, Model: {Vehicle.CheckModel()}, Year: " + Vehicle.CheckYear() +", EngineCapacity: " + Vehicle.CheckEngineCapacity());
    
        }
    }
    
    private void getVehiclesByYearFromUser()
    {
        Console.Write("Input year: ");
    

        string input = Console.ReadLine();


        if (int.TryParse(input, out int year))
        {

            getVehiclesByYear(year); 
        }
        else
        {
            Console.WriteLine("Incorret Year.");
        }
    }

    
    private void getVehiclesByModelFromUser()
    {
        Console.Write("Enter the model to search for: ");
        string input = Console.ReadLine();
        getVehiclesByModel(input);
    }
    
    private void getVehiclesByEngineCapacity()
    {
        Console.Write("Enter the Engine Capacity to search for: ");
        string engineCapacity = Console.ReadLine();
        getVehiclesByEngineCapacity(double.Parse(engineCapacity));
    }

    private void addVehicleCarToDatabase()
    {
        Console.Write("Enter the model: ");
        string model = Console.ReadLine();
        
        Console.Write("Enter the year: ");
        string year = Console.ReadLine();
        int yearInt =  int.Parse(year);
        
        Console.Write("Enter the engine Capacity: ");
        string engineCapacity = Console.ReadLine();
        double engineCapacityDouble = double.Parse(engineCapacity);
        
        Console.Write("Enter the type: ");
        string type = Console.ReadLine();
        
        
        database.AddVehicle(new Car(type, engineCapacityDouble, model, yearInt));
        
        
        
        
    }
    
    
    
}