public interface ICourierRepository : IRepositoryBase<Courier>
{
     Task<Courier?> GetAsync(int id);
}