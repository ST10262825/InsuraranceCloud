using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace KCrafts.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
    public string UserId { get; set; }
   
    public IdentityUser User { get; set; }
}
