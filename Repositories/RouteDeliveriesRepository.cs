public class RouteDeliveriesRepository : IRouteDeliveriesRepository
{
     private readonly DeliflowDbContext _context;

    public RouteDeliveriesRepository(DeliflowDbContext context)
    {
        _context = context;
    }
    public async Task<RouteDeliveries> AddAsync(RouteDeliveries routesDelivery)
    {
        await _context.AddAsync(routesDelivery);
        _context.SaveChanges();

        return routesDelivery;
    }
}