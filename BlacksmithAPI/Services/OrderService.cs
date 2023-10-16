using BlacksmithAPI.Models;using BlacksmithAPI.Repositories;namespace BlacksmithAPI.Services;

public class OrderService : IOrderService
{
    private ICustomerRepository _customerRepository;
    private IMaterialRepository _materialRepository;

    public OrderService(ICustomerRepository customerRepository, IMaterialRepository materialRepository)    {        _customerRepository = customerRepository;        _materialRepository = materialRepository;    }

	public Order RequestOrder(OrderRequest request)	{        // Check client
        Customer customer = _customerRepository.GetById(request.CustomerId);

        // Check inventory
        float materialModifier = _materialRepository.GetMaterialPriceModifier(request.Material);        // Calculate price        decimal price = 0;
        if (request.ItemType == "Sword")
        {
            price = 5 * (decimal)materialModifier;
        }
        else if (request.ItemType == "Spear")
        {
            price = 15 * (decimal)materialModifier;
        }
        else if (request.ItemType == "Shield")
        {
            price = 25 * (decimal)materialModifier;
        }

        // Calculate delivery date
        DateTime deliveryDate = DateTime.Now.AddDays(2);
        if (request.ItemType == "Sword")
        {
            deliveryDate = deliveryDate.AddDays(1);
        }
        else if (request.ItemType == "Spear")
        {
            deliveryDate = deliveryDate.AddDays(2);
        }
        else if (request.ItemType == "Shield")
        {
            deliveryDate = deliveryDate.AddDays(3);
        }        // Express customers have quicker delivery        if (customer.Category == "Express")
        {
            deliveryDate = deliveryDate.AddDays(-2);
        }


        // Premium customers have quicker delivery and an 10% discount
        if (customer.Category == "Premium")
        {
            deliveryDate = deliveryDate.AddDays(-2);
            price = price * 0.9m;
        }

        return new Order()
        {
            Id = 1,
            Price = decimal.Round(price, 2),
            DeliveryDate = deliveryDate
        };    }
}
