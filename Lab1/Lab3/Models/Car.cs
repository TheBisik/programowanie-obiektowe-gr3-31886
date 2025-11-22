namespace Lab3.Models;

public class Car : Vehicle
{
    public Car(double engineCapacity, string model, double year) : base(engineCapacity, model, year)
    {
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Stop()
    {
        base.Stop();
    }
}