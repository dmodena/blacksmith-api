namespace BlacksmithAPI.Models;

public class Customer
{
    public int Id { get; set; }

    public string Category { get; set; }

    public Customer(int id, string category)
    {
        Id = id;
        Category = category;
    }
}
