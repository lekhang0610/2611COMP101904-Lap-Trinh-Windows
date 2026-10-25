# Lab 12 - Data Binding, Stored Procedure và Transaction

Module nhập điểm theo lớp (C# WinForms, SQL Server, ADO.NET, Microsoft.Data.SqlClient).

## Chạy chương trình
1. Mở SSMS, chạy `Database/QLSinhVienLab12.sql`.
2. Sửa `DAL/Database.cs` nếu server không phải `.` (ví dụ `.\SQLEXPRESS`).
3. Mở project bằng Visual Studio 2022 (.NET 8), nhấn F5.

## Cách dùng
Chọn lớp, môn học, bấm **Tải danh sách**, nhập Điểm/Ghi chú, bấm **Lưu tất cả**.

## Cấu trúc
- `Forms/FrmNhapDiemTheoLop`: giao diện, validate điểm (không rỗng, là số, 0-10)
- `DAL/Database.cs`: connection string
- `DAL/KetQuaDAL.cs`: gọi stored procedure bằng parameter, lưu bằng transaction (commit khi tất cả hợp lệ, rollback khi lỗi)
- `Database/QLSinhVienLab12.sql`: tạo DB, bảng, dữ liệu mẫu, 4 stored procedure

## Test
- Nhập điểm 15 cho một sinh viên: báo lỗi, không dòng nào được lưu.
- Nhập điểm hợp lệ cho cả lớp: báo đã lưu 3 dòng, tải lại vẫn thấy điểm.

## Ảnh chụp màn hình
Thêm ảnh Form trước và sau khi lưu vào thư mục `screenshots/`.
