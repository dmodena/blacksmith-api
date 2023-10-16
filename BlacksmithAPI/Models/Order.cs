namespace BlacksmithAPI.Models;

public class Order 
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public DateTime DeliveryDate { get; set; }
}
