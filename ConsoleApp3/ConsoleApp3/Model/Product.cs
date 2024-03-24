namespace ConsoleApp3.Model;

public class Product
{ 
    public static Dictionary<string, double> GetProductAsDictionary(string name,double weight)
    {
        Dictionary<string, double> product = new Dictionary<string, double>();
        product.Add(name,weight);
        return product;
    }
}