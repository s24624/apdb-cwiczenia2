
using ConsoleApp3.Interface;

namespace ConsoleApp3.Model;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool isSafe;
    public LiquidContainer(double height, double ownWeight, double maxLoadWeight, double depth,bool isSafe) :
        base(height, ownWeight, maxLoadWeight, depth)
    {
        this.isSafe = isSafe;
        createSerialNumber("L");
    }

    public override void emptyCargo()
    {
        setCargoWeight(getCargoWeight()*-1);
    }

    public override void loadCargo(double weight)
    {
        if (weight > 0)
        {
            if (!type() && getCargoWeight() + weight > 0.5 * getMaxLoadWeight())
            {
                sendNotification("Kontener o numerze: " + getSerialNumber() + " w przypadku ładunku niebezpiecznego " +
                                 "może przechować jedynie 50% jego wagi maksymalnego ładunku \n" +
                                 " Maksymalna waga ładunku: " +
                                 +0.5 * getMaxLoadWeight());
            }
            else if (getCargoWeight() + weight > 0.9 * getMaxLoadWeight())
            {
                
                try
                {
                    sendNotification("Kontener o numerze: " + getSerialNumber() + "moze przechowac jedynie" +
                                     " 90% jego wagi maksymalnego ładunku, spróbuj ponownie \n " +
                                     " Maksymalna waga ładunku: "
                                     + 0.9 * getMaxLoadWeight());
                    throw new OverfillException();
                }catch (OverfillException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            else
            {
                setCargoWeight(weight);
                Console.WriteLine("ładunek pomyslnie zaladowany");
            }
        }else
            Console.WriteLine("Waga musi byc wieksza od 0");
    }
    private bool type()
    {
        return isSafe;
    }

    public void sendNotification(string message)
    {
        Console.WriteLine(message);
    }
}