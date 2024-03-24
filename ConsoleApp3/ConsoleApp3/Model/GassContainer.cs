using ConsoleApp3.Interface;

namespace ConsoleApp3.Model;

public class GassContainer : Container, IHazardNotifier
{
    private double atmosphericPressure;
    public GassContainer(double height, double ownWeight, double maxLoadWeight, double depth,double atmosphericPressure) : base(height, ownWeight, maxLoadWeight, depth)
    {
        this.atmosphericPressure = atmosphericPressure;
        createSerialNumber("G");
    }

    public override void emptyCargo()
    {
        setCargoWeight(getCargoWeight()*0.05 - getCargoWeight());
    }

    public override void loadCargo(double weight)
    {
        if (getCargoWeight()+weight>getMaxLoadWeight())
        {
            sendNotification("Próba załadowania zbyt dużego ładunku w kontenerze o numerze: " +  getSerialNumber() );
            try
            {
                throw new OverfillException();
            }
            catch (OverfillException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        setCargoWeight(weight);
    }

    public void sendNotification(string message)
    {
        Console.WriteLine(message);
    }
}