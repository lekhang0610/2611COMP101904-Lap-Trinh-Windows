using System.Globalization;

namespace ProductManager;

public class Program
{
    private static readonly ProductService service = new();

    public static void Main()
    {
        service.ProductAdded += p => Console.WriteLine($">> Da them san pham: {p.MaSP} - {p.TenSP}");
        service.ProductRemoved += p => Console.WriteLine($">> Da xoa san pham: {p.MaSP} - {p.TenSP}");

        bool running = true;
        while (running)
        {
            PrintMenu();
            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice.Trim())
                {
                    case "1": AddProduct(); break;
                    case "2": PrintAll(); break;
                    case "3": FindByCode(); break;
                    case "4": FindByName(); break;
                    case "5": FilterByPriceRange(); break;
                    case "6": RemoveProduct(); break;
                    case "7": PrintTotalValue(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Lua chon khong hop le."); break;
                }
            }
            catch (DuplicateProductException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Loi du lieu: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi khong xac dinh: {ex.Message}");
            }

            Console.WriteLine();
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine("===== PRODUCT MANAGER =====");
        Console.WriteLine("1. Them san pham");
        Console.WriteLine("2. Xuat danh sach");
        Console.WriteLine("3. Tim theo ma");
        Console.WriteLine("4. Tim theo ten");
        Console.WriteLine("5. Loc theo khoang gia");
        Console.WriteLine("6. Xoa san pham");
        Console.WriteLine("7. Tinh tong gia tri kho");
        Console.WriteLine("0. Thoat");
        Console.Write("Chon: ");
    }

    private static void AddProduct()
    {
        Console.Write("Ma san pham: ");
        string maSP = Console.ReadLine() ?? "";

        Console.Write("Ten san pham: ");
        string tenSP = Console.ReadLine() ?? "";

        decimal price = ReadDecimal("Don gia: ");
        int quantity = ReadInt("So luong: ");

        service.AddProduct(maSP, tenSP, price, quantity);
    }

    private static void PrintAll()
    {
        var products = service.GetAll();
        if (products.Count == 0)
        {
            Console.WriteLine("Danh sach san pham dang trong.");
            return;
        }

        PrintHeader();
        foreach (var p in products)
            Console.WriteLine(p);
    }

    private static void FindByCode()
    {
        Console.Write("Nhap ma san pham: ");
        string maSP = Console.ReadLine() ?? "";

        var product = service.FindById(maSP);
        PrintHeader();
        Console.WriteLine(product);
    }

    private static void FindByName()
    {
        Console.Write("Nhap tu khoa: ");
        string keyword = Console.ReadLine() ?? "";

        var results = service.Search(keyword);
        if (results.Count == 0)
        {
            Console.WriteLine("Khong tim thay san pham phu hop.");
            return;
        }

        PrintHeader();
        foreach (var p in results)
            Console.WriteLine(p);
    }

    private static void FilterByPriceRange()
    {
        decimal min = ReadDecimal("Gia nho nhat: ");
        decimal max = ReadDecimal("Gia lon nhat: ");

        var results = service.Filter(min, max);
        if (results.Count == 0)
        {
            Console.WriteLine("Khong co san pham trong khoang gia nay.");
            return;
        }

        PrintHeader();
        foreach (var p in results)
            Console.WriteLine(p);
    }

    private static void RemoveProduct()
    {
        Console.Write("Nhap ma san pham can xoa: ");
        string maSP = Console.ReadLine() ?? "";

        service.RemoveProduct(maSP);
    }

    private static void PrintTotalValue()
    {
        decimal total = service.GetTotalValue();
        Console.WriteLine($"Tong gia tri kho: {total:N0}");
    }

    private static void PrintHeader()
    {
        Console.WriteLine($"{"Ma",-10} {"Ten",-20} {"Don gia",15} {"So luong",10}");
        Console.WriteLine(new string('-', 58));
    }

    private static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value))
                return value;

            Console.WriteLine("Gia tri khong hop le, vui long nhap lai.");
        }
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int value))
                return value;

            Console.WriteLine("Gia tri khong hop le, vui long nhap lai.");
        }
    }
}
