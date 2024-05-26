﻿using System;
using System.Collections.Generic;

namespace KCrafts.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
    public int TransactionId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
public class OrderSummaryViewModel
{
    public Transaction Transaction { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}