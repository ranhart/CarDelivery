using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDelivery.Models;

public partial class Cars
{
    [Key]
    public int Carid { get; set; }
    [Required]
    public string Make { get; set; } = null!;
    [Required]
    public string Model { get; set; } = null!;
    [Required]
    public int Complectationid { get; set; }
    [Required]
    public int Price { get; set; }

    [ForeignKey("Complectationid")]
    [NotMapped]
    [ValidateNever]
    public virtual Complectations Complectations { get; set; }

    public ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
