using Infrastructure.DBConfiguration.EFCore;
using Infrastructure.Interface.Interface;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DDDContext _context;
        public UnitOfWork(DDDContext context)
        {
            _context = context;
        }
        public IUserRepository Users => new UserRepository(_context);
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
