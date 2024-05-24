namespace DataExporter;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; }

    public static Category GetCategory(string[] parts)
    {
        return new Category()
        {
            Name = parts[0],
            Description = parts[1]
        };
    }

    public override string ToString() => $"Name: {Name}, IsActive {Description}";
}
