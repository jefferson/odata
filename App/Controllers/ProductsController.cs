using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using App.Models;

namespace App.Controllers;

public class ProductsController : ODataController
{
    private List<Product> products = new List<Product>()
    {
        new Product()
        {
            ID = 1,
            Name = "Bread",
        },
            new Product()
        {
            ID = 2,
            Name = "Jeff",
        }
    };

    [EnableQuery]
    public List<Product> Get()
    {
        return products;
    }

    [EnableQuery]
    public IActionResult Get(int key)
    {
        return Ok(products.FirstOrDefault(c => c.ID == key));
    }
}
