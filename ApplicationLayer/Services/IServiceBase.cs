public interface IServiceBase<T> where T : class
{
    Task<IQueryable<T>> GetMultipleAsync();
}