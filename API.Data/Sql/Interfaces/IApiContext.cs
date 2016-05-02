namespace API.Data.Sql.Interfaces
{
    using Core.Entities;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    public interface IApiContext
    {
        IDbSet<Product> Products { get; set; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync();
        void SetModified(object entity);
        void SetDeleted(object entity);
        void Dispose();
    }
}