using BlacksmithAPI.Data;
using BlacksmithAPI.Models;namespace BlacksmithAPI.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public Customer GetById(int id)
    {
        return BlacksmithDatabase.Get<Customer>("customers", x => x.Id == id);
    }
}
