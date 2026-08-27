using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        int luaChon;

        do
        {
            HienThiMenu();
            luaChon = NhapLuaChon();

            switch (luaChon)
            {
                case 1:
                    BaiTap1_Calculator();
                    break;
                case 2:
                    BaiTap2_PhuongTrinhBac2();
                    break;
                case 3:
                    BaiTap3_SoNguyenToFibonacci();
                    break;
                case 0:
                    Console.WriteLine("\nCảm ơn bạn đã sử dụng chương trình. Tạm biệt!");
                    break;
                default:
                    Console.WriteLine("\nLựa chọn không hợp lệ! Vui lòng chọn lại.");
                    break;
            }

            if (luaChon != 0)
            {
                Console.WriteLine("\nNhấn phím bất kỳ để quay lại Menu...");
                Console.ReadKey();
                Console.Clear();
            }

        } while (luaChon != 0);
    }

    static void HienThiMenu()
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("           CHƯƠNG TRÌNH BÀI TẬP        ");
        Console.WriteLine("=========================================");
        Console.WriteLine("1. Chạy Bài tập 1 (Calculator)");
        Console.WriteLine("2. Chạy Bài tập 2 (Phương trình bậc 2)");
        Console.WriteLine("3. Chạy Bài tập 3 (Số nguyên tố & Fibonacci)");
        Console.WriteLine("0. Thoát chương trình");
        Console.WriteLine("=========================================");
        Console.Write("Mời bạn chọn chức năng: ");
    }

    static int NhapLuaChon()
    {
        int luaChon;
        bool hopLe = int.TryParse(Console.ReadLine(), out luaChon);
        return hopLe ? luaChon : -1; 
    }

    static void BaiTap1_Calculator()
    {
        Console.Clear();
        Console.WriteLine("----- BÀI TẬP 1: CALCULATOR -----\n");

        Console.Write("Nhập số thứ nhất a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhập số thứ hai b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhập phép toán (+, -, *, /, %): ");
        char op = char.Parse(Console.ReadLine());

        string result = TinhToan(a, b, op);
        Console.WriteLine("\nKết quả: " + result);
    }

    static string TinhToan(double a, double b, char op)
    {
        try
        {
            double ketQua = op switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' when b == 0 => throw new DivideByZeroException(),
                '/' => a / b,
                '%' when b == 0 => throw new DivideByZeroException(),
                '%' => a % b,
                _ => throw new InvalidOperationException("Phép toán không hợp lệ!")
            };

            return $"{ketQua:F2}";
        }
        catch (DivideByZeroException)
        {
            return "Lỗi: Không thể chia cho 0!";
        }
        catch (InvalidOperationException ex)
        {
            return $"Lỗi: {ex.Message}";
        }
    }
    static void BaiTap2_PhuongTrinhBac2()
    {
        Console.Clear();
        Console.WriteLine("----- BÀI TẬP 2: GIẢI PHƯƠNG TRÌNH BẬC 2 -----\n");

        Console.Write("Nhập hệ số a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhập hệ số b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhập hệ số c: ");
        double c = double.Parse(Console.ReadLine());

        Console.WriteLine();
        GiaiPhuongTrinh(a, b, c);
    }

    static void GiaiPhuongTrinh(double a, double b, double c)
    {
        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                    Console.WriteLine("Phương trình vô số nghiệm.");
                else
                    Console.WriteLine("Phương trình vô nghiệm.");
            }
            else
            {
                double x = -c / b;
                Console.WriteLine($"Phương trình bậc nhất có nghiệm x = {x:F2}");
            }
        }
        else
        {
            double delta = b * b - 4 * a * c;

            if (delta > 0)
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"Phương trình có 2 nghiệm phân biệt: x1 = {x1:F2}, x2 = {x2:F2}");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Phương trình có nghiệm kép: x = {x:F2}");
            }
            else
            {
                Console.WriteLine("Phương trình vô nghiệm.");
            }
        }
    }

    static void BaiTap3_SoNguyenToFibonacci()
    {
        Console.Clear();
        Console.WriteLine("----- BÀI TẬP 3: SỐ NGUYÊN TỐ, SỐ HOÀN HẢO & FIBONACCI -----\n");

        Console.Write("Nhập số nguyên dương N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine();

        if (IsPerfectNumber(n))
            Console.WriteLine($"{n} là Số hoàn hảo!");
        else
            Console.WriteLine($"{n} KHÔNG là Số hoàn hảo!");

        if (IsPrime(n))
            Console.WriteLine($"{n} là Số nguyên tố.");
        else
            Console.WriteLine($"{n} KHÔNG là Số nguyên tố.");

        Console.Write($"Dãy Fibonacci {n} số: ");
        InFibonacci(n);
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;

        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    static bool IsPerfectNumber(int n)
    {
        if (n <= 1) return false;

        int tongUoc = 0;
        for (int i = 1; i < n; i++)
        {
            if (n % i == 0)
                tongUoc += i;
        }
        return tongUoc == n;
    }

    static void InFibonacci(int n)
    {
        long a = 0, b = 1;
        int count = 0;

        while (count < n)
        {
            Console.Write(a);
            if (count < n - 1)
                Console.Write(", ");

            long temp = a + b;
            a = b;
            b = temp;
            count++;
        }
        Console.WriteLine();
    }
}