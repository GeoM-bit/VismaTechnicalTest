namespace VismaTechnicalTest.Models
{
    public class CustomerSelectionViewModel
    {
        public int SelectedCustomerId { get; set; }
        public List<Customer> Customers { get; set; } = new();
    }
}
