using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace CarDelivery.Models;

public partial class Orders
{
    public int Orderid { get; set; }

    public int Userid { get; set; }

    public int Carid { get; set; }

    public int Quantity { get; set; }

    [ValidateNever]
    public virtual Cars Cars { get; set; } = null!;

    [ValidateNever]
    public virtual Users Users { get; set; } = null!;
}
