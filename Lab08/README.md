# COMP1019 - Lab 08: Simple Paint (WinForms + GDI+)

## Cách chạy
1. Mở `COMP1019_Lab08_SimplePaint.csproj` bằng Visual Studio 2022 trở lên (cần workload .NET desktop, .NET 8).
2. Nhấn F5 để chạy. Hoặc dùng lệnh: `dotnet run`.

## Chức năng
- Chế độ vẽ: Pen, Line, Rectangle, Ellipse (kéo chuột theo mọi hướng đều đúng).
- Chọn màu (ColorDialog), độ dày 1-20 (NumericUpDown).
- Undo, Clear (có xác nhận), tọa độ chuột hiển thị ở status bar.
- Nét vẽ lưu trong `List<DrawItem>`, vẽ lại trong Paint event nên không mất khi resize.
- Nâng cao: Ctrl+Z, lưu PNG, tô màu hình (checkbox Fill), đổi màu nền canvas.

## Cấu trúc
- `Program.cs`, `FrmPaint.cs`, `DrawMode.cs`, `DrawItem.cs`, `DrawSurface.cs`

## Ảnh chụp màn hình
Thêm ảnh vào thư mục `screenshots/` (vẽ thử ít nhất 4 loại hình).
