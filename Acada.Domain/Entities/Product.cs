using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Acada.Domain.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name", TypeName = "nvarchar(300)")]
        [Required]
        public string Name { get; set; } = "";

        [Column("description", TypeName = "nvarchar(2000)")]
        [Required]
        public string Description { get; set; } = "";

        [Column("price", TypeName = "decimal(18,2)")]
        [Required]
        public float Price { get; set; } 

    }
}
