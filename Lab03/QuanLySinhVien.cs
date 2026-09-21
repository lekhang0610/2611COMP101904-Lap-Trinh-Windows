using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private List<SinhVien> danhSach = new List<SinhVien>();

        public bool Them(SinhVien sv)
        {
            if (danhSach.Any(x => x.MaSinhVien == sv.MaSinhVien))
                return false;
            danhSach.Add(sv);
            return true;
        }

        public bool Sua(string ma, double diemMoi)
        {
            var sv = TimTheoMa(ma);
            if (sv == null) return false;
            sv.DiemTrungBinh = diemMoi;
            return true;
        }

        public bool Xoa(string ma)
        {
            var sv = TimTheoMa(ma);
            if (sv == null) return false;
            danhSach.Remove(sv);
            return true;
        }

        public SinhVien TimTheoMa(string ma)
        {
            return danhSach.FirstOrDefault(x => x.MaSinhVien.Equals(ma, StringComparison.OrdinalIgnoreCase));
        }

        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return danhSach
                .Where(x => x.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<SinhVien> SapXepTheoDiem()
        {
            return danhSach.OrderByDescending(x => x.DiemTrungBinh).ToList();
        }

        public List<SinhVien> LocSinhVienDat()
        {
            return danhSach.Where(x => x.DiemTrungBinh >= 5).ToList();
        }

        public List<SinhVien> LayDanhSach()
        {
            return danhSach;
        }
    }
}
