namespace ConsoleApp3.Model;

public class Ship
{
    public static int number;
    private List<Container> containers;
    private double maxSpeed;
    private int maxContainersNumber;
    private double maxContainersWeight;
    private double containersWeight;
    private double containersNumber;

    public Ship(double maxSpeed, int maxContainersNumber, double maxContainersWeight)
    {
        number++;
        containersWeight = 0;
        containers = new List<Container>();
        this.maxSpeed = maxSpeed;
        this.maxContainersNumber = maxContainersNumber;
        this.maxContainersWeight = maxContainersWeight;
    }

    public void addContainer(Container container)
    {
        containersWeight += container.getFullWeight();
        containersNumber += 1;
        if (maxContainersWeight < containersWeight || maxContainersNumber < containersNumber)
        {
              Console.WriteLine("Nie mozna dodac kontenera, zbyt duza ilosc konterów na statku bądź zbyt duża waga");
        }
        else
        {
            containers.Add(container);
        }
    }

    public void addContainerList(List<Container> containers)
    {
        double fullWeight = 0;
        double containersCount = 0;
        for (int i = 0; i < containers.Count; i++)
        {
            fullWeight += containers[i].getFullWeight();
            containersCount++;
        }

        if (fullWeight <= maxContainersWeight && containersCount <= maxContainersNumber)
        {
            this.containers = containers;
        }
        else
        {
            Console.WriteLine("Liczba kontenerów bądź ich waga jest zbyt duża");
        }
    }

    public void removeContainer()
    {
        int containerId = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj id kontenera, który chcesz usunąć");
        Console.WriteLine("Lista kontenerów:");
        displayContainers();

        if (containerId > containers.Count || containerId < 0)
        {
            Console.WriteLine("Niepoprawne id");
        }
        else
        {
            containers.RemoveAt(containerId);
            Console.WriteLine("Kontener usunieto pomyslnie");
        }
    }

    public void replaceContainer(Container container)
    {
        displayContainers();
        Console.WriteLine("Podaj nr seryjny kontenera który chcesz zastąpić");
        string input = Console.ReadLine();
        
        for (int i = 0; i < containers.Count; i++)
        {
            if (containers[i].getSerialNumber().Equals(input))
                containers[i] = container;
        }
        
        
    }

    public void moveContainerToAnotherShip(Ship ship)
    {
        displayContainers();
        Console.WriteLine("Podaj nr kontenera który chcesz przeniesc");
        int containerId = int.Parse(Console.ReadLine());
        if (containerId > containers.Count || containerId < 0)
        {
            Console.WriteLine("Nie ma takiego kontenera");
        }
        else
        {
            
            ship.addContainer(containers[containerId]);
            containers.RemoveAt(containerId);
            Console.WriteLine("Kontener pomyslnie przeniesiono");
        }
    }

    public void displayContainers()
    {
        for (int i = 0; i < containers.Count; i++)
        {
            Console.WriteLine(i + "." + containers[i].getSerialNumber());
        }
    }

    public override string ToString()
    {
        return "Kontenerowiec: "+ number+ "{ " + "maksymalna predkosc: " + maxSpeed + ", maksymalna liczba kontenerów: " +
               maxContainersNumber + ", maksymalna waga kontenerów: " + maxContainersWeight + "}";
    }
}