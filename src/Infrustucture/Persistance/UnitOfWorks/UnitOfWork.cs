using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using Persistance.Context;
using Persistance.Repositories;
using System.Threading.Tasks;

namespace Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository ProductRepository { get; }
        public UnitOfWork(ApplicationDbContext context, IProductRepository productRepository)
        {
            _context = context;
            ProductRepository = productRepository;
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
        public async ValueTask DisposeAsync() { }
    }
}