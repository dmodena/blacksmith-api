﻿using BlacksmithAPI.Data;
using BlacksmithAPI.Models;
using BlacksmithAPI.Repositories;

public class OrderServiceTests
{
    private Mock<ICustomerRepository> _customerRepositoryMock;
    private Mock<IMaterialRepository> _materialRepositoryMock;
	{
		_customerRepositoryMock = new Mock<ICustomerRepository>();
		_materialRepositoryMock = new Mock<IMaterialRepository>();

		_customerRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
		_materialRepositoryMock.Setup(x => x.GetMaterialPriceModifier(It.IsAny<string>()))

		_sut = new OrderService(_customerRepositoryMock.Object, _materialRepositoryMock.Object);
	}

	[Theory]
	[InlineData("Sword", "wood", 5)]
}