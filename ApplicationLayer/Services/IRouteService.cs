public interface IRouteService
{
    
    Task<bool> Calculate(int courierId, string date);
    
}