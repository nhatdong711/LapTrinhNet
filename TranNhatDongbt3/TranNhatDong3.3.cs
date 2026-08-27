using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Nhập số nguyên dương N: ");
        int n = int.Parse(Console.ReadLine());

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