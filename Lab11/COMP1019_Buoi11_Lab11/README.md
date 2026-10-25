# COMP1019 - Lab 11: ADO.NET và CRUD với SQL Server

Form `FrmLop` quản lý bảng `LOP` trong database `EduManagerDB` (SQL Server), dùng `Microsoft.Data.SqlClient` và `SqlParameter` cho mọi câu SQL.

## Cách chạy
1. Mở SSMS, chạy `EduManagerDB.sql` để tạo database và dữ liệu mẫu.
2. Mở `COMP1019_Buoi11_Lab11.csproj` bằng Visual Studio 2022 (.NET 8), restore NuGet, nhấn F5.

## Connection string đang dùng
```
Data Source=.;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True
```
Nếu dùng SQL Express: đổi thành `Data Source=.\SQLEXPRESS`. Chuỗi nằm ở hằng `cs` trong `FrmLop.cs`.

## Chức năng
F1 load khi mở Form · F2 click dòng đổ lên TextBox (khóa txtMaLop) · F3 Thêm (rỗng, trùng mã) · F4 Sửa (phải chọn lớp) · F5 Xóa (xác nhận, chặn lớp có sinh viên, bắt lỗi khóa ngoại 547) · F6 Tìm kiếm LIKE + parameter · F7 Làm mới (mở khóa txtMaLop, load lại) · F8 toàn bộ dùng parameter.

## Test case
| STT | Tình huống | Dữ liệu | Kết quả mong đợi |
|---|---|---|---|
| 1 | Load Form | Mở FrmLop | Hiển thị 3 lớp |
| 2 | Thêm hợp lệ | TEST01, Lớp test | Thêm thành công |
| 3 | Thêm thiếu mã | MaLop rỗng | Báo nhập mã lớp |
| 4 | Thêm thiếu tên | TenLop rỗng | Báo nhập tên lớp |
| 5 | Thêm trùng mã | CNTT01 | Báo mã lớp đã tồn tại |
| 6 | Sửa khi chưa chọn | Không chọn dòng | Báo chọn lớp cần sửa |
| 7 | Sửa hợp lệ | Chọn TEST01, đổi tên | Cập nhật thành công |
| 8 | Xóa lớp chưa có SV | TEST01 | Hỏi xác nhận, xóa thành công |
| 9 | Xóa lớp có SV | CNTT01 | Không cho xóa |
| 10 | Tìm kiếm | CNTT | Hiện CNTT01, CNTT02 |
| 11 | Làm mới | Bấm Làm mới | Xóa TextBox, mở khóa mã lớp, load lại |

## Ảnh chụp màn hình
(Chèn ảnh Form đang load dữ liệu tại đây: `screenshots/form.png`)

## Push GitHub
```
git init
git add .
git commit -m "Lab 11 - ADO.NET CRUD LOP"
git branch -M main
git remote add origin <url-repo>
git push -u origin main
```
