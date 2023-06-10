using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class RecyclableMatter
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public double Quantity { get; set; }
    }
}
