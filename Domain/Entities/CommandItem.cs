namespace Domain.Entities
{
    public class CommandItem : BaseEntity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public double ItemPrice { get; set; }
    }
}
