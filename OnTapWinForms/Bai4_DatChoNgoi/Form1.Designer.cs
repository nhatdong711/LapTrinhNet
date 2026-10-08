using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bai4_DatChoNgoi
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpSoDo = new GroupBox();
            tlpSoDo = new TableLayoutPanel();
            lblManHinh = new Label();
            pnlChuThich = new FlowLayoutPanel();
            lblCtTrong = new Label();
            lblCtDangChon = new Label();
            lblCtDaDat = new Label();
            grpThongKe = new GroupBox();
            lblKhungGio = new Label();
            cboKhungGio = new ComboBox();
            lblSoViTriTitle = new Label();
            lblSoViTri = new Label();
            lblTamTinhTitle = new Label();
            lblTamTinh = new Label();
            lblDanhSachTitle = new Label();
            lblDanhSach = new Label();
            btnXacNhan = new Button();
            btnHuyChon = new Button();
            grpSoDo.SuspendLayout();
            pnlChuThich.SuspendLayout();
            grpThongKe.SuspendLayout();
            SuspendLayout();
            grpSoDo.Controls.Add(lblManHinh);
            grpSoDo.Controls.Add(tlpSoDo);
            grpSoDo.Controls.Add(pnlChuThich);
            grpSoDo.Location = new Point(12, 12);
            grpSoDo.Name = "grpSoDo";
            grpSoDo.Size = new Size(520, 420);
            grpSoDo.TabIndex = 0;
            grpSoDo.TabStop = false;
            grpSoDo.Text = "Sơ đồ vị trí (4 hàng × 5 cột)";
            lblManHinh.BackColor = Color.DimGray;
            lblManHinh.ForeColor = Color.White;
            lblManHinh.Location = new Point(15, 28);
            lblManHinh.Name = "lblManHinh";
            lblManHinh.Size = new Size(490, 26);
            lblManHinh.Text = "QUẦY / SÂN KHẤU";
            lblManHinh.TextAlign = ContentAlignment.MiddleCenter;
            tlpSoDo.ColumnCount = 5;
            tlpSoDo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSoDo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSoDo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSoDo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSoDo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSoDo.Location = new Point(15, 64);
            tlpSoDo.Name = "tlpSoDo";
            tlpSoDo.RowCount = 4;
            tlpSoDo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSoDo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSoDo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSoDo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSoDo.Size = new Size(490, 300);
            tlpSoDo.TabIndex = 0;
            pnlChuThich.Controls.Add(lblCtTrong);
            pnlChuThich.Controls.Add(lblCtDangChon);
            pnlChuThich.Controls.Add(lblCtDaDat);
            pnlChuThich.Location = new Point(15, 375);
            pnlChuThich.Name = "pnlChuThich";
            pnlChuThich.Size = new Size(490, 32);
            lblCtTrong.BackColor = Color.WhiteSmoke;
            lblCtTrong.BorderStyle = BorderStyle.FixedSingle;
            lblCtTrong.Margin = new Padding(0, 0, 10, 0);
            lblCtTrong.Name = "lblCtTrong";
            lblCtTrong.Size = new Size(150, 28);
            lblCtTrong.Text = "Trống";
            lblCtTrong.TextAlign = ContentAlignment.MiddleCenter;
            lblCtDangChon.BackColor = Color.LimeGreen;
            lblCtDangChon.BorderStyle = BorderStyle.FixedSingle;
            lblCtDangChon.ForeColor = Color.White;
            lblCtDangChon.Margin = new Padding(0, 0, 10, 0);
            lblCtDangChon.Name = "lblCtDangChon";
            lblCtDangChon.Size = new Size(150, 28);
            lblCtDangChon.Text = "Đang chọn";
            lblCtDangChon.TextAlign = ContentAlignment.MiddleCenter;
            lblCtDaDat.BackColor = Color.Crimson;
            lblCtDaDat.BorderStyle = BorderStyle.FixedSingle;
            lblCtDaDat.ForeColor = Color.White;
            lblCtDaDat.Margin = new Padding(0);
            lblCtDaDat.Name = "lblCtDaDat";
            lblCtDaDat.Size = new Size(150, 28);
            lblCtDaDat.Text = "Đã đặt / Đã khóa";
            lblCtDaDat.TextAlign = ContentAlignment.MiddleCenter;
            grpThongKe.Controls.Add(lblKhungGio);
            grpThongKe.Controls.Add(cboKhungGio);
            grpThongKe.Controls.Add(lblSoViTriTitle);
            grpThongKe.Controls.Add(lblSoViTri);
            grpThongKe.Controls.Add(lblTamTinhTitle);
            grpThongKe.Controls.Add(lblTamTinh);
            grpThongKe.Controls.Add(lblDanhSachTitle);
            grpThongKe.Controls.Add(lblDanhSach);
            grpThongKe.Controls.Add(btnXacNhan);
            grpThongKe.Controls.Add(btnHuyChon);
            grpThongKe.Location = new Point(545, 12);
            grpThongKe.Name = "grpThongKe";
            grpThongKe.Size = new Size(280, 420);
            grpThongKe.TabIndex = 1;
            grpThongKe.TabStop = false;
            grpThongKe.Text = "Thống kê";
            lblKhungGio.AutoSize = true;
            lblKhungGio.Location = new Point(15, 32);
            lblKhungGio.Name = "lblKhungGio";
            lblKhungGio.Size = new Size(75, 20);
            lblKhungGio.Text = "Khung giờ:";
            cboKhungGio.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhungGio.Items.AddRange(new object[] { "Sáng - 100.000đ / vị trí", "Tối - 150.000đ / vị trí" });
            cboKhungGio.Location = new Point(15, 56);
            cboKhungGio.Name = "cboKhungGio";
            cboKhungGio.Size = new Size(250, 28);
            cboKhungGio.TabIndex = 0;
            cboKhungGio.SelectedIndexChanged += cboKhungGio_SelectedIndexChanged;
            lblSoViTriTitle.AutoSize = true;
            lblSoViTriTitle.Location = new Point(15, 102);
            lblSoViTriTitle.Name = "lblSoViTriTitle";
            lblSoViTriTitle.Size = new Size(140, 20);
            lblSoViTriTitle.Text = "Số vị trí đang chọn:";
            lblSoViTri.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSoViTri.ForeColor = Color.ForestGreen;
            lblSoViTri.Location = new Point(165, 96);
            lblSoViTri.Name = "lblSoViTri";
            lblSoViTri.Size = new Size(100, 30);
            lblSoViTri.Text = "0";
            lblSoViTri.TextAlign = ContentAlignment.MiddleRight;
            lblTamTinhTitle.AutoSize = true;
            lblTamTinhTitle.Location = new Point(15, 140);
            lblTamTinhTitle.Name = "lblTamTinhTitle";
            lblTamTinhTitle.Size = new Size(110, 20);
            lblTamTinhTitle.Text = "Tạm tính tiền:";
            lblTamTinh.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTamTinh.ForeColor = Color.Firebrick;
            lblTamTinh.Location = new Point(115, 134);
            lblTamTinh.Name = "lblTamTinh";
            lblTamTinh.Size = new Size(150, 30);
            lblTamTinh.Text = "0 đ";
            lblTamTinh.TextAlign = ContentAlignment.MiddleRight;
            lblDanhSachTitle.AutoSize = true;
            lblDanhSachTitle.Location = new Point(15, 178);
            lblDanhSachTitle.Name = "lblDanhSachTitle";
            lblDanhSachTitle.Size = new Size(110, 20);
            lblDanhSachTitle.Text = "Vị trí đã chọn:";
            lblDanhSach.BorderStyle = BorderStyle.FixedSingle;
            lblDanhSach.Location = new Point(15, 202);
            lblDanhSach.Name = "lblDanhSach";
            lblDanhSach.Size = new Size(250, 95);
            lblDanhSach.Text = "(chưa chọn)";
            btnXacNhan.BackColor = Color.FromArgb(0, 120, 215);
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Location = new Point(15, 315);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(250, 42);
            btnXacNhan.TabIndex = 1;
            btnXacNhan.Text = "Xác nhận đặt";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            btnHuyChon.Location = new Point(15, 365);
            btnHuyChon.Name = "btnHuyChon";
            btnHuyChon.Size = new Size(250, 38);
            btnHuyChon.TabIndex = 2;
            btnHuyChon.Text = "Hủy chọn tất cả";
            btnHuyChon.UseVisualStyleBackColor = true;
            btnHuyChon.Click += btnHuyChon_Click;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 445);
            Controls.Add(grpSoDo);
            Controls.Add(grpThongKe);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 4 - Sơ đồ chọn vị trí / Đặt bàn theo khung giờ";
            Load += Form1_Load;
            grpSoDo.ResumeLayout(false);
            pnlChuThich.ResumeLayout(false);
            grpThongKe.ResumeLayout(false);
            grpThongKe.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSoDo;
        private TableLayoutPanel tlpSoDo;
        private Label lblManHinh;
        private FlowLayoutPanel pnlChuThich;
        private Label lblCtTrong;
        private Label lblCtDangChon;
        private Label lblCtDaDat;
        private GroupBox grpThongKe;
        private Label lblKhungGio;
        private ComboBox cboKhungGio;
        private Label lblSoViTriTitle;
        private Label lblSoViTri;
        private Label lblTamTinhTitle;
        private Label lblTamTinh;
        private Label lblDanhSachTitle;
        private Label lblDanhSach;
        private Button btnXacNhan;
        private Button btnHuyChon;
    }
}
