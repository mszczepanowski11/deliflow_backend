using DeliflowRequests;

public class DeliveryService : IDeliveryService
{
    private readonly IDeliveryRepository _deliveries;
    private readonly ICourierRepository _couriers;
    public DeliveryService(IDeliveryRepository deliveries, ICourierRepository couriers){
        _deliveries = deliveries;
        _couriers = couriers;
    }
    public async Task<IQueryable<Delivery>> GetMultipleAsync(int? courierId, string? dateOfDelivery)
    {
        return await _deliveries.GetMultipleAsync(courierId,dateOfDelivery); 
    }

    public async Task<Delivery> AddAsync(DeliveryRequest delivery)
    {

        var deliveryCreated = new Delivery()
        {
            Name = delivery.Name,
            City = delivery.City,
            PostalCode = delivery.PostalCode ,
            Address = delivery.Address ,
            DateOfDelivery = DateOnly.Parse(delivery.DateOfDelivery),
        };

        var courier = await _couriers.GetAsync(delivery.CourierId);

        deliveryCreated.Courier = courier;

        return await _deliveries.AddAsync(deliveryCreated);
    }

}

