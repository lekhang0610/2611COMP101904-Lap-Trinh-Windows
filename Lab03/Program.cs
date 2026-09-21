using System;
using System.Globalization;

namespace Lab03_QuanLySinhVienOOP
{
    public class Program
    {
        static QuanLySinhVien quanLy = new QuanLySinhVien();

        public static void Main(string[] args)
        {
            int luaChon;
            do
            {
                HienThiMenu();
                luaChon = NhapSo("Chon chuc nang: ");
                switch (luaChon)
                {
                    case 1: ThemSinhVien(); break;
                    case 2: XuatDanhSach(); break;
                    case 3: TimTheoMa(); break;
                    case 4: TimTheoTen(); break;
                    case 5: SuaDiem(); break;
                    case 6: XoaSinhVien(); break;
                    case 7: SapXepTheoDiem(); break;
                    case 8: LocSinhVienDat(); break;
                    case 0: Console.WriteLine("Tam biet!"); break;
                    default: Console.WriteLine("Lua chon khong hop le."); break;
                }
                Console.WriteLine();
            } while (luaChon != 0);
        }

        static void HienThiMenu()
        {
            Console.WriteLine("===== QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim sinh vien theo ten");
            Console.WriteLine("5. Sua diem trung binh");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo diem giam dan");
            Console.WriteLine("8. Loc sinh vien dat");
            Console.WriteLine("0. Thoat");
        }

        static void ThemSinhVien()
        {
            Console.Write("Ma sinh vien: ");
            string ma = Console.ReadLine();

            Console.Write("Ho ten: ");
            string hoTen = Console.ReadLine();

            DateTime ngaySinh = NhapNgay("Ngay sinh (dd/MM/yyyy): ");

            Console.Write("Ma lop: ");
            string maLop = Console.ReadLine();

            double diem = NhapDiem("Diem trung binh (0-10): ");

            var sv = new SinhVien(ma, hoTen, ngaySinh, maLop, diem);
            if (quanLy.Them(sv))
                Console.WriteLine("Them thanh cong.");
            else
                Console.WriteLine("Ma sinh vien da ton tai.");
        }

        static void XuatDanhSach()
        {
            var ds = quanLy.LayDanhSach();
            InDanhSach(ds);
        }

        static void TimTheoMa()
        {
            Console.Write("Nhap ma sinh vien: ");
            string ma = Console.ReadLine();
            var sv = quanLy.TimTheoMa(ma);
            if (sv == null)
                Console.WriteLine("Khong tim thay.");
            else
                Console.WriteLine(sv.LayThongTin());
        }

        static void TimTheoTen()
        {
            Console.Write("Nhap tu khoa ho ten: ");
            string tuKhoa = Console.ReadLine();
            var ds = quanLy.TimTheoTen(tuKhoa);
            InDanhSach(ds);
        }

        static void SuaDiem()
        {
            Console.Write("Nhap ma sinh vien: ");
            string ma = Console.ReadLine();
            if (quanLy.TimTheoMa(ma) == null)
            {
                Console.WriteLine("Khong tim thay.");
                return;
            }
            double diemMoi = NhapDiem("Diem moi (0-10): ");
            quanLy.Sua(ma, diemMoi);
            Console.WriteLine("Cap nhat thanh cong.");
        }

        static void XoaSinhVien()
        {
            Console.Write("Nhap ma sinh vien: ");
            string ma = Console.ReadLine();
            if (quanLy.Xoa(ma))
                Console.WriteLine("Xoa thanh cong.");
            else
                Console.WriteLine("Khong tim thay.");
        }

        static void SapXepTheoDiem()
        {
            var ds = quanLy.SapXepTheoDiem();
            InDanhSach(ds);
        }

        static void LocSinhVienDat()
        {
            var ds = quanLy.LocSinhVienDat();
            InDanhSach(ds);
        }

        static void InDanhSach(System.Collections.Generic.List<SinhVien> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach rong.");
                return;
            }
            Console.WriteLine($"{"Ma",-8}{"Ho ten",-25}{"Lop",-10}{"Diem",-6}Xep loai");
            foreach (var sv in ds)
                Console.WriteLine(sv.LayThongTin());
        }

        static int NhapSo(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                if (int.TryParse(Console.ReadLine(), out int kq))
                    return kq;
                Console.WriteLine("Vui long nhap so nguyen.");
            }
        }

        static double NhapDiem(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                if (double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double diem)
                    && diem >= 0 && diem <= 10)
                    return diem;
                Console.WriteLine("Diem khong hop le, vui long nhap lai (0-10).");
            }
        }

        static DateTime NhapNgay(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngay))
                    return ngay;
                Console.WriteLine("Ngay khong hop le, vui long nhap lai (dd/MM/yyyy).");
            }
        }
    }
}
