using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IA { get; set; }
        public ActivityType ActivityType { get; set; }
    }
    public enum ActivityType
    {
        Enterprice = 0,
        induvdules = 1
    }
}
