namespace DataExporter;

public class Product
{
    public int ProductID { get; set; } 
    public string Name { get; set; } 
    public decimal Price { get; set; }

    public static Product GetProduct(string[] parts)
    {
        return new Product()
        {
            ProductID = int.Parse(parts[1]),
            Name = parts[2],
            Price = decimal.Parse(parts[3]),
        };
    }

    public override string ToString() => $"Code: {ProductID}, Name: {Name}, Price: {Price:0.00}";
}
