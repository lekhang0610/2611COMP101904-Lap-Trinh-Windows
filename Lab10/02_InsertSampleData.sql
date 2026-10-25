\xEF\xBB\xBF/* =====================================================================
   COMP1019 - Lập trình trên Windows | Buổi 10 - Lab
   File    : 02_InsertSampleData.sql
   Mục đích: Nhập dữ liệu mẫu cho EduManagerDB.
   Thứ tự  : KHOA -> LOP -> SINHVIEN, MONHOC -> KETQUA, TAIKHOAN
             (bảng cha phải có dữ liệu trước bảng con để thỏa khóa ngoại)
   Số lượng: 2 khoa, 3 lớp, 7 sinh viên, 4 môn học, 8 kết quả, 2 tài khoản
   ===================================================================== */

USE EduManagerDB;
GO

-- 1. KHOA
INSERT INTO KHOA (MaKhoa, TenKhoa, DienThoai) VALUES
('FIT',  N'Khoa Công nghệ Thông tin', '0281234567'),
('MATH', N'Khoa Toán - Tin học',      '0287654321');

-- 2. LOP (mỗi lớp thuộc một khoa)
INSERT INTO LOP (MaLop, TenLop, MaKhoa) VALUES
('CNTT01',  N'Công nghệ thông tin 01', 'FIT'),
('CNTT02',  N'Công nghệ thông tin 02', 'FIT'),
('SPTIN01', N'Sư phạm Tin học 01',     'MATH');

-- 3. SINHVIEN (mỗi sinh viên thuộc một lớp)
--    SV007 cố ý KHÔNG có điểm để dùng cho câu truy vấn xóa (câu 6).
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) VALUES
('SV001', N'Nguyễn Văn An',    '2005-02-10', N'Nam', 'CNTT01'),
('SV002', N'Trần Thị Bình',    '2005-08-21', N'Nữ',  'CNTT01'),
('SV003', N'Lê Minh Chi',      '2004-12-02', N'Nữ',  'CNTT02'),
('SV004', N'Phạm Quốc Dũng',   '2005-04-16', N'Nam', 'CNTT02'),
('SV005', N'Hoàng Gia Hân',    '2005-10-30', N'Nữ',  'SPTIN01'),
('SV006', N'Võ Thành Khang',   '2004-09-09', N'Nam', 'CNTT02'),
('SV007', N'Đặng Thị Mai',     '2005-06-18', N'Nữ',  'CNTT01');

-- 4. MONHOC
INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES
('COMP1017', N'Lập trình cơ bản',              3),
('COMP1019', N'Lập trình trên Windows',        3),
('COMP1020', N'Cơ sở dữ liệu',                 3),
('COMP1044', N'Nhập môn Công nghệ phần mềm',   3);

-- 5. KETQUA (sau khi đã có SINHVIEN và MONHOC)
INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES
('SV001', 'COMP1019', 8.5),
('SV001', 'COMP1020', 7.5),
('SV002', 'COMP1019', 9.0),
('SV002', 'COMP1020', 8.0),
('SV003', 'COMP1019', 6.5),
('SV004', 'COMP1017', 7.0),
('SV005', 'COMP1017', 8.0),
('SV006', 'COMP1044', 7.8);

-- 6. TAIKHOAN (tài khoản demo)
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, HoTen, VaiTro) VALUES
('admin', '123456', N'Quản trị viên',    'Admin'),
('gv01',  '123456', N'Giảng viên demo',  'User');
GO

-- Kiểm tra số dòng của từng bảng
SELECT 'KHOA'      AS Bang, COUNT(*) AS SoDong FROM KHOA      UNION ALL
SELECT 'LOP',                COUNT(*)          FROM LOP       UNION ALL
SELECT 'SINHVIEN',           COUNT(*)          FROM SINHVIEN  UNION ALL
SELECT 'MONHOC',             COUNT(*)          FROM MONHOC    UNION ALL
SELECT 'KETQUA',             COUNT(*)          FROM KETQUA    UNION ALL
SELECT 'TAIKHOAN',           COUNT(*)          FROM TAIKHOAN;
GO
