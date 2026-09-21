# Lab03 - Quan Ly Sinh Vien (OOP, C# Console)

Chuong trinh Console quan ly sinh vien, ap dung class, ke thua, property validation, List<T> va LINQ.
Mon hoc: COMP1019 - Lap trinh tren Windows - Buoi 3.

## Cau truc project

```
Lab03_QuanLySinhVienOOP/
|-- Nguoi.cs                       # Class cha: HoTen, NgaySinh, LayThongTin()
|-- SinhVien.cs                    # Ke thua Nguoi: MaSinhVien, MaLop, DiemTrungBinh (0-10), XepLoai()
|-- QuanLySinhVien.cs              # Quan ly List<SinhVien>: Them/Sua/Xoa/Tim/SapXep/Loc
|-- Program.cs                     # Menu va luong nhap lieu, khong xu ly danh sach truc tiep
|-- Lab03_QuanLySinhVienOOP.csproj # File project .NET
```

## Yeu cau he thong

- .NET SDK 8.0 tro len
- Visual Studio 2022 (hoac VS Code + C# extension)

## Cach chay

### Bang Visual Studio
1. Mo `Lab03_QuanLySinhVienOOP.csproj` bang Visual Studio.
2. Nhan `F5` hoac `Ctrl+F5` de build va chay.

### Bang dong lenh (.NET CLI)
```bash
cd Lab03_QuanLySinhVienOOP
dotnet run
```

## Chuc nang menu

| Chon | Chuc nang |
|------|-----------|
| 1 | Them sinh vien (kiem tra ma trung) |
| 2 | Xuat toan bo danh sach |
| 3 | Tim theo ma sinh vien |
| 4 | Tim theo ten (chua tu khoa) |
| 5 | Sua diem trung binh |
| 6 | Xoa sinh vien theo ma |
| 7 | Sap xep giam dan theo diem (LINQ) |
| 8 | Loc sinh vien co diem >= 5 (LINQ) |
| 0 | Thoat |

## Ghi chu ky thuat

- `DiemTrungBinh` la property tu kiem tra gia tri, chi nhan 0-10; nhap sai se duoc yeu cau nhap lai (khong crash).
- Nhap ngay sinh theo dinh dang `dd/MM/yyyy`; nhap sai dinh dang se duoc yeu cau nhap lai.
- `Program.cs` chi dieu khien luong va goi `QuanLySinhVien`, khong thao tac truc tiep tren `List<SinhVien>`.
- LINQ duoc dung trong `TimTheoMa`, `TimTheoTen`, `SapXepTheoDiem`, `LocSinhVienDat`.
