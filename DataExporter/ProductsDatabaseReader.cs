using Microsoft.Data.SqlClient;

namespace DataExporter;

public interface IProductsDatabaseReader
{
    IEnumerable<Product> GetProducts();
    IEnumerable<Category> GetCategories();
}

public class ProductsDatabaseReader : IProductsDatabaseReader
{
    private readonly string _connectionString;

    public ProductsDatabaseReader(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Category> GetCategories()
    {
        List<Category> categories = new List<Category>();
        string query = "Select CategoryID, CategoryName, Description from Categories";

        using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
        {
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            CategoryId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2)
                        };

                        categories.Add(category);
                    }

                    reader.Close();
                }

                catch (Exception ex)
                {
                    throw new ArgumentException($"Error occurred while reading categories: {ex.Message}");
                }
            }
        }

        return categories;
    }

    public IEnumerable<Product> GetProducts()
    {
        List<Product> products = new List<Product>();

        string query = "SELECT ProductID, ProductName, UnitPrice FROM Products";

        using SqlConnection sqlConnection = new SqlConnection(_connectionString);
        using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

        try
        {
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product
                {
                    ProductID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal(2)
                };

                products.Add(product);
            }

            reader.Close();
        }

        catch (Exception ex)
        {
            throw new ArgumentException($"You have some error in your code: {ex.Message}");
        }

        finally { sqlConnection.Close(); };

        return products;
    }
}