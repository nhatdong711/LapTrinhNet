namespace Bai_5._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void HienThiNhanVien(string tenNhom)
        {
            lsvEmployees.Items.Clear();

            string[,] nhanVien =
            {
        { "NV01", "Lê Trung Hiếu", "Trưởng phòng", "01/03/2022", "Công ty" },
        { "NV02", "Trần Thị Thảo", "Nhân viên", "15/06/2023", "Phòng Kinh doanh" },
        { "NV03", "Lê Văn Cường", "Nhân viên bán hàng", "10/08/2023", "Nhóm Bán hàng" },
        { "NV04", "Phạm Huyền Trang", "Chăm sóc khách hàng", "20/01/2024", "Nhóm Chăm sóc khách hàng" },
        { "NV05", "Lê Văn Dũng", "Lập trình viên", "05/02/2022", "Phòng Kỹ thuật" },
        { "NV06", "Lê Huyền Trang", "Lập trình viên", "12/04/2024", "Nhóm Phần mềm" },
        { "NV07", "Lê Xuân Lộc", "Kỹ thuật viên", "18/09/2023", "Nhóm Hệ thống" }
    };

            for (int i = 0; i < nhanVien.GetLength(0); i++)
            {
                string phongBan = nhanVien[i, 4];

                if (tenNhom == "Công ty" ||
                    tenNhom == phongBan ||
                    (tenNhom == "Phòng Kinh doanh" &&
                     (phongBan == "Nhóm Bán hàng" ||
                      phongBan == "Nhóm Chăm sóc khách hàng")) ||
                    (tenNhom == "Phòng Kỹ thuật" &&
                     (phongBan == "Nhóm Phần mềm" ||
                      phongBan == "Nhóm Hệ thống")))
                {
                    ListViewItem item = new ListViewItem(nhanVien[i, 0]);

                    item.SubItems.Add(nhanVien[i, 1]);
                    item.SubItems.Add(nhanVien[i, 2]);
                    item.SubItems.Add(nhanVien[i, 3]);

                    lsvEmployees.Items.Add(item);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tạo cây phòng ban
            tvDepartments.Nodes.Clear();

            TreeNode congTy = new TreeNode("Công ty");

            TreeNode kinhDoanh = new TreeNode("Phòng Kinh doanh");
            kinhDoanh.Nodes.Add("Nhóm Bán hàng");
            kinhDoanh.Nodes.Add("Nhóm Chăm sóc khách hàng");

            TreeNode kyThuat = new TreeNode("Phòng Kỹ thuật");
            kyThuat.Nodes.Add("Nhóm Phần mềm");
            kyThuat.Nodes.Add("Nhóm Hệ thống");

            congTy.Nodes.Add(kinhDoanh);
            congTy.Nodes.Add(kyThuat);

            tvDepartments.Nodes.Add(congTy);
            tvDepartments.ExpandAll();

            // Các chế độ xem ListView
            cboView.Items.Add("Details");
            cboView.Items.Add("SmallIcon");
            cboView.Items.Add("LargeIcon");
            cboView.Items.Add("Tile");
            cboView.SelectedIndex = 0;

            // Tạo các cột ListView
            lsvEmployees.Columns.Clear();
            lsvEmployees.Columns.Add("Mã NV", 80);
            lsvEmployees.Columns.Add("Họ Tên", 150);
            lsvEmployees.Columns.Add("Chức vụ", 120);
            lsvEmployees.Columns.Add("Ngày vào làm", 120);

            // Gắn ImageList
            tvDepartments.ImageList = imgIcons;
            lsvEmployees.SmallImageList = imgIcons;
            lsvEmployees.LargeImageList = imgIcons;

            // Hiển thị dữ liệu ban đầu
            HienThiNhanVien("Công ty");
        }

        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            HienThiNhanVien(e.Node.Text);
        }

        private void cboView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboView.Text == "Details")
                lsvEmployees.View = View.Details;
            else if (cboView.Text == "SmallIcon")
                lsvEmployees.View = View.SmallIcon;
            else if (cboView.Text == "LargeIcon")
                lsvEmployees.View = View.LargeIcon;
            else if (cboView.Text == "Tile")
                lsvEmployees.View = View.Tile;
        }
    }
}
