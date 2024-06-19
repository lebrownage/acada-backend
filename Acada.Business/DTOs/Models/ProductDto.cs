namespace Acada.Business.DTOs.Models
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public float Price { get; set; }
    }
}
