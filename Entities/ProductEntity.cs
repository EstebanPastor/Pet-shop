using System.ComponentModel.DataAnnotations;

namespace pet_shop_api.Entities
{
    public class ProductEntity
    {
        [Key]
        public long Id { get; set; }
        
        public string Brand { get; set; }

        public String Title { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
