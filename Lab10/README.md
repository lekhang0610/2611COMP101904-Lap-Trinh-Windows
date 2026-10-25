# Báo cáo Lab Buổi 10 – EduManagerDB (SQL Server)

**Môn:** COMP1019 – Lập trình trên Windows
**Họ tên / MSSV:** ………………………………

## 1. Mục tiêu
Thiết kế và cài đặt cơ sở dữ liệu quan hệ **EduManagerDB** cho ứng dụng quản lý sinh viên bằng T-SQL: tạo bảng, khóa chính, khóa ngoại, ràng buộc CHECK, nhập dữ liệu mẫu, viết truy vấn và kiểm thử ràng buộc.

## 2. Cấu trúc file nộp
| File | Nội dung |
|---|---|
| `01_CreateDatabase.sql` | Tạo database và 6 bảng cùng ràng buộc |
| `02_InsertSampleData.sql` | Dữ liệu mẫu (2 khoa, 3 lớp, 7 sinh viên, 4 môn, 8 kết quả, 2 tài khoản) |
| `03_Queries.sql` | 12 truy vấn theo yêu cầu + test ràng buộc bổ sung |
| `README.md` | Báo cáo ngắn này |

**Cách chạy:** mở từng file trong SSMS và chạy theo thứ tự 01 → 02 → 03. File 01 tự xóa database cũ nên có thể chạy lại nhiều lần.

## 3. Thiết kế database

```
KHOA (MaKhoa PK, TenKhoa, DienThoai)
  └─< LOP (MaLop PK, TenLop, MaKhoa FK)
        └─< SINHVIEN (MaSV PK, HoTen, NgaySinh, GioiTinh, MaLop FK)
              └─< KETQUA (MaSV FK, MaMH FK, Diem)  PK(MaSV, MaMH)
                    >─ MONHOC (MaMH PK, TenMH, SoTinChi)
TAIKHOAN (TenDangNhap PK, MatKhau, HoTen, VaiTro, TrangThai)
```

**Ràng buộc đã cài đặt**
- `LOP.MaKhoa → KHOA`, `SINHVIEN.MaLop → LOP`, `KETQUA.MaSV → SINHVIEN`, `KETQUA.MaMH → MONHOC` (khóa ngoại).
- `KETQUA`: khóa chính ghép (MaSV, MaMH) để mỗi sinh viên chỉ có một điểm cho mỗi môn.
- `CK_KETQUA_Diem`: điểm từ 0 đến 10.
- `CK_SINHVIEN_GioiTinh`: giới tính chỉ nhận `Nam` hoặc `Nữ`.
- `CK_MONHOC_SoTinChi`: số tín chỉ > 0.

## 4. Kết quả chạy truy vấn
> Chèn ảnh chụp kết quả vào các mục dưới đây (thư mục `images/`).

| Truy vấn | Ảnh |
|---|---|
| Object Explorer có đủ 6 bảng | `![](images/tables.png)` |
| Câu 2 – Sinh viên kèm lớp, khoa | `![](images/q02.png)` |
| Câu 8 – Điểm trung bình | `![](images/q08.png)` |
| Câu 9 – Số sinh viên theo lớp | `![](images/q09.png)` |
| Câu 10 – Lớp có từ 2 sinh viên | `![](images/q10.png)` |
| Câu 11, 12 – Test lỗi ràng buộc (tab Messages) | `![](images/q11_12.png)` |

## 5. Kết quả kiểm thử ràng buộc
| Test | Kết quả mong đợi |
|---|---|
| Thêm sinh viên vào lớp `CNTT99` | Lỗi vi phạm khóa ngoại `FK_SINHVIEN_LOP` |
| Nhập điểm `12` | Lỗi vi phạm `CK_KETQUA_Diem` |
| Giới tính `Khác` | Lỗi vi phạm `CK_SINHVIEN_GioiTinh` |
| Trùng `MaSV` | Lỗi vi phạm `PK_SINHVIEN` |
| Số tín chỉ `0` | Lỗi vi phạm `CK_MONHOC_SoTinChi` |

## 6. Nhận xét
- Thứ tự nhập dữ liệu phải theo quan hệ cha → con (KHOA → LOP → SINHVIEN/MONHOC → KETQUA).
- Ràng buộc ở tầng database giúp chặn dữ liệu sai dù ứng dụng phía trên có kiểm tra hay không.
- Mật khẩu trong `TAIKHOAN` lưu dạng thường chỉ để demo; ứng dụng thật cần băm mật khẩu.
