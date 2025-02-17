

public class RouteRepository : IRouteRepository
{
    private readonly DeliflowDbContext _context;
    public RouteRepository(DeliflowDbContext context)
    {
        _context = context;
    }
    public async Task<Route?> GetAsync(int id)
    {
        return await Task.Run(() => _context.Routes.Find(id));
    }

    public async Task<Route> AddAsync(Route route)
    {
        await _context.AddAsync(route);
        _context.SaveChanges();

        return route;
    }
}