using Azure.Identity;
using Microsoft.AspNetCore.Mvc;

public class RouteController: ControllerBase
{
    public readonly IRouteService _routes;
    public readonly ICourierService _couriers;

    public RouteController(IRouteService routes,ICourierService couriers)
    {
        _routes = routes;
        _couriers = couriers;
    }

    [HttpPost("routes/calculate")]
    public async Task<bool> Calculate(int courierId, string date)
    {   

        return await _routes.Calculate(courierId,date);
    } 

    [HttpGet("routes/getlatest")]
    public async Task<Route> GetLatest(int courierId, string date)
    {
        return new Route();
    }
}