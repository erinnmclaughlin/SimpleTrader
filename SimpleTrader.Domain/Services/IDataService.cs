namespace SimpleTrader.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(Guid id, T entity);
        Task<bool> Delete(Guid id);
    }
}
