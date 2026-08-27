using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Nhập số thứ nhất a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhập số thứ hai b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhập phép toán (+, -, *, /, %): ");
        char op = char.Parse(Console.ReadLine());

        string result = TinhToan(a, b, op);
        Console.WriteLine(result);
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
}