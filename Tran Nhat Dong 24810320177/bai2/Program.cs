using System.Text;
using Bai2_QuanLyPhuongTien;

Console.OutputEncoding = Encoding.UTF8;


Console.WriteLine("=== TC01: Khởi tạo Ô tô có NamSanXuat = 1890 ===");
try
{
    OTo otoLoi = new OTo("OT00", "Kia", 1890, 750_000_000m, 5, 1.6);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"ArgumentException: {ex.Message}");
}


Console.WriteLine("\n=== TC02: Ô tô 7 chỗ, GiaGoc = 850,000,000 VNĐ ===");
OTo oto = new OTo("OT01", "Mazda", 2022, 850_000_000m, 7, 2.5);
Console.WriteLine($"Giá lăn bánh: {oto.TinhGiaLanBanh():N0} VNĐ");


Console.WriteLine("\n=== TC03: Xe máy 125cc, GiaGoc = 42,000,000 VNĐ ===");
XeMay xeMay = new XeMay("XM01", "Yamaha", 2025, 42_000_000m, 125);
Console.WriteLine($"Giá lăn bánh: {xeMay.TinhGiaLanBanh():N0} VNĐ");


Console.WriteLine("\n=== TC04: Đa hình List<PhuongTien> ===");
List<PhuongTien> list = new List<PhuongTien> { oto, xeMay };
foreach (PhuongTien pt in list)
{
    Console.WriteLine($"{pt.GetType().Name} - {pt.MaPT}: {pt.TinhGiaLanBanh():N0} VNĐ");
}


Console.WriteLine("\n=== TC05: FindMaxGiaLanBanh() ===");
QuanLyPhuongTien ql = new QuanLyPhuongTien();
ql.AddPhuongTien(oto);
ql.AddPhuongTien(xeMay);
ql.DisplayAll();
PhuongTien? max = ql.FindMaxGiaLanBanh();
Console.WriteLine($"Giá lăn bánh cao nhất: {max?.GetInfo()} | {max?.TinhGiaLanBanh():N0} VNĐ");
