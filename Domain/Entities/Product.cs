using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ComercialName { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Form { get; set; }
        public int Volume { get; set; }
        public float Rating { get; set; }
        public byte[] Picture { get; set; }
    }
}
