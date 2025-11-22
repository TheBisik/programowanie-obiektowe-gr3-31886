namespace Lab3.Services;

public class ProgramService
{
    private bool running = true;
    private static ProgramService programService = null;

    public void run()
    {
        GetInstance();
        
        do
        {
            Console.WriteLine("[1] Show all, [2] Search by year, [3] Search by model, [4] Search by engine capacity, [5] Add car, [0] Exit\n");
            var input = Console.ReadKey().KeyChar;
            
            Console.WriteLine("\n");

            switch (input)
            {
                case '1':
                    //foreach interface connected to repo
                    break;
                case '2':
                    // Search object by year
                    break;
                case '3':
                    // search by model
                    break;
                case '4':
                    //Search by engine capacity
                    break;
                case '5':
                    //Add car 
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

    private static ProgramService GetInstance()
    {
        if (programService == null) programService = new ProgramService();
        return programService;
    }
}