using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bai4_DatChoNgoi
{
    public partial class Form1 : Form
    {
        private const int SO_HANG = 4;
        private const int SO_COT = 5;

        private static readonly CultureInfo VN = new CultureInfo("vi-VN");

        private static readonly Color MAU_TRONG = Color.WhiteSmoke;
        private static readonly Color MAU_DANG_CHON = Color.LimeGreen;
        private static readonly Color MAU_DA_DAT = Color.Crimson;

        private readonly decimal[] giaKhungGio = { 100000m, 150000m };

        private readonly Dictionary<int, HashSet<string>> daDatTheoKhungGio = new Dictionary<int, HashSet<string>>
        {
            { 0, new HashSet<string> { "A3", "B2", "C5" } },
            { 1, new HashSet<string> { "A1", "D4" } }
        };

        private readonly List<Button> dsNut = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tlpSoDo.SuspendLayout();
            for (int hang = 0; hang < SO_HANG; hang++)
            {
                for (int cot = 0; cot < SO_COT; cot++)
                {
                    string ma = $"{(char)('A' + hang)}{cot + 1}";
                    Button btn = new Button
                    {
                        Name = "btn" + ma,
                        Text = ma,
                        Dock = DockStyle.Fill,
                        Margin = new Padding(4),
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        Cursor = Cursors.Hand,
                        Tag = ma
                    };
                    btn.FlatAppearance.BorderColor = Color.Gray;

                    btn.Click += ViTri_Click;

                    tlpSoDo.Controls.Add(btn, cot, hang);
                    dsNut.Add(btn);
                }
            }
            tlpSoDo.ResumeLayout();

            cboKhungGio.SelectedIndex = 0;
        }

        private void ViTri_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.BackColor == MAU_DA_DAT)
            {
                MessageBox.Show($"Vị trí {btn.Text} đã có người đặt ở khung giờ này.", "Không thể chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btn.BackColor = (btn.BackColor == MAU_DANG_CHON) ? MAU_TRONG : MAU_DANG_CHON;
            btn.ForeColor = (btn.BackColor == MAU_DANG_CHON) ? Color.White : Color.Black;

            CapNhatThongKe();
        }

        private void cboKhungGio_SelectedIndexChanged(object sender, EventArgs e)
        {
            VeLaiSoDo();
            CapNhatThongKe();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            List<Button> dangChon = LayViTriDangChon();
            if (dangChon.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí nào.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal tong = dangChon.Count * giaKhungGio[cboKhungGio.SelectedIndex];
            string ds = string.Join(", ", dangChon.Select(b => b.Text));

            DialogResult kq = MessageBox.Show(
                $"Khung giờ: {cboKhungGio.Text}\nVị trí: {ds}\nSố lượng: {dangChon.Count}\n" +
                $"Thành tiền: {tong.ToString("N0", VN)} đ\n\nXác nhận đặt?",
                "Xác nhận đặt chỗ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq != DialogResult.Yes) return;

            HashSet<string> daDat = daDatTheoKhungGio[cboKhungGio.SelectedIndex];
            foreach (Button b in dangChon)
            {
                daDat.Add((string)b.Tag);
                DatTrangThaiDaDat(b);
            }
            CapNhatThongKe();
            MessageBox.Show("Đặt chỗ thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuyChon_Click(object sender, EventArgs e)
        {
            foreach (Button b in LayViTriDangChon())
            {
                b.BackColor = MAU_TRONG;
                b.ForeColor = Color.Black;
            }
            CapNhatThongKe();
        }

        private void VeLaiSoDo()
        {
            HashSet<string> daDat = daDatTheoKhungGio[cboKhungGio.SelectedIndex];
            foreach (Button b in dsNut)
            {
                if (daDat.Contains((string)b.Tag))
                {
                    DatTrangThaiDaDat(b);
                }
                else
                {
                    b.BackColor = MAU_TRONG;
                    b.ForeColor = Color.Black;
                    b.Cursor = Cursors.Hand;
                }
            }
        }

        private static void DatTrangThaiDaDat(Button b)
        {
            b.BackColor = MAU_DA_DAT;
            b.ForeColor = Color.White;
            b.Cursor = Cursors.No;
        }

        private List<Button> LayViTriDangChon()
        {
            return dsNut.Where(b => b.BackColor == MAU_DANG_CHON).ToList();
        }

        private void CapNhatThongKe()
        {
            List<Button> dangChon = LayViTriDangChon();
            decimal gia = cboKhungGio.SelectedIndex >= 0 ? giaKhungGio[cboKhungGio.SelectedIndex] : 0;

            lblSoViTri.Text = dangChon.Count.ToString();
            lblTamTinh.Text = (dangChon.Count * gia).ToString("N0", VN) + " đ";
            lblDanhSach.Text = dangChon.Count == 0 ? "(chưa chọn)" : string.Join(", ", dangChon.Select(b => b.Text));
        }
    }
}
