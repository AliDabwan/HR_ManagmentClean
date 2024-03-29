﻿using HR_ManagmentClean.Domin.Common;

namespace HR_ManagmentClean.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAsync();
        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity); 
        Task DeleteAsync(T entity);
        
     
    }

}