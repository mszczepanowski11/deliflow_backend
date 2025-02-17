public interface IRepositoryBase<T> where T : class
{
    Task<IQueryable<T>> GetMultipleAsync();
    
}