using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odata_hello_world.App.Models;

namespace odata_hello_world.App.Controllers;

public class MovieLinkController : ODataController
{
    private readonly OdatadbContext dbContext;

    public MovieLinkController(OdatadbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [EnableQuery(PageSize = 10)]
    public IQueryable<MovieLink> Get()
    {
        return this.dbContext.MovieLinks;
    }

    [EnableQuery]
    public IActionResult Get(string key)
    {
        return Ok(this.dbContext.MovieLinks.FirstOrDefault( c => c.Key == key));
    }
}
