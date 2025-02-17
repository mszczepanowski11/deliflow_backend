

public class RouteService : IRouteService
{
    private readonly IRouteRepository _routes;
    private readonly ICourierRepository _couriers;
    private readonly IDeliveryRepository _deliveries;
    private readonly IRouteDeliveriesRepository _routeDeliveries;

    public RouteService(IRouteRepository routes, ICourierRepository couriers, IDeliveryRepository deliveries, IRouteDeliveriesRepository routeDeliveries)
    {
        _routes = routes;
        _couriers = couriers;
        _deliveries = deliveries;
        _routeDeliveries = routeDeliveries;
    }

    public async Task<bool> Calculate(int courierId, string date)
    {
        var courier = await _couriers.GetAsync(courierId);

        var routeCreated = new Route()
        {
            Courier = courier,
            timeCreated = DateTime.Now,
            deliveryDate = DateOnly.Parse(date)
        };

        Route route = await _routes.AddAsync(routeCreated);

        if (route == null)
        {
            return false;
        }


        var deliveries = await _deliveries.GetMultipleAsync(courierId, date);
        var count = 0;

        foreach (var delivery in deliveries)
        {
            var routeDelivery = new RouteDeliveries()
            {
                Delivery = delivery,
                Route = route,
                timeEstimated = DateTime.Now,
                Order = count++,
                Status = false
            };

            await _routeDeliveries.AddAsync(routeDelivery);
        }


        return true;
    }
}