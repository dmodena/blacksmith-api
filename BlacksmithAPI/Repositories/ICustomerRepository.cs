using BlacksmithAPI.Models;namespace BlacksmithAPI.Repositories
{
	public interface ICustomerRepository	{
		public Customer GetById(int id);	}
}
