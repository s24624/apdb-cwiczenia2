namespace ConsoleApp3.Model;

public abstract class Container
{
    private static List<int> serialNumbers = new List<int>();
    private double cargoWeight;
    private double height;
    private double ownWeight;
    private double depth;
    private string serialNumber;
    private double maxLoadWeight;

    public Container(double height, double ownWeight, double maxLoadWeight,double depth)
    {
        
        this.height = height;
        this.ownWeight = ownWeight;
        this.depth = depth;
        this.maxLoadWeight = maxLoadWeight;
    }
    protected void createSerialNumber(string type)
    {
        serialNumber = " ";
        Random rand = new Random();
        int number = rand.Next();

        while (serialNumbers.Contains(number))
        {   
            number = rand.Next();
        }
        serialNumbers.Add(number);
        serialNumber = "KON-" + type + number;
    }

    public abstract void emptyCargo();

    public abstract void loadCargo(double weight);

    protected void setCargoWeight(double weight)
    {
        cargoWeight += weight;
    }

    public double getMaxLoadWeight()
    {
        return maxLoadWeight;
    }

    public double getCargoWeight()
    {
        return cargoWeight;
    }

    public string getSerialNumber()
    {
        return serialNumber;
    }
    

}