
public interface IDeliveryRepository
{
    Task<Delivery> AddAsync(Delivery delivery);
    Task<IQueryable<Delivery>> GetMultipleAsync(int? courierId,string? dateOfDelivery);
}