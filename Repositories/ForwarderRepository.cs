public class ForwarderRepository : IForwarderRepository
{
    private readonly DeliflowDbContext _context;

    public ForwarderRepository(DeliflowDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Forwarder>> GetMultipleAsync()
    {
        return await Task.Run(() => _context.Forwarders);
    }

    public async Task<Forwarder?> GetAsyncByEmail(string email)
    {
         return await Task.Run(() => _context.Forwarders.FirstOrDefault(f => f.Email == email));
    }

    public async Task<Forwarder> AddAsync(Forwarder forwarder)
    {
        await _context.AddAsync(forwarder);
        _context.SaveChanges();
        
        return forwarder;
    }
}