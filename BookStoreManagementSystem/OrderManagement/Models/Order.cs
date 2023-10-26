namespace OrderManagement.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerUserId { get; set; }
        public int BookId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
