namespace Bai2_QuanLyPhuongTien
{
   
    public class QuanLyPhuongTien
    {
        private readonly List<PhuongTien> _danhSach = new List<PhuongTien>();

 
        public void AddPhuongTien(PhuongTien pt)
        {
            _danhSach.Add(pt);
        }

    
        public void DisplayAll()
        {
            foreach (PhuongTien pt in _danhSach)
            {
                Console.WriteLine($"{pt.GetInfo()} | Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
            }
        }

      
        public PhuongTien? FindMaxGiaLanBanh()
        {
            PhuongTien? max = null;
            foreach (PhuongTien pt in _danhSach)
            {
                if (max == null || pt.TinhGiaLanBanh() > max.TinhGiaLanBanh())
                    max = pt;
            }
            return max;
        }

   
        public List<PhuongTien> SearchByName(string keyword)
        {
            return _danhSach
                .Where(pt => pt.TenHang.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
