namespace API.Data.Repository.Interfaces
{
    using Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    interface IProductRepository
    {
        Task<IList<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task<bool> InsertAsync(Product entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Product entityToDelete);
        Task<bool> UpdateAsync(Product entityToUpdate);
    }
}