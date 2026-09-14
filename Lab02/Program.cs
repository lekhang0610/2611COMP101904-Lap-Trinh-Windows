using System;

namespace Lab02_YeuCau
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = null;
            int choice;

            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Nhap mang");
                Console.WriteLine("2. Xuat mang");
                Console.WriteLine("3. Tinh tong");
                Console.WriteLine("4. Tim max/min");
                Console.WriteLine("5. Dem chan/le");
                Console.WriteLine("6. Sap xep tang dan");
                Console.WriteLine("7. Tim kiem");
                Console.WriteLine("0. Thoat");

                choice = NhapSoNguyen("Chon chuc nang: ");

                if (choice >= 2 && choice <= 7 && arr == null)
                {
                    Console.WriteLine("Vui long nhap mang truoc khi thuc hien chuc nang nay!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        arr = NhapMang();
                        break;
                    case 2:
                        Console.WriteLine("Cac phan tu cua mang:");
                        XuatMang(arr);
                        break;
                    case 3:
                        Console.WriteLine($"Tong cac phan tu trong mang = {TinhTong(arr)}");
                        break;
                    case 4:
                        Console.WriteLine($"Gia tri lon nhat (max) = {TimMax(arr)}");
                        Console.WriteLine($"Gia tri nho nhat (min) = {TimMin(arr)}");
                        break;
                    case 5:
                        Console.WriteLine($"So luong phan tu chan = {DemChan(arr)}");
                        Console.WriteLine($"So luong phan tu le = {DemLe(arr)}");
                        break;
                    case 6:
                        SapXepTangDan(arr);
                        Console.WriteLine("Mang sau khi sap xep tang dan:");
                        XuatMang(arr);
                        break;
                    case 7:
                        int x = NhapSoNguyen("Nhap gia tri x can tim: ");
                        int pos = TimKiem(arr, x);
                        if (pos != -1)
                            Console.WriteLine($"Co tim thay {x}, vi tri dau tien la {pos} neu tinh tu 0.");
                        else
                            Console.WriteLine($"Khong tim thay {x} trong mang.");
                        break;
                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai!");
                        break;
                }
            } while (choice != 0);
        }

        static int NhapSoNguyen(string message)
        {
            int result;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result))
                    return result;
                Console.WriteLine("Du lieu khong hop le. Vui long nhap mot so nguyen!");
            }
        }

        static int NhapSoNguyenDuong(string message)
        {
            int result;
            while (true)
            {
                result = NhapSoNguyen(message);
                if (result > 0)
                    return result;
                Console.WriteLine("Vui long nhap so nguyen duong lon hon 0!");
            }
        }

        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen($"Nhap phan tu a[{i}]: ");
            }
            return a;
        }

        static void XuatMang(int[] a)
        {
            foreach (int item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static int TinhTong(int[] a)
        {
            int sum = 0;
            foreach (int item in a)
            {
                sum += item;
            }
            return sum;
        }

        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
            }
            return max;
        }

        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min) min = a[i];
            }
            return min;
        }

        static int DemChan(int[] a)
        {
            int count = 0;
            foreach (int item in a)
            {
                if (item % 2 == 0) count++;
            }
            return count;
        }

        static int DemLe(int[] a)
        {
            int count = 0;
            foreach (int item in a)
            {
                if (item % 2 != 0) count++;
            }
            return count;
        }

        static void SapXepTangDan(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                    return i;
            }
            return -1;
        }
    }
}