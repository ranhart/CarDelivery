using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDelivery.Models;

public partial class Complectations
{
    [Key]
    public int Complectationid { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Equipment { get; set; } = null!;
    [Required]
    public string Engine { get; set; } = null!;

    public ICollection<Cars> Cars { get; set; } = new List<Cars>();
}
