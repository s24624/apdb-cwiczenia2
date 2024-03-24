namespace ConsoleApp3.Model
{
    public class RefrigeratedContainer : Container
    {
        private Dictionary<int, Dictionary<string, double>> listOfProducts =
            new Dictionary<int, Dictionary<string, double>>();

        private Dictionary<string, double> productsAtContainer = new Dictionary<string, double>();
        private double temperature;
        private double productTemperature;
        private bool isFirstProductAdded = false;
        private double firstProductTemperature;

        public RefrigeratedContainer(double height, double ownWeight, double maxLoadWeight,
            double depth, double temperature) : base(height, ownWeight, maxLoadWeight, depth)
        {
            this.temperature = temperature;
            listOfProducts.Add(0, Product.GetProductAsDictionary("Banany", 13.3));
            listOfProducts.Add(1, Product.GetProductAsDictionary("Ryby", 2));
            listOfProducts.Add(2, Product.GetProductAsDictionary("Jajka", 19));
            listOfProducts.Add(3, Product.GetProductAsDictionary("Nabiał", 5));
            listOfProducts.Add(4, Product.GetProductAsDictionary("Pomidory", 13.3));
            showProductList();
            createSerialNumber("C");
        }

        public override void emptyCargo()
        {
            setCargoWeight(0);
            productsAtContainer = new Dictionary<string, double>();
        }

        public override void loadCargo(double weight)
        {
            Console.WriteLine("Podaj id produktu, który chcesz dodać");
            int productId = int.Parse(Console.ReadLine());
            getProductTemperature(productId);
            if (getCargoWeight() + weight > getMaxLoadWeight())
            {
                try
                {
                    throw new OverfillException();
                }
                catch (OverfillException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (temperature < productTemperature)
            {
                Console.WriteLine(
                    "Temperatura kontenera jest zbyt niska dla wymaganej temperatury przez ten produkt \n" +
                    "Temperatura w kontenerze: " + temperature + "\n" + "Temperatura wymagana dla produktu: " +
                    productTemperature);
            }
            else if (isFirstProductAdded && productTemperature != firstProductTemperature)
            {
                Console.WriteLine("Kontener może przechowywać produkty, które mają tę samą temperaturę przewożenia");
            }
            else
            {
                if (!isFirstProductAdded)
                {
                    firstProductTemperature = productTemperature;
                    isFirstProductAdded = true;
                }

                addProductAtContainer(productId);
            }

            setCargoWeight(weight);
        }

        protected void showProductList()
        {
            Console.WriteLine("Dostępne produkty");
            foreach (var kvp in listOfProducts)
            {
                Console.WriteLine($"Nr produktu: {kvp.Key}");
                foreach (var innerKvp in kvp.Value)
                {
                    Console.WriteLine($"  Nazwa: {innerKvp.Key}, Temperatura: {innerKvp.Value}");
                }

                Console.WriteLine();
            }
        }

        protected void addProductAtContainer(int id)
        {
            int productId = id;
            if (listOfProducts.ContainsKey(productId))
            {
                Dictionary<string, double> products = listOfProducts[productId];
                foreach (var kvp in products)
                {
                    productsAtContainer.Add(kvp.Key, kvp.Value);
                }
            }
            else
            {
                Console.WriteLine("Nie znaleziono produktu o podanym numerze na liście.");
            }
        }

        public void showProductsAtTheContainer()
        {
            Console.WriteLine("Produkty w kontenerze:");
            foreach (var kvp in productsAtContainer)
            {
                Console.WriteLine($"  Nazwa: {kvp.Key}, Temperatura: {kvp.Value}");
            }
        }

        protected void getProductTemperature(int id)
        {

            if (listOfProducts.ContainsKey(id))
            {
                Dictionary<string, double> product = listOfProducts[id];
                foreach (var kvp in product)
                {
                    productTemperature = kvp.Value;
                }

                Console.WriteLine(productTemperature);
            }
            else
            {
                Console.WriteLine("Produkt o podanym identyfikatorze nie istnieje.");
            }
        }
        public override string ToString()
        {
            return "Refrigerated Container";
        }
    }
}

