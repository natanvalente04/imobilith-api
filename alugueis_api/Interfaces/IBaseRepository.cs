namespace alugueis_api.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity, T updatedEntity);
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
