public class CourierService : ICourierService
{
    private readonly ICourierRepository _couriers;
    public CourierService(ICourierRepository couriers){
       _couriers = couriers;
    }
    public async Task<IQueryable<Courier>> GetMultipleAsync()
    {
        return await _couriers.GetMultipleAsync();
    }
}