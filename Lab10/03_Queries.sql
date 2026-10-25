\xEF\xBB\xBF/* =====================================================================
   COMP1019 - Lập trình trên Windows | Buổi 10 - Lab
   File    : 03_Queries.sql
   Mục đích: 12 truy vấn yêu cầu của đề (SELECT, JOIN, GROUP BY,
             UPDATE, DELETE và kiểm thử ràng buộc).
   Gợi ý   : Bôi đen từng câu rồi bấm Execute để chụp ảnh kết quả.
   ===================================================================== */

USE EduManagerDB;
GO

/* ---------------------------------------------------------------------
   Câu 1. Liệt kê toàn bộ sinh viên
   --------------------------------------------------------------------- */
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;
GO

/* ---------------------------------------------------------------------
   Câu 2. Liệt kê sinh viên kèm tên lớp và tên khoa
   JOIN 3 bảng: SINHVIEN -> LOP -> KHOA
   --------------------------------------------------------------------- */
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP  l ON sv.MaLop  = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa  = k.MaKhoa
ORDER BY sv.MaSV;
GO

/* ---------------------------------------------------------------------
   Câu 3. Tìm sinh viên theo một phần họ tên bằng LIKE
   %...% : khớp chuỗi con ở bất kỳ vị trí nào
   --------------------------------------------------------------------- */
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%Văn%'
ORDER BY HoTen;
GO

/* ---------------------------------------------------------------------
   Câu 4. Liệt kê sinh viên theo mã lớp (ví dụ lớp CNTT01)
   --------------------------------------------------------------------- */
SELECT MaSV, HoTen, GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01';
GO

/* ---------------------------------------------------------------------
   Câu 5. Cập nhật họ tên của một sinh viên
   Luôn kiểm tra WHERE trước khi chạy UPDATE.
   (Muốn đổi lớp: SET MaLop = 'CNTT02' - lớp mới phải tồn tại.)
   --------------------------------------------------------------------- */
SELECT MaSV, HoTen FROM SINHVIEN WHERE MaSV = 'SV001';   -- trước khi cập nhật

UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn Anh'
WHERE MaSV = 'SV001';

SELECT MaSV, HoTen FROM SINHVIEN WHERE MaSV = 'SV001';   -- sau khi cập nhật
GO

/* ---------------------------------------------------------------------
   Câu 6. Xóa một sinh viên chưa có dữ liệu điểm
   SV007 chưa có điểm nên xóa được. Điều kiện NOT EXISTS đảm bảo
   không xóa nhầm sinh viên đã có điểm (nếu xóa sẽ vi phạm khóa ngoại).
   --------------------------------------------------------------------- */
DELETE FROM SINHVIEN
WHERE MaSV = 'SV007'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV007');

SELECT MaSV, HoTen FROM SINHVIEN;                         -- SV007 đã biến mất
GO

/* ---------------------------------------------------------------------
   Câu 7. Liệt kê điểm của từng sinh viên theo từng môn
   --------------------------------------------------------------------- */
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC   mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;
GO

/* ---------------------------------------------------------------------
   Câu 8. Tính điểm trung bình của từng sinh viên
   GROUP BY gom theo sinh viên, AVG tính trung bình điểm.
   --------------------------------------------------------------------- */
SELECT sv.MaSV, sv.HoTen, CAST(AVG(kq.Diem) AS DECIMAL(4,2)) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen
ORDER BY sv.MaSV;
GO

/* ---------------------------------------------------------------------
   Câu 9. Thống kê số sinh viên theo từng lớp
   LEFT JOIN để lớp chưa có sinh viên vẫn hiện (SoSinhVien = 0).
   --------------------------------------------------------------------- */
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
ORDER BY l.MaLop;
GO

/* ---------------------------------------------------------------------
   Câu 10. Liệt kê các lớp có từ 2 sinh viên trở lên
   HAVING lọc SAU khi đã GROUP BY (WHERE không dùng được với COUNT).
   --------------------------------------------------------------------- */
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2;
GO

/* =====================================================================
   KIỂM THỬ RÀNG BUỘC - các lệnh dưới đây PHẢI báo lỗi.
   Dùng TRY...CATCH để in thông báo lỗi mà không dừng script.
   Nếu hiện "!!! KHÔNG LỖI" nghĩa là ràng buộc chưa hoạt động.
   ===================================================================== */

/* Câu 11. Thêm sinh viên vào lớp không tồn tại -> lỗi khóa ngoại (FK) */
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
    PRINT N'!!! KHÔNG LỖI (câu 11) - cần kiểm tra lại khóa ngoại';
END TRY
BEGIN CATCH
    PRINT N'Câu 11 - Lỗi như mong đợi: ' + ERROR_MESSAGE();
END CATCH;
GO

/* Câu 12. Nhập điểm ngoài khoảng 0..10 -> lỗi CHECK
   Dùng cặp (SV004, COMP1020) chưa tồn tại để lỗi chắc chắn do CHECK
   chứ không phải do trùng khóa chính. */
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem)
    VALUES ('SV004', 'COMP1020', 12);
    PRINT N'!!! KHÔNG LỖI (câu 12) - cần kiểm tra lại CHECK điểm';
END TRY
BEGIN CATCH
    PRINT N'Câu 12 - Lỗi như mong đợi: ' + ERROR_MESSAGE();
END CATCH;
GO

/* ---------------------------------------------------------------------
   Test bổ sung (không bắt buộc, nhưng nên có để lấy trọn điểm ràng buộc)
   --------------------------------------------------------------------- */

-- Câu 13. Giới tính không thuộc Nam/Nữ -> lỗi CHECK
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV998', N'Sinh viên giới tính lỗi', '2005-01-01', N'Khác', 'CNTT01');
    PRINT N'!!! KHÔNG LỖI (câu 13)';
END TRY
BEGIN CATCH
    PRINT N'Câu 13 - Lỗi như mong đợi: ' + ERROR_MESSAGE();
END CATCH;
GO

-- Câu 14. Trùng khóa chính (MaSV SV001 đã tồn tại) -> lỗi PRIMARY KEY
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV001', N'Trùng mã', '2005-01-01', N'Nam', 'CNTT01');
    PRINT N'!!! KHÔNG LỖI (câu 14)';
END TRY
BEGIN CATCH
    PRINT N'Câu 14 - Lỗi như mong đợi: ' + ERROR_MESSAGE();
END CATCH;
GO

-- Câu 15. Số tín chỉ <= 0 -> lỗi CHECK
BEGIN TRY
    INSERT INTO MONHOC (MaMH, TenMH, SoTinChi)
    VALUES ('COMP9999', N'Môn lỗi', 0);
    PRINT N'!!! KHÔNG LỖI (câu 15)';
END TRY
BEGIN CATCH
    PRINT N'Câu 15 - Lỗi như mong đợi: ' + ERROR_MESSAGE();
END CATCH;
GO
