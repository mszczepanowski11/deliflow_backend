
public interface IRouteRepository
{
    Task<Route?> AddAsync(Route route);
    Task<Route?> GetAsync(int id);
}