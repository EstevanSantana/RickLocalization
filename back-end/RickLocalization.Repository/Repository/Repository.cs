using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RickLocalization.Repository
{
    public class Repository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(T item)
        {
            _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T item)
        {
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> item)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(item);
        }

        public async Task Update(T item)
        {
            _context.Entry(item).State = EntityState.Added;
            _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
        }
    }
}
