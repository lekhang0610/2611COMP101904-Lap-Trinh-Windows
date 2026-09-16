using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class NhanVien
{
    public string MaNV { get; set; }
    public string HoTen { get; set; }
    private double luongCoBan;
    public double LuongCoBan
    {
        get => luongCoBan;
        set => luongCoBan = value > 0 ? value : 0;
    }

    public NhanVien(string maNV, string hoTen, double luongCoBan)
    {
        MaNV = maNV;
        HoTen = hoTen;
        LuongCoBan = luongCoBan;
    }

    public virtual double TinhLuong()
    {
        return LuongCoBan;
    }

    public virtual void HienThiThongTin()
    {
        Console.WriteLine($"[NV] {MaNV} - {HoTen} - Lương cơ bản: {LuongCoBan:N0} - Lương: {TinhLuong():N0}");
    }
}

class NhanVienVanPhong : NhanVien
{
    private int soNgayLamViec;
    public int SoNgayLamViec
    {
        get => soNgayLamViec;
        set => soNgayLamViec = (value >= 0 && value <= 31) ? value : 0;
    }

    public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
        : base(maNV, hoTen, luongCoBan)
    {
        SoNgayLamViec = soNgayLamViec;
    }

    public override double TinhLuong()
    {
        return LuongCoBan + SoNgayLamViec * 200000;
    }

    public override void HienThiThongTin()
    {
        Console.WriteLine($"[Văn phòng] {MaNV} - {HoTen} - Số ngày làm: {SoNgayLamViec} - Lương: {TinhLuong():N0}");
    }
}

class NhanVienKinhDoanh : NhanVien
{
    private double doanhSo;
    public double DoanhSo
    {
        get => doanhSo;
        set => doanhSo = value >= 0 ? value : 0;
    }

    public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
        : base(maNV, hoTen, luongCoBan)
    {
        DoanhSo = doanhSo;
    }

    public override double TinhLuong()
    {
        return LuongCoBan + 0.05 * DoanhSo;
    }

    public override void HienThiThongTin()
    {
        Console.WriteLine($"[Kinh doanh] {MaNV} - {HoTen} - Doanh số: {DoanhSo:N0} - Lương: {TinhLuong():N0}");
    }
}

class NhanVienThoiVu : NhanVien
{
    private int soGioLam;
    public int SoGioLam
    {
        get => soGioLam;
        set => soGioLam = value >= 0 ? value : 0;
    }
    private double luongTheoGio;
    public double LuongTheoGio
    {
        get => luongTheoGio;
        set => luongTheoGio = value >= 0 ? value : 0;
    }

    public NhanVienThoiVu(string maNV, string hoTen, int soGioLam, double luongTheoGio)
        : base(maNV, hoTen, 0)
    {
        SoGioLam = soGioLam;
        LuongTheoGio = luongTheoGio;
    }

    public override double TinhLuong()
    {
        return SoGioLam * LuongTheoGio;
    }

    public override void HienThiThongTin()
    {
        Console.WriteLine($"[Thời vụ] {MaNV} - {HoTen} - Số giờ làm: {SoGioLam} - Lương theo giờ: {LuongTheoGio:N0} - Lương: {TinhLuong():N0}");
    }
}

class Program
{
    static List<NhanVien> danhSach = new List<NhanVien>();

    static void NhapItNhat5NhanVien()
    {
        int soLuong = 0;
        while (soLuong < 5)
        {
            Console.WriteLine($"\n-- Nhập nhân viên thứ {soLuong + 1} --");
            NhapNhanVien();
            soLuong = danhSach.Count;
        }
    }

    static void NhapNhanVien()
    {
        Console.Write("Mã NV: ");
        string maNV = Console.ReadLine();
        Console.Write("Họ tên: ");
        string hoTen = Console.ReadLine();
        Console.WriteLine("Loại: 1-Văn phòng 2-Kinh doanh 3-Thời vụ");
        Console.Write("Chọn: ");
        string loai = Console.ReadLine();

        if (loai == "1")
        {
            Console.Write("Lương cơ bản: ");
            double luongCoBan = double.Parse(Console.ReadLine());
            Console.Write("Số ngày làm việc: ");
            int soNgay = int.Parse(Console.ReadLine());
            danhSach.Add(new NhanVienVanPhong(maNV, hoTen, luongCoBan, soNgay));
        }
        else if (loai == "2")
        {
            Console.Write("Lương cơ bản: ");
            double luongCoBan = double.Parse(Console.ReadLine());
            Console.Write("Doanh số: ");
            double doanhSo = double.Parse(Console.ReadLine());
            danhSach.Add(new NhanVienKinhDoanh(maNV, hoTen, luongCoBan, doanhSo));
        }
        else if (loai == "3")
        {
            Console.Write("Số giờ làm: ");
            int soGio = int.Parse(Console.ReadLine());
            Console.Write("Lương theo giờ: ");
            double luongGio = double.Parse(Console.ReadLine());
            danhSach.Add(new NhanVienThoiVu(maNV, hoTen, soGio, luongGio));
        }
        else
        {
            Console.WriteLine("Loại không hợp lệ.");
        }
    }

    static void XuatDanhSach()
    {
        foreach (var nv in danhSach)
            nv.HienThiThongTin();
    }

    static void TimTheoMa()
    {
        Console.Write("Nhập mã cần tìm: ");
        string ma = Console.ReadLine();
        var nv = danhSach.FirstOrDefault(x => x.MaNV == ma);
        if (nv != null)
            nv.HienThiThongTin();
        else
            Console.WriteLine("Không tìm thấy.");
    }

    static void TimLuongCaoNhat()
    {
        if (danhSach.Count == 0) return;
        var nvCaoNhat = danhSach.OrderByDescending(x => x.TinhLuong()).First();
        nvCaoNhat.HienThiThongTin();
    }

    static void TongLuong()
    {
        double tong = danhSach.Sum(x => x.TinhLuong());
        Console.WriteLine($"Tổng lương công ty phải trả: {tong:N0}");
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        NhapItNhat5NhanVien();

        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Xuất danh sách nhân viên");
            Console.WriteLine("2. Tìm nhân viên theo mã");
            Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
            Console.WriteLine("4. Tính tổng lương công ty phải trả");
            Console.WriteLine("5. Thêm nhân viên mới");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            string chon = Console.ReadLine();

            switch (chon)
            {
                case "1": XuatDanhSach(); break;
                case "2": TimTheoMa(); break;
                case "3": TimLuongCaoNhat(); break;
                case "4": TongLuong(); break;
                case "5": NhapNhanVien(); break;
                case "0": return;
                default: Console.WriteLine("Lựa chọn không hợp lệ."); break;
            }
        }
    }
}
