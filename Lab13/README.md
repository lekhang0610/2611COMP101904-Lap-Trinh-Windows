# Lab 13 - Báo cáo sinh viên bằng LINQ

Học phần COMP1019 - Lập trình trên Windows (C# WinForms, .NET 8).

## Chức năng
- Chọn lớp (`cboLop`), kết quả (`cboKetQua`: Tất cả / Đạt / Không đạt), từ khóa theo mã SV hoặc họ tên (`txtTuKhoa`).
- **Xem báo cáo**: lọc bằng LINQ (`Where`), sắp xếp giảm dần theo điểm (`OrderByDescending`), hiển thị trên `dgvBaoCao`.
- **Thống kê**: `GroupBy` theo lớp, hiển thị số lượng, số đạt, số không đạt, điểm TB.
- **Xuất file**: lưu dữ liệu đang hiển thị ra CSV (UTF-8 BOM, mở bằng Excel không lỗi tiếng Việt) hoặc TXT.
- StatusStrip hiển thị: tổng số SV, số đạt, số không đạt, điểm TB của kết quả đang hiển thị.
- Không có dữ liệu phù hợp -> hiện thông báo rõ ràng.

## Cấu trúc
```
Lab13
├── Models/SinhVien.cs
├── Forms/FrmBaoCaoSinhVien.cs (+ .Designer.cs)
└── Program.cs
```

## Chạy
Cần Windows + .NET 8 SDK (hoặc Visual Studio 2022):
```
dotnet run
```
