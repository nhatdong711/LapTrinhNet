using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bai3_QuanLyVatTu
{
    public partial class Form1 : Form
    {
        private static readonly CultureInfo VN = new CultureInfo("vi-VN");

        private readonly List<VatTu> dsVatTu = new List<VatTu>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dsVatTu.Add(new VatTu { MaVT = "VT001", TenVT = "Ốc vít M4", DonViTinh = "Bộ", DonGia = 15000 });
            dsVatTu.Add(new VatTu { MaVT = "VT002", TenVT = "Dây điện 2.5mm", DonViTinh = "Mét", DonGia = 8500 });
            dsVatTu.Add(new VatTu { MaVT = "VT003", TenVT = "RAM DDR4 8GB", DonViTinh = "Cái", DonGia = 650000 });
            HienThiDanhSach();
            LamMoiONhap();
        }

        private void HienThiDanhSach(string maChon = null)
        {
            lvVatTu.BeginUpdate();
            lvVatTu.Items.Clear();
            foreach (VatTu vt in dsVatTu)
            {
                ListViewItem item = new ListViewItem(vt.MaVT);
                item.SubItems.Add(vt.TenVT);
                item.SubItems.Add(vt.DonViTinh);
                item.SubItems.Add(vt.DonGia.ToString("N0", VN));
                item.Tag = vt;
                lvVatTu.Items.Add(item);

                if (maChon != null && vt.MaVT == maChon)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                }
            }
            lvVatTu.EndUpdate();
            lblSoLuong.Text = $"Tổng số: {dsVatTu.Count} vật tư";
        }

        private void LamMoiONhap()
        {
            txtMaVT.Clear();
            txtTenVT.Clear();
            cboDonViTinh.SelectedIndex = 0;
            txtDonGia.Clear();
            txtMaVT.Focus();
        }

        private void lvVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvVatTu.SelectedItems.Count == 0) return;
            VatTu vt = (VatTu)lvVatTu.SelectedItems[0].Tag;
            txtMaVT.Text = vt.MaVT;
            txtTenVT.Text = vt.TenVT;
            cboDonViTinh.SelectedItem = vt.DonViTinh;
            txtDonGia.Text = vt.DonGia.ToString("N0", VN);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            VatTu moi = DocDuLieuNhap();
            if (moi == null) return;

            if (dsVatTu.Any(v => v.MaVT.Equals(moi.MaVT, StringComparison.OrdinalIgnoreCase)))
            {
                ThongBaoLoi($"Mã vật tư \"{moi.MaVT}\" đã tồn tại trong danh sách!", txtMaVT);
                return;
            }

            dsVatTu.Add(moi);
            HienThiDanhSach(moi.MaVT);
            LamMoiONhap();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (lvVatTu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng trong danh sách để cập nhật.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VatTu dangChon = (VatTu)lvVatTu.SelectedItems[0].Tag;
            VatTu duLieu = DocDuLieuNhap();
            if (duLieu == null) return;

            if (dsVatTu.Any(v => v != dangChon &&
                                 v.MaVT.Equals(duLieu.MaVT, StringComparison.OrdinalIgnoreCase)))
            {
                ThongBaoLoi($"Mã vật tư \"{duLieu.MaVT}\" đã thuộc về vật tư khác!", txtMaVT);
                return;
            }

            dangChon.MaVT = duLieu.MaVT;
            dangChon.TenVT = duLieu.TenVT;
            dangChon.DonViTinh = duLieu.DonViTinh;
            dangChon.DonGia = duLieu.DonGia;
            HienThiDanhSach(dangChon.MaVT);
            MessageBox.Show("Cập nhật thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (lvVatTu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            VatTu vt = (VatTu)lvVatTu.SelectedItems[0].Tag;
            DialogResult kq = MessageBox.Show(
                $"Bạn có chắc muốn xóa vật tư \"{vt.MaVT} - {vt.TenVT}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                dsVatTu.Remove(vt);
                HienThiDanhSach();
                LamMoiONhap();
            }
        }

        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            if (dsVatTu.Count == 0) return;
            DialogResult kq = MessageBox.Show(
                $"Xóa toàn bộ {dsVatTu.Count} vật tư trong danh sách?",
                "Xác nhận xóa toàn bộ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (kq == DialogResult.Yes)
            {
                dsVatTu.Clear();
                HienThiDanhSach();
                LamMoiONhap();
            }
        }

        private VatTu DocDuLieuNhap()
        {
            string ma = txtMaVT.Text.Trim();
            string ten = txtTenVT.Text.Trim();

            if (ma == "") { ThongBaoLoi("Vui lòng nhập Mã vật tư.", txtMaVT); return null; }
            if (ten == "") { ThongBaoLoi("Vui lòng nhập Tên vật tư.", txtTenVT); return null; }
            if (cboDonViTinh.SelectedIndex < 0) { ThongBaoLoi("Vui lòng chọn Đơn vị tính.", cboDonViTinh); return null; }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), NumberStyles.Number, VN, out decimal gia) &&
                !decimal.TryParse(txtDonGia.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out gia))
            {
                ThongBaoLoi("Đơn giá nhập phải là số.", txtDonGia);
                return null;
            }
            if (gia <= 0) { ThongBaoLoi("Đơn giá nhập phải lớn hơn 0.", txtDonGia); return null; }

            return new VatTu { MaVT = ma, TenVT = ten, DonViTinh = cboDonViTinh.Text, DonGia = gia };
        }

        private static void ThongBaoLoi(string msg, Control focus)
        {
            MessageBox.Show(msg, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus.Focus();
        }
    }
}
