using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bai1_TinhCuocDichVu
{
    public partial class Form1 : Form
    {
        private static readonly CultureInfo VN = new CultureInfo("vi-VN");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (!TryReadDecimal(txtDonGia, "Đơn giá dịch vụ", out decimal donGia)) return;
            if (donGia < 0)
            {
                ShowError(txtDonGia, "Đơn giá dịch vụ không được âm.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                ShowError(txtSoLuong, "Vui lòng nhập Số lượng khách.");
                return;
            }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                ShowError(txtSoLuong, "Số lượng khách phải là số nguyên lớn hơn 0.");
                return;
            }

            decimal giam = 0;
            if (!string.IsNullOrWhiteSpace(txtGiamGia.Text))
            {
                if (!TryReadDecimal(txtGiamGia, "% giảm giá", out giam)) return;
                if (giam < 0 || giam > 100)
                {
                    ShowError(txtGiamGia, "% giảm giá phải nằm trong khoảng 0 đến 100.");
                    return;
                }
            }

            decimal tongTien = donGia * soLuong * (100 - giam) / 100;
            lblTongTien.Text = tongTien.ToString("N0", VN) + " đ";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            lblTongTien.Text = "0 đ";
            txtDonGia.Focus();
        }

        private bool TryReadDecimal(TextBox txt, string tenTruong, out decimal value)
        {
            value = 0;
            string s = txt.Text.Trim();
            if (string.IsNullOrEmpty(s))
            {
                ShowError(txt, $"Vui lòng nhập {tenTruong}.");
                return false;
            }
            if (!decimal.TryParse(s, NumberStyles.Number, VN, out value) &&
                !decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
            {
                ShowError(txt, $"{tenTruong} phải là số, không được chứa chữ.");
                return false;
            }
            return true;
        }

        private static void ShowError(TextBox txt, string message)
        {
            MessageBox.Show(message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txt.Focus();
            txt.SelectAll();
        }
    }
}
