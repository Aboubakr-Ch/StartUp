using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifierId { get; set; }
        public virtual User? Modifier { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
