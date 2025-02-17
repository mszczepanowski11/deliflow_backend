public class CourierRepository: ICourierRepository
{
    private readonly DeliflowDbContext _context;

    public CourierRepository(DeliflowDbContext context)
    {
        _context = context;
    }

    public async Task<Courier?> GetAsync(int id)
    {
        return await Task.Run(() => _context.Couriers.Find(id));
    }

    public async Task<IQueryable<Courier>> GetMultipleAsync()
    {
        return await Task.Run(() => _context.Couriers);
    }
}