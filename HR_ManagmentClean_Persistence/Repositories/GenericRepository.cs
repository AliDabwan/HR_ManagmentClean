﻿using HR_ManagmentClean.Application.Contracts.Persistence;
using HR_ManagmentClean.Domin.Common;
using HR_ManagmentClean_Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_ManagmentClean_Persistence.Repositories
{
    public class GenericRepository<T> :IGenericRepository<T> where T : BaseEntity
    {
        protected readonly HrDatabaseContext _context;

        public GenericRepository(HrDatabaseContext context)
        {
            this._context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
         await   _context.AddAsync(entity);
           await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
           _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q=>q.Id==id);
        }

      

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
