namespace DataExporter;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=DESKTOP-VCKBLPI\\SQLEXPRESS01; Database=NorthWind; Integrated Security=true; TrustServerCertificate=true";
        string filePath = @"D:\categoriesANDproducts.txt";

        IProductsDatabaseReader databaseReader = new ProductsDatabaseReader(connectionString);
        IProductsFileDataWriter fileWriter = new ProductsFileDataWriter();

        IEnumerable<Category> categories = databaseReader.GetCategories();
        IEnumerable<Product> products = databaseReader.GetProducts();

        fileWriter.WriteCategoriesAndProductsToFile(categories, products, filePath);


        foreach (var category in categories)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"CategoryID:{category.CategoryId}, CategoryName: {category.Name}, Description: {category.Description}");
            Console.ResetColor();

            foreach (var product in products)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ProductID:{product.ProductID}, Name: {product.Name}, Price: {product.Price}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        Console.WriteLine("Data exported successfully.");
    }
}