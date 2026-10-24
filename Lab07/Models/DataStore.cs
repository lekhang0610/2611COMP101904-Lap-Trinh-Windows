using System.Collections.Generic;
using System.ComponentModel;

namespace ShopManagerMini.Models
{
    /// <summary>
    /// Lưu trữ dữ liệu trong bộ nhớ (In-memory DataStore) dùng chung cho ứng dụng
    /// </summary>
    public static class DataStore
    {
        // Danh sách tài khoản người dùng theo yêu cầu bài lab
        public static List<User> Users { get; set; } = new List<User>
        {
            new User("admin", "123", "Quản trị viên", "Admin"),
            new User("user", "123", "Nhân viên bán hàng", "User")
        };

        // Danh sách sản phẩm mẫu
        public static BindingList<Product> Products { get; set; } = new BindingList<Product>
        {
            new Product("SP001", "Bánh mì sandwich", "Thực phẩm", 15000, 50),
            new Product("SP002", "Nước ngọt Coca Cola 330ml", "Đồ uống", 10000, 100),
            new Product("SP003", "Sữa tươi Vinamilk 180ml", "Đồ uống", 8500, 80),
            new Product("SP004", "Khăn ướt Bobby 80 miếng", "Gia dụng", 32000, 45),
            new Product("SP005", "Snack khoai tây Oishi", "Bánh kẹo", 12000, 60)
        };

        // Danh sách khách hàng mẫu
        public static BindingList<Customer> Customers { get; set; } = new BindingList<Customer>
        {
            new Customer("KH001", "Nguyễn Văn An", "0901234567", "VIP"),
            new Customer("KH002", "Trần Thị Bình", "0912345678", "Thân thiết"),
            new Customer("KH003", "Lê Hoàng Cường", "0987654321", "Thường"),
            new Customer("KH004", "Phạm Thu Dung", "0934567890", "VIP")
        };
    }
}
