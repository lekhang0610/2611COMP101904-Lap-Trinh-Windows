using System;

namespace Lab03_QuanLySinhVienOOP
{
    public class SinhVien : Nguoi
    {
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }

        private double diemTrungBinh;
        public double DiemTrungBinh
        {
            get => diemTrungBinh;
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException(nameof(value), "Diem phai tu 0 den 10");
                diemTrungBinh = value;
            }
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh;
        }

        public string XepLoai()
        {
            if (diemTrungBinh >= 8) return "Gioi";
            if (diemTrungBinh >= 6.5) return "Kha";
            if (diemTrungBinh >= 5) return "Trung binh";
            return "Yeu";
        }

        public override string LayThongTin()
        {
            return $"{MaSinhVien,-8}{HoTen,-25}{MaLop,-10}{DiemTrungBinh,-6:0.0}{XepLoai()}";
        }
    }
}
