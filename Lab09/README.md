# StudentCardPrinter – COMP1019 Lab 09

Ứng dụng Windows Forms (C#, .NET 8) nhập thông tin sinh viên, chọn ảnh, xem trước thẻ bằng GDI+ và in thẻ bằng `PrintDocument`.

## Yêu cầu
- Windows 10/11
- .NET 8 SDK
- Visual Studio 2022 (workload ".NET desktop development") hoặc dotnet CLI

## Cách chạy
**Visual Studio:** mở thư mục dự án (file `StudentCardPrinter.csproj`) → nhấn `F5`.

**Dòng lệnh:**
```
dotnet run --project StudentCardPrinter.csproj
```

## Cách dùng
1. Nhập mã sinh viên, họ tên, khóa; chọn lớp, khoa, giới tính, ngày sinh.
2. Bấm **Chọn ảnh** để chọn ảnh JPG/PNG/BMP. Thẻ bên phải tự cập nhật.
3. Bấm **Xem trước in** để mở Print Preview.
4. Bấm **In** để chọn máy in (có thể chọn *Microsoft Print to PDF*).
5. Bấm **Làm mới** để xóa dữ liệu và ảnh; **Thoát** để đóng chương trình.

## Cấu trúc
| File | Vai trò |
|---|---|
| `Program.cs` | Điểm vào chương trình |
| `StudentCardInfo.cs` | Lớp dữ liệu của thẻ |
| `FrmStudentCard.cs` | Logic form, vẽ thẻ, in |
| `FrmStudentCard.Designer.cs` | Khai báo control |

## Ảnh chụp màn hình
- `screenshots/main-form.png` – Form chính
- `screenshots/print-preview.png` – Print Preview


