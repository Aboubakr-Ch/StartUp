namespace Domain.Entities
{
    public class Command : BaseEntity
    {
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public int ClientId { get; set; }
        public FacturationType FacturationType { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<CommandItem> CommandItems { get; set; } = new List<CommandItem>();
    }
    public enum FacturationType
    {
        Cash = 0,
        Check = 1,
        CartBunqueir = 2
    }
}
