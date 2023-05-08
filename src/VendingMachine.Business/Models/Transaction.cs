namespace VendingMachine.Business.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public List<Product> Products{ get; set; }
        public decimal AmountPaid { get; set; }
    }
}