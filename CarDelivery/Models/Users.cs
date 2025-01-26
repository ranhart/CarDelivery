using System;
using System.Collections.Generic;

namespace CarDelivery.Models;

public partial class Users
{
    public int Userid { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
