namespace HR_ManagmentClean.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByNameAsync(string name);

        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity); 
        Task DeleteAsync(T entity);
        
     
    }

}