namespace ShopManagerMini.Models
{
    /// <summary>
    /// Lớp đại diện cho khách hàng
    /// </summary>
    public class Customer
    {
        public string CustomerId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CustomerType { get; set; } = string.Empty;

        public Customer() { }

        public Customer(string customerId, string fullName, string phone, string customerType)
        {
            CustomerId = customerId;
            FullName = fullName;
            Phone = phone;
            CustomerType = customerType;
        }
    }
}
