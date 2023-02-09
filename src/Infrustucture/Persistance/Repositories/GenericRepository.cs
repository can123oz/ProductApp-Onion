using Application.Interfaces.Repository;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : BaseEntity, new()
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> Table { get => _dbContext.Set<T>(); }

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await Table.FindAsync(Id);
        }
    }
}
