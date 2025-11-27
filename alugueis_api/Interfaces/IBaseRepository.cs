namespace alugueis_api.Interfaces
{
    public interface IBaseRepository<T>
    {
        void AddAsync(T entity);
        void RemoveAsync(T entity);
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
