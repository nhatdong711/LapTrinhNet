using System;
using System.Text;
 
class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
 
        Console.Write("Nhập hệ số a: ");
        double a = double.Parse(Console.ReadLine());
 
        Console.Write("Nhập hệ số b: ");
        double b = double.Parse(Console.ReadLine());
 
        Console.Write("Nhập hệ số c: ");
        double c = double.Parse(Console.ReadLine());
 
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
}
