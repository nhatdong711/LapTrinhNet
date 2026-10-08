using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai5_QuanLyDonGiaoHang
{
    public partial class Form1 : Form
    {
        private static readonly CultureInfo VN = new CultureInfo("vi-VN");

        public Form1()
        {
            InitializeComponent();
            CauHinhLuoi();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerDongHo.Start();
            CapNhatDongHo();
            TaoDonMoi();

            ThemDong("Bàn phím cơ", 2, 1.2m, 850000m);
            ThemDong("Màn hình 24 inch", 1, 4.5m, 3200000m);
            CapNhatTongCong();
        }

        private void CauHinhLuoi()
        {
            colSoLuong.ValueType = typeof(int);
            colTrongLuong.ValueType = typeof(decimal);
            colDonGia.ValueType = typeof(decimal);
            colThanhTien.ValueType = typeof(decimal);

            foreach (DataGridViewColumn c in new DataGridViewColumn[] { colSoLuong, colTrongLuong, colDonGia, colThanhTien })
            {
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                c.DefaultCellStyle.FormatProvider = VN;
            }
            colTrongLuong.DefaultCellStyle.Format = "0.##";
            colDonGia.DefaultCellStyle.Format = "N0";
            colThanhTien.DefaultCellStyle.Format = "N0";
            colThanhTien.DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            colThanhTien.DefaultCellStyle.Font = new Font(dgvHangHoa.Font, FontStyle.Bold);
        }

        private void timerDongHo_Tick(object sender, EventArgs e) => CapNhatDongHo();

        private void CapNhatDongHo()
        {
            lblThoiGian.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                ThemDongMoiTrenLuoi();
                return true;
            }

            if (keyData == Keys.Delete && dgvHangHoa.Focused && !dgvHangHoa.IsCurrentCellInEditMode)
            {
                XoaDongDangChon();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ThemDongMoiTrenLuoi()
        {
            dgvHangHoa.EndEdit();
            int idx = ThemDong("", 1, 1m, 0m);
            dgvHangHoa.Focus();
            dgvHangHoa.CurrentCell = dgvHangHoa.Rows[idx].Cells[colTenHang.Index];
            dgvHangHoa.BeginEdit(true);
        }

        private void XoaDongDangChon()
        {
            DataGridViewRow row = dgvHangHoa.CurrentRow;
            if (row == null) return;

            string ten = Convert.ToString(row.Cells[colTenHang.Index].Value);
            if (string.IsNullOrWhiteSpace(ten)) ten = "(chưa đặt tên)";

            if (MessageBox.Show($"Xóa dòng hàng \"{ten}\"?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvHangHoa.Rows.Remove(row);
            }
        }

        private void dgvHangHoa_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];
            string text = Convert.ToString(e.FormattedValue).Trim();

            if (e.ColumnIndex == colSoLuong.Index)
            {
                if (!int.TryParse(text, NumberStyles.Integer, VN, out _))
                {
                    row.ErrorText = "Số lượng phải là số nguyên.";
                    e.Cancel = true;
                }
            }
            else if (e.ColumnIndex == colTrongLuong.Index || e.ColumnIndex == colDonGia.Index)
            {
                if (!decimal.TryParse(text, NumberStyles.Number, VN, out _))
                {
                    row.ErrorText = $"{dgvHangHoa.Columns[e.ColumnIndex].HeaderText} phải là số.";
                    e.Cancel = true;
                }
            }

            if (!e.Cancel) row.ErrorText = "";
        }

        private void dgvHangHoa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == colThanhTien.Index) return;
            TinhLaiDong(dgvHangHoa.Rows[e.RowIndex]);
            CapNhatTongCong();
        }

        private void dgvHangHoa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) => CapNhatTongCong();

        private void dgvHangHoa_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) => CapNhatTongCong();

        private void dgvHangHoa_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgvHangHoa.Rows[e.RowIndex].ErrorText = "Giá trị không hợp lệ.";
            e.Cancel = true;
        }

        private int ThemDong(string ten, int soLuong, decimal trongLuong, decimal donGia)
        {
            int idx = dgvHangHoa.Rows.Add(ten, soLuong, trongLuong, donGia, 0m);
            TinhLaiDong(dgvHangHoa.Rows[idx]);
            return idx;
        }

        private void TinhLaiDong(DataGridViewRow row)
        {
            int sl = LayInt(row.Cells[colSoLuong.Index].Value);
            decimal kl = LayDecimal(row.Cells[colTrongLuong.Index].Value);
            decimal gia = LayDecimal(row.Cells[colDonGia.Index].Value);

            row.Cells[colSoLuong.Index].ErrorText = sl <= 0 ? "Số lượng phải > 0" : "";
            row.Cells[colTrongLuong.Index].ErrorText = kl <= 0 ? "Trọng lượng phải > 0" : "";
            row.Cells[colDonGia.Index].ErrorText = gia < 0 ? "Đơn giá không được âm" : "";

            row.Cells[colThanhTien.Index].Value = sl * gia;
        }

        private void CapNhatTongCong()
        {
            int tongSL = 0;
            decimal tongKL = 0, tongTien = 0;
            int soDongLoi = 0;

            foreach (DataGridViewRow row in dgvHangHoa.Rows)
            {
                int sl = LayInt(row.Cells[colSoLuong.Index].Value);
                decimal kl = LayDecimal(row.Cells[colTrongLuong.Index].Value);
                if (sl <= 0 || kl <= 0) soDongLoi++;

                tongSL += Math.Max(sl, 0);
                tongKL += Math.Max(kl, 0);
                tongTien += LayDecimal(row.Cells[colThanhTien.Index].Value);
            }

            lblTongSL.Text = $"Tổng SL: {tongSL.ToString("N0", VN)}";
            lblTongKL.Text = $"Tổng KL: {tongKL.ToString("0.##", VN)} kg";
            lblTongTien.Text = $"Tổng tiền: {tongTien.ToString("N0", VN)} đ";

            errorProvider.SetError(dgvHangHoa,
                soDongLoi > 0 ? $"Có {soDongLoi} dòng có Số lượng hoặc Trọng lượng ≤ 0" : "");
        }

        private static int LayInt(object v)
        {
            if (v == null || v == DBNull.Value) return 0;
            return int.TryParse(Convert.ToString(v, VN), NumberStyles.Integer, VN, out int r) ? r : 0;
        }

        private static decimal LayDecimal(object v)
        {
            if (v == null || v == DBNull.Value) return 0;
            if (v is decimal d) return d;
            return decimal.TryParse(Convert.ToString(v, VN), NumberStyles.Number, VN, out decimal r) ? r : 0;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e) => KiemTraSoLuong();
        private void txtTrongLuong_TextChanged(object sender, EventArgs e) => KiemTraTrongLuong();
        private void txtDonGia_TextChanged(object sender, EventArgs e) => KiemTraDonGia();

        private bool KiemTraSoLuong()
        {
            string s = txtSoLuong.Text.Trim();
            string loi = "";
            if (s == "") loi = "Vui lòng nhập số lượng";
            else if (!int.TryParse(s, NumberStyles.Integer, VN, out int sl)) loi = "Số lượng phải là số nguyên";
            else if (sl <= 0) loi = "Số lượng phải > 0";
            errorProvider.SetError(txtSoLuong, loi);
            return loi == "";
        }

        private bool KiemTraTrongLuong()
        {
            string s = txtTrongLuong.Text.Trim();
            string loi = "";
            if (s == "") loi = "Vui lòng nhập trọng lượng";
            else if (!decimal.TryParse(s, NumberStyles.Number, VN, out decimal kl)) loi = "Trọng lượng phải là số";
            else if (kl <= 0) loi = "Trọng lượng phải > 0";
            errorProvider.SetError(txtTrongLuong, loi);
            return loi == "";
        }

        private bool KiemTraDonGia()
        {
            string s = txtDonGia.Text.Trim();
            string loi = "";
            if (s == "") loi = "Vui lòng nhập đơn giá";
            else if (!decimal.TryParse(s, NumberStyles.Number, VN, out decimal g)) loi = "Đơn giá phải là số";
            else if (g < 0) loi = "Đơn giá không được âm";
            errorProvider.SetError(txtDonGia, loi);
            return loi == "";
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            bool okTen = !string.IsNullOrWhiteSpace(txtTenHang.Text);
            errorProvider.SetError(txtTenHang, okTen ? "" : "Vui lòng nhập tên hàng");

            bool okSL = KiemTraSoLuong();
            bool okKL = KiemTraTrongLuong();
            bool okGia = KiemTraDonGia();
            if (!(okTen && okSL && okKL && okGia)) return;

            ThemDong(txtTenHang.Text.Trim(),
                     int.Parse(txtSoLuong.Text.Trim(), NumberStyles.Integer, VN),
                     decimal.Parse(txtTrongLuong.Text.Trim(), NumberStyles.Number, VN),
                     decimal.Parse(txtDonGia.Text.Trim(), NumberStyles.Number, VN));
            CapNhatTongCong();
            XoaKhungThemNhanh();
            txtTenHang.Focus();
        }

        private void XoaKhungThemNhanh()
        {
            txtTenHang.Clear();
            txtSoLuong.Clear();
            txtTrongLuong.Clear();
            txtDonGia.Clear();
            errorProvider.SetError(txtTenHang, "");
            errorProvider.SetError(txtSoLuong, "");
            errorProvider.SetError(txtTrongLuong, "");
            errorProvider.SetError(txtDonGia, "");
        }

        private void btnLuuDon_Click(object sender, EventArgs e)
        {
            dgvHangHoa.EndEdit();

            bool okTen = !string.IsNullOrWhiteSpace(txtTenKH.Text);
            bool okSDT = System.Text.RegularExpressions.Regex.IsMatch(txtSDT.Text.Trim(), @"^0\d{9,10}$");
            errorProvider.SetError(txtTenKH, okTen ? "" : "Vui lòng nhập tên khách hàng");
            errorProvider.SetError(txtSDT, okSDT ? "" : "SĐT phải bắt đầu bằng 0 và có 10-11 chữ số");
            if (!okTen || !okSDT)
            {
                tabThongTin.SelectedTab = tabKhachHang;
                return;
            }

            if (dgvHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Đơn hàng chưa có mặt hàng nào. Nhấn F2 để thêm dòng.", "Thiếu hàng hóa",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvHangHoa.Rows)
            {
                bool loi = string.IsNullOrWhiteSpace(Convert.ToString(row.Cells[colTenHang.Index].Value))
                           || LayInt(row.Cells[colSoLuong.Index].Value) <= 0
                           || LayDecimal(row.Cells[colTrongLuong.Index].Value) <= 0;
                if (loi)
                {
                    dgvHangHoa.CurrentCell = row.Cells[colTenHang.Index];
                    MessageBox.Show($"Dòng {row.Index + 1} chưa hợp lệ (thiếu tên hàng hoặc SL/KL ≤ 0).",
                        "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Khách hàng : {txtTenKH.Text.Trim()} - {txtSDT.Text.Trim()}");
            sb.AppendLine($"Địa chỉ    : {txtDiaChi.Text.Trim()}");
            sb.AppendLine($"Vận chuyển : {cboLoaiVC.Text} - giao ngày {dtpNgayGiao.Value:dd/MM/yyyy}");
            sb.AppendLine($"Số mặt hàng: {dgvHangHoa.Rows.Count}");
            sb.AppendLine(lblTongSL.Text);
            sb.AppendLine(lblTongKL.Text);
            sb.AppendLine(lblTongTien.Text);
            MessageBox.Show(sb.ToString(), "Đã lưu đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDonMoi_Click(object sender, EventArgs e)
        {
            if (dgvHangHoa.Rows.Count > 0 &&
                MessageBox.Show("Tạo đơn mới sẽ xóa dữ liệu hiện tại. Tiếp tục?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            TaoDonMoi();
        }

        private void TaoDonMoi()
        {
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            cboLoaiVC.SelectedIndex = 0;
            dtpNgayGiao.Value = DateTime.Today.AddDays(3);
            txtGhiChu.Clear();
            dgvHangHoa.Rows.Clear();
            XoaKhungThemNhanh();
            errorProvider.Clear();
            tabThongTin.SelectedTab = tabKhachHang;
            CapNhatTongCong();
        }
    }
}
