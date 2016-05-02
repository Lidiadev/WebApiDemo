namespace API.Core.Dtos.Product
{
    using Entities;

    public class DetailProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DetailProductDto()
        {
        }

        public DetailProductDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
        }
    }
}