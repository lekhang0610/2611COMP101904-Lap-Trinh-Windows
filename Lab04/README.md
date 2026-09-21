# Product Manager - COMP1019 Lab 04

Console app quản lý sản phẩm, minh họa Exception tự tạo, Delegate/Event,
Func/Action và Generic trong C#.

## Cấu trúc project

```
ProductManager/
├── ProductManager.csproj
├── README.md
└── src/
    ├── IEntity.cs                  # Interface ràng buộc generic (string Id)
    ├── Product.cs                  # Entity sản phẩm, validate Price/Quantity >= 0
    ├── DuplicateProductException.cs
    ├── ProductNotFoundException.cs
    ├── Repository.cs               # Repository<T> where T : IEntity
    ├── ProductService.cs           # Nghiệp vụ + event ProductAdded/ProductRemoved
    └── Program.cs                  # Main, menu, nhập xuất, bắt exception
```

## Cách chạy

Yêu cầu .NET SDK 8.0 trở lên.

```bash
dotnet run --project ProductManager.csproj
```

## Chức năng

| Lựa chọn | Chức năng |
|---|---|
| 1 | Thêm sản phẩm |
| 2 | Xuất danh sách |
| 3 | Tìm theo mã |
| 4 | Tìm theo tên (chứa từ khóa) |
| 5 | Lọc theo khoảng giá (dùng `Func<Product,bool>`) |
| 6 | Xóa sản phẩm |
| 7 | Tính tổng giá trị kho |
| 0 | Thoát |

## Ghi chú kỹ thuật

- `Repository<T>` là generic class với constraint `where T : IEntity`, cung cấp
  `Add`, `Remove`, `FindById`, `Find(Func<T,bool>)`, `GetAll`.
- `DuplicateProductException` được ném khi `Add` một `Id` đã tồn tại;
  `ProductNotFoundException` được ném khi `Remove`/`FindById` không thấy.
- `ProductService` bọc `Repository<Product>`, kiểm tra nghiệp vụ và phát
  event `ProductAdded` / `ProductRemoved` (kiểu `Action<Product>`).
- `Search` và `Filter` dùng `Func<Product,bool>` truyền vào `Repository.Find`.
- `Program.Main` bắt toàn bộ exception trong vòng lặp menu nên nhập sai dữ
  liệu không làm chương trình dừng đột ngột.
