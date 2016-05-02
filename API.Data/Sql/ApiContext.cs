namespace API.Data.Sql
{
    using Core.Entities;
    using Interfaces;
    using System.Data.Entity;

    public class ApiContext : DbContext, IApiContext
    {
        public IDbSet<Product> Products { get; set; }

        public ApiContext()
           : base("DefaultConnection")
        {
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetDeleted(object entity)
        {
            Entry(entity).State = EntityState.Deleted;
        }
    }
}