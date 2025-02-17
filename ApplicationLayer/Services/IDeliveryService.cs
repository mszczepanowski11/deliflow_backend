using DeliflowRequests;

public interface IDeliveryService
{
     Task<Delivery> AddAsync(DeliveryRequest delivery);
     Task<IQueryable<Delivery>> GetMultipleAsync(int? courierId,string? dateOfDelivery);
}