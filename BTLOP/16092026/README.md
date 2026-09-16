# Chương trình Quản Lý Nhân Viên (C#)

Chương trình Console C# quản lý nhân viên, áp dụng Class, Property, Constructor, Encapsulation, Kế thừa và Đa hình.

## Ảnh minh họa

> _(Thêm ảnh chụp màn hình chương trình vào đây)_

![Ảnh minh họa 1](images/screenshot-1.png)
![Ảnh minh họa 2](images/screenshot-2.png)

## Cấu trúc lớp

### `NhanVien` (lớp cơ sở)
| Thành phần | Mô tả |
|---|---|
| `MaNV` | Mã nhân viên |
| `HoTen` | Họ tên |
| `LuongCoBan` | Lương cơ bản (bắt buộc > 0) |
| `TinhLuong()` | Phương thức ảo, tính lương |
| `HienThiThongTin()` | Phương thức ảo, hiển thị thông tin |

### `NhanVienVanPhong` (kế thừa `NhanVien`)
- Thêm `SoNgayLamViec` (0–31)
- Công thức lương: `LuongCoBan + SoNgayLamViec × 200.000`

### `NhanVienKinhDoanh` (kế thừa `NhanVien`)
- Thêm `DoanhSo` (≥ 0)
- Công thức lương: `LuongCoBan + 5% × DoanhSo`

### `NhanVienThoiVu` (kế thừa `NhanVien`) — mở rộng thêm
- Thêm `SoGioLam`, `LuongTheoGio`
- Công thức lương: `SoGioLam × LuongTheoGio`

## Chức năng chương trình

Chương trình yêu cầu nhập **ít nhất 5 nhân viên** (thuộc các loại trên) trước khi vào menu chính.

Menu gồm:

1. **Xuất danh sách nhân viên** — hiển thị toàn bộ danh sách, thông qua đa hình (`HienThiThongTin()`).
2. **Tìm nhân viên theo mã** — nhập mã, tìm và hiển thị thông tin nhân viên tương ứng.
3. **Tìm nhân viên có lương cao nhất** — so sánh lương qua `TinhLuong()`, không cần biết loại nhân viên cụ thể.
4. **Tính tổng lương công ty phải trả** — cộng dồn lương của toàn bộ nhân viên trong danh sách.
5. **Thêm nhân viên mới** — bổ sung thêm nhân viên vào danh sách sau khi đã vào menu.
0. **Thoát** — kết thúc chương trình.

Điểm quan trọng: các chức năng 1, 3, 4 xử lý hoàn toàn thông qua đa hình (`TinhLuong()`, `HienThiThongTin()`), **không** dùng `if`/`switch` để kiểm tra kiểu nhân viên. Nhờ vậy khi thêm `NhanVienThoiVu` (hoặc bất kỳ loại nhân viên mới nào), không cần sửa lại các thuật toán này.

## Cách chạy chương trình

1. Mở Visual Studio → tạo project **Console App (C#)**.
2. Thay nội dung file `Program.cs` bằng nội dung file `QuanLyNhanVien.cs`.
3. Nhấn **F5** (Debug) hoặc **Ctrl+F5** (chạy không debug) để chạy chương trình.

## Yêu cầu

- .NET 6.0 trở lên
- Nếu tiếng Việt hiển thị bị lỗi font trên console, đổi font console sang **Consolas** hoặc **Lucida Console** (chuột phải cửa sổ console → Properties → Font).
