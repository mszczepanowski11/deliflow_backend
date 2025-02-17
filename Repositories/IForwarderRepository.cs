
public interface IForwarderRepository : IRepositoryBase<Forwarder>
{
    Task<Forwarder?> GetAsyncByEmail(string email);
    Task<Forwarder> AddAsync(Forwarder forwarder);
}