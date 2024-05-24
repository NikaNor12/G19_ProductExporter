namespace DataExporter;

public interface IProductsFileDataWriter
{
    void WriteCategoriesAndProductsToFile(IEnumerable<Category> categories, IEnumerable<Product> products, string filePath);
}

public class ProductsFileDataWriter : IProductsFileDataWriter
{
    public void WriteCategoriesAndProductsToFile(IEnumerable<Category> categories, IEnumerable<Product> products, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var category in categories)
            {
                writer.WriteLine($"CategoryID:{category.CategoryId} CategoryName: {category.Name}, Description: {category.Description}");

                foreach (var product in products)
                {
                    writer.WriteLine($"ProductID:{product.ProductID}");
                    writer.WriteLine($"Name:{product.Name}");
                    writer.WriteLine($"Price:{product.Price}");
                }

                writer.WriteLine();
            }
        }
    }
}