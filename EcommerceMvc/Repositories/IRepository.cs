namespace EcommerceMvc.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id, QueryOptions<T> options);
    Task AddAsync(T entity);
    Task DeleteById(int id);
}
