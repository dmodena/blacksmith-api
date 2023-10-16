using BlacksmithAPI.Data;
using BlacksmithAPI.Models;
using BlacksmithAPI.Repositories;using BlacksmithAPI.Services;using Moq;namespace BlacksmithAPI.Tests.Services;

public class OrderServiceTests
{
    private Mock<ICustomerRepository> _customerRepositoryMock;
    private Mock<IMaterialRepository> _materialRepositoryMock;	private readonly OrderService _sut;    public OrderServiceTests()
	{
		_customerRepositoryMock = new Mock<ICustomerRepository>();
		_materialRepositoryMock = new Mock<IMaterialRepository>();

		_customerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))            .Returns((int id) => BlacksmithDatabase.Get<Customer>("customers", x => x.Id == id));
		_materialRepositoryMock.Setup(x => x.GetMaterialPriceModifier(It.IsAny<string>()))            .Returns((string id) => BlacksmithDatabase.Get<Material>("materials", x => x.Id == id).PriceModifier);

		_sut = new OrderService(_customerRepositoryMock.Object, _materialRepositoryMock.Object);
	}

	[Theory]
	[InlineData("Sword", "wood", 5)]    [InlineData("Sword", "bronze", 6)]    [InlineData("Sword", "iron", 11)]    [InlineData("Sword", "gold", 34)]    [InlineData("Spear", "wood", 15)]    [InlineData("Spear", "bronze", 19)]    [InlineData("Spear", "iron", 33)]    [InlineData("Spear", "gold", 102)]    [InlineData("Shield", "wood", 25)]    [InlineData("Shield", "bronze", 32)]    [InlineData("Shield", "iron", 55)]    [InlineData("Shield", "gold", 170)]    public void RequestOrder_CalculatesPrice(string itemType, string material, int expectedPrice)	{		var request = new OrderRequest { CustomerId = 1, ItemType = itemType, Material = material };		var result = _sut.RequestOrder(request);		Assert.Equal(expectedPrice, result.Price);	}
}
