# Bài Lab 01 - Ứng Dụng Thông Tin Cá Nhân

**Học phần:** COMP1019 - Lập trình trên Windows
**Công cụ:** Visual Studio, Windows Forms App (.NET 8), C#

## Mô tả
Ứng dụng Windows Forms cho phép nhập thông tin cá nhân sinh viên (họ tên, năm sinh,
email, giới tính, khoa/lớp), kiểm tra dữ liệu hợp lệ, và hiển thị kết quả tổng hợp
khi nhấn nút **Hiển thị**. Nút **Xóa** đưa form về trạng thái rỗng, nút **Thoát**
hỏi xác nhận trước khi đóng chương trình.

## Cấu trúc project
- `Program.cs` — điểm khởi chạy ứng dụng
- `Form1.Designer.cs` — khai báo và bố trí control
- `Form1.cs` — xử lý sự kiện, kiểm tra dữ liệu, hiển thị kết quả

## Cách chạy
1. Mở `QuanLyThongTinCaNhan.csproj` bằng Visual Studio (2022+, có cài .NET desktop
   development workload).
2. Nhấn F5 để build và chạy.

## Kết quả
_(Chèn ảnh chụp màn hình chương trình khi chạy, khi nhập thiếu dữ liệu, và khi
hiển thị kết quả thành công vào đây trước khi nộp bài.)_

Ví dụ nhập:
- Họ tên: Nguyễn Văn A
- Năm sinh: 2005
- Email: vana@example.com
- Giới tính: Nam
- Khoa: Công nghệ thông tin

Kết quả hiển thị:
```
THÔNG TIN SINH VIÊN
Họ tên: Nguyễn Văn A
Tuổi: 21
Email: vana@example.com
Giới tính: Nam
Khoa/Lớp: Công nghệ thông tin
```
