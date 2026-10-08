using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai2_PhieuSuCoIT
{
    public partial class Form1 : Form
    {
        private string duongDanAnh = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NhapLai();
        }

        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Chọn ảnh chụp lỗi";
                dlg.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
                    using (var img = Image.FromStream(fs))
                    {
                        picAnhLoi.Image?.Dispose();
                        picAnhLoi.Image = new Bitmap(img);
                    }
                    picAnhLoi.SizeMode = PictureBoxSizeMode.StretchImage;
                    duongDanAnh = dlg.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không đọc được file ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text))
            {
                CanhBao("Vui lòng nhập Mã phiếu.", txtMaPhieu);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNguoiYeuCau.Text))
            {
                CanhBao("Vui lòng nhập Người yêu cầu.", txtNguoiYeuCau);
                return;
            }
            if (cboLoaiSuCo.SelectedIndex < 0)
            {
                CanhBao("Vui lòng chọn Loại sự cố.", cboLoaiSuCo);
                return;
            }

            List<string> thietBi = new List<string>();
            foreach (CheckBox chk in grpThietBi.Controls.OfType<CheckBox>().OrderBy(c => c.TabIndex))
            {
                if (chk.Checked) thietBi.Add(chk.Text);
            }
            if (thietBi.Count == 0)
            {
                CanhBao("Vui lòng chọn ít nhất 1 thiết bị bị ảnh hưởng.", chkMayTinhBan);
                return;
            }

            string uuTien = grpUuTien.Controls.OfType<RadioButton>()
                                 .First(r => r.Checked).Text;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===== PHIẾU YÊU CẦU HỖ TRỢ IT =====");
            sb.AppendLine($"Mã phiếu        : {txtMaPhieu.Text.Trim()}");
            sb.AppendLine($"Người yêu cầu   : {txtNguoiYeuCau.Text.Trim()}");
            sb.AppendLine($"Ngày ghi nhận   : {dtpNgayGhiNhan.Value:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Mức độ ưu tiên  : {uuTien}");
            sb.AppendLine($"Loại sự cố      : {cboLoaiSuCo.Text}");
            sb.AppendLine($"Thiết bị        : {string.Join(", ", thietBi)}");
            sb.AppendLine($"Mô tả           : {(string.IsNullOrWhiteSpace(txtMoTa.Text) ? "(không có)" : txtMoTa.Text.Trim())}");
            sb.AppendLine($"Ảnh lỗi         : {(duongDanAnh == "" ? "(chưa đính kèm)" : Path.GetFileName(duongDanAnh))}");

            MessageBox.Show(sb.ToString(), "Tóm tắt yêu cầu đã gửi",
                MessageBoxButtons.OK,
                rdoKhanCap.Checked ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            NhapLai();
        }

        private void NhapLai()
        {
            txtMaPhieu.Text = "SC" + DateTime.Now.ToString("yyMMddHHmmss");
            txtNguoiYeuCau.Clear();
            dtpNgayGhiNhan.Value = DateTime.Now;
            rdoTrungBinh.Checked = true;
            cboLoaiSuCo.SelectedIndex = -1;
            foreach (CheckBox chk in grpThietBi.Controls.OfType<CheckBox>())
                chk.Checked = false;
            txtMoTa.Clear();
            picAnhLoi.Image?.Dispose();
            picAnhLoi.Image = null;
            duongDanAnh = "";
            txtNguoiYeuCau.Focus();
        }

        private static void CanhBao(string message, Control focus)
        {
            MessageBox.Show(message, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus.Focus();
        }
    }
}
