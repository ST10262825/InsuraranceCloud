using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KCrafts.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int OrderId { get; set; }

    public DateTime TransactionDate { get; set; }

    public virtual Order Order { get; set; } = null!;

    [Required]
    [Display(Name = "Card Holder Name")]
    public string CardHolderName { get; set; }

    [Required]
    [Display(Name = "Card Number")]
    public string CardNumber { get; set; }

    [Required]
    [Display(Name = "Expiration Month")]
    public int ExpirationMonth { get; set; }

    [Required]
    [Display(Name = "Expiration Year")]
    public int ExpirationYear { get; set; }

    [Required]
    [Display(Name = "CVV")]
    public string CVV { get; set; }
}
