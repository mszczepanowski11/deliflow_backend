using Microsoft.EntityFrameworkCore;
public class DeliveryRepository: IDeliveryRepository
{
    private readonly DeliflowDbContext _context;

    public DeliveryRepository(DeliflowDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Delivery>> GetMultipleAsync(int? courierId,string? dateOfDelivery)
    {
        IQueryable<Delivery> query = _context.Deliveries.Include(d => d.Courier).AsQueryable();
        
        if(courierId.HasValue){
           query = query.Where(d => d.Courier.Id == courierId);
        }

        if(dateOfDelivery != null){
            query = query.Where(d => d.DateOfDelivery == DateOnly.Parse(dateOfDelivery));
        }

        return query;
    }

    public async Task<Delivery> AddAsync(Delivery delivery)
    {
        await _context.AddAsync(delivery);
        _context.SaveChanges();

        return delivery;
    }
}