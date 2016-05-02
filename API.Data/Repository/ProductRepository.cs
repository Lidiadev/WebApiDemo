namespace API.Data.Repository
{
    using Sql.Interfaces;
    using Core.Entities;
    using Interfaces;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Sql;

    public class ProductRepository : IProductRepository
    {
        internal IApiContext _context;

        public ProductRepository()
            : this(new ApiContext())
        {
        }

        public ProductRepository(IApiContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(Product entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Products.Attach(entityToDelete);
            }
            _context.Products.Remove(entityToDelete);

            return await _context.SaveChangesAsync() != 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Product entityToDelete = _context.Products.Find(id);
            return await DeleteAsync(entityToDelete);
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> InsertAsync(Product entity)
        {
            _context.Products.Add(entity);
            return (await _context.SaveChangesAsync()) != 0;
        }

        public async Task<bool> UpdateAsync(Product entityToUpdate)
        {
            _context.Products.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;

            return await _context.SaveChangesAsync() != 0;
        }
    }
}