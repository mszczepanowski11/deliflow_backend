public class ForwarderService : IForwarderService
{
    private readonly IForwarderRepository _forwarders;

    public ForwarderService(IForwarderRepository forwarders){
        _forwarders = forwarders;
    }
    public async Task<IQueryable<Forwarder>> GetMultipleAsync()
    {
        return await _forwarders.GetMultipleAsync();
    }
}