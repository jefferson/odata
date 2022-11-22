using System.ComponentModel.DataAnnotations;

namespace App.Models;
public class Product
{
    [Key]
    public int ID { get; set; }
    public string? Name { get; set; }
}