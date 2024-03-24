using ConsoleApp3.Model;

bool stan = true;
List<Ship> kontenerowce = new List<Ship>();
List<Container> kontenery = new List<Container>();
while (stan)
{
   
    if (kontenerowce.Count == 0)
    {   Console.WriteLine("Wybierz opcje");
        Console.WriteLine("1.Dodaj Kontenerowiec");
        
        int enter = int.Parse(Console.ReadLine());
       
        if (enter == 1)
        {
            display();
            Console.WriteLine("Podaj maksymalna predkosc dla kontenerowca");
            int maxSpeed = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj maksymalna ilosc kontenerow dla kontenerowca");
            int maxNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj maksymalna wage kontenerow dla kontenerowca");
            int maxWeight = int.Parse(Console.ReadLine());
            Ship ship = new Ship(maxSpeed, maxNumber, maxWeight);
            kontenerowce.Add(ship);
        }
    }
    Console.WriteLine("Wybierz opcje");
    Console.WriteLine("1.Dodaj Kontenerowiec");
    Console.WriteLine("2.Usun Kontenerowiec");
    Console.WriteLine("3.Dodaj Kontener");
    Console.WriteLine("4.Dodaj kontener na statek");
    Console.WriteLine("5.Usun kontener ze statku");
    Console.WriteLine("6.Zastąp Kontener");
    Console.WriteLine("7.Przenies kontener na inny statek");
    Console.WriteLine("8.Zaladuj kontener");
    Console.WriteLine("9.Opróżnij kontener");
    Console.WriteLine("10.Wyswietl kontenery dla danego statku");
    Console.WriteLine("120.Zakoncz program");
    
     int input = int.Parse(Console.ReadLine());
    if (kontenerowce.Count > 0)
    {
        display();
        if (input == 1)
        {
            Console.WriteLine("Podaj maksymalna predkosc dla kontenerowca");
            int maxSpeed = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj maksymalna ilosc kontenerow dla kontenerowca");
            int maxNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj maksymalna wage kontenerow dla kontenerowca");
            int maxWeight = int.Parse(Console.ReadLine());
            Ship ship = new Ship(maxSpeed, maxNumber, maxWeight);
            kontenerowce.Add(ship);
        }else if (input == 2)
        {
            Console.WriteLine("Podaj nr kontenerowca do usuniecia");
            int delete = int.Parse(Console.ReadLine());
            for (int i = 0; i < kontenerowce.Count; i++)
            {
                Console.WriteLine(i + " " +kontenerowce[i]);
            }
            kontenerowce.RemoveAt(delete);
            
        }else if (input == 3)
        {
            Console.WriteLine("Podaj nr typu kontenera, który chcesz utworzyć");
            Console.WriteLine("1.Gazowy");
            Console.WriteLine("2.Na płyny");
            Console.WriteLine("3.Chłodniczy");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                Console.WriteLine("Podaj wysokosc");
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj wage");
                double weight = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj maksymalna wage ladunku");
                double maxWeight = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj glebokosc");
                double depth = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj cisnienie");
                double pressure = double.Parse(Console.ReadLine());
                GassContainer gassContainer = new GassContainer(
                    height, weight, maxWeight, depth, pressure);
                kontenery.Add(gassContainer);
            }else if (option == 2)
            {
                Console.WriteLine("Podaj wysokosc");
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj wage");
                double weight = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj maksymalna wage ladunku");
                double maxWeight = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj glebokosc");
                double depth = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj true albo false w zaleznosci czy przewozi bezpieczny ladunek");
                bool isSafe = bool.Parse(Console.ReadLine());
                LiquidContainer liquidContainer = new LiquidContainer(
                    height, weight, maxWeight, depth, isSafe);
                kontenery.Add(liquidContainer);
            }else if (option == 3)
            {
                Console.WriteLine("Podaj wysokosc");
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj wage");
                double weight = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj maksymalna wage ladunku");
                double maxWeight = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj glebokosc");
                double depth = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj temperature");
                double temperature = double.Parse(Console.ReadLine());
                RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(
                    height, weight, maxWeight, depth, temperature);
                kontenery.Add(refrigeratedContainer);
            }
        }else if (input == 4)
        {
            Console.Write("Podaj indeks statku, na który chcesz dodać kontener");
            int shipNumber = int.Parse(Console.ReadLine());
            Console.Write("Podaj nr kontenera, który chcesz dodać");
            int containerNumber = int.Parse(Console.ReadLine());
                 
            kontenerowce[shipNumber].addContainer(kontenery[containerNumber]);
                
        }else if (input == 5)
        {
            Console.Write("Podaj indeks statku, z którego chcesz usunąć kontener");
            int shipNumber = int.Parse(Console.ReadLine());
            kontenerowce[shipNumber].removeContainer();
        }
        else if (input == 6)
        {
            Console.Write("Podaj indeks statku, na ktorym chcesz zastapic kontener");
            int shipNumber = int.Parse(Console.ReadLine());
            Console.Write("Podaj nr kontenera, który chcesz wstawić na statek zamiast innego");
            int containerNumber = int.Parse(Console.ReadLine());
            kontenerowce[shipNumber].replaceContainer(kontenery[containerNumber]);
        }
        else if(input == 7)
        {
            Console.Write("Podaj indeks statku, z którego chcesz przeniesc ładunek");
            int shipNumber = int.Parse(Console.ReadLine());
            Console.Write("Podaj nr statku, na ktory chcesz przeniesc ładunek");
            int shipNumber2 = int.Parse(Console.ReadLine());
            
            kontenerowce[shipNumber].moveContainerToAnotherShip(kontenerowce[shipNumber2]);
        }else if (input == 8)
        {
            for (int i = 0; i < kontenery.Count; i++)
            {
                Console.WriteLine(i +"."+kontenery[i]);
            }
            Console.WriteLine("Podaj indeks kontenera do, którego chcesz załadować towar");
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wage towaru");
            double weight = double.Parse(Console.ReadLine());
            kontenery[option].loadCargo(weight);
        }
        else if (input == 9)
        {
            for (int i = 0; i < kontenery.Count; i++)
            {
                Console.WriteLine(i +"."+kontenery[i]);
            }
            Console.WriteLine("Podaj indeks kontenera, który chcesz opróżnic");
            int option = int.Parse(Console.ReadLine());
            kontenery[option].emptyCargo();
        }
        else if (input == 10)
        {
            Console.WriteLine("Podaj indeks statku dla ktorego chcesz wyswietlic liste kontenerow");
            int number = int.Parse(Console.ReadLine());
            kontenerowce[number].displayContainers();
        }
        else if(input == 120)
        {
            stan = false;
        }
    }
    

    
}
void display()
{
    Console.WriteLine("============================================");
    Console.WriteLine("Lista kontenerowców: ");
    if(kontenerowce.Count==0)
        Console.WriteLine("Brak");
    for (int i = 0; i < kontenerowce.Count; i++)
    {
        Console.WriteLine(i+"." +kontenerowce[i]);
    }
    Console.WriteLine("Lista kontenerów: ");
    if(kontenery.Count==0)
        Console.WriteLine("Brak");
    for (int i = 0; i < kontenery.Count; i++)
    {
        Console.WriteLine(i +"." +kontenery[i]);
    }
    Console.WriteLine("============================================");
}