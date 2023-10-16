﻿using BlacksmithAPI.Models;

public class OrderService : IOrderService
{
    private ICustomerRepository _customerRepository;
    private IMaterialRepository _materialRepository;

    public OrderService(ICustomerRepository customerRepository, IMaterialRepository materialRepository)

	public Order RequestOrder(OrderRequest request)
        Customer customer = _customerRepository.GetById(request.CustomerId);

        // Check inventory
        float materialModifier = _materialRepository.GetMaterialPriceModifier(request.Material);
        if (request.ItemType == "Sword")
        {
            price = 5 * (int)materialModifier;
        }
        else if (request.ItemType == "Spear")
        {
            price = 15 * (int)materialModifier;
        }
        else if (request.ItemType == "Shield")
        {
            price = 25 * (int)materialModifier;
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
        }
        {
            deliveryDate = deliveryDate.AddDays(-2);
        }


        // Premium customers have quicker delivery and an 10% discount
        if (customer.Category == "Premium")
        {
            deliveryDate = deliveryDate.AddDays(-2);
            price = (int)(price * 0.9);
        }

        return new Order()
        {
            Id = 1,
            Price = price,
            DeliveryDate = deliveryDate
        };
}