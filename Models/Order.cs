﻿using System;
using System.Collections.Generic;

namespace KCrafts.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
