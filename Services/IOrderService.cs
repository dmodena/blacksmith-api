﻿using BlacksmithAPI.Models;

public interface IOrderService
{
	public Order RequestOrder(OrderRequest request);