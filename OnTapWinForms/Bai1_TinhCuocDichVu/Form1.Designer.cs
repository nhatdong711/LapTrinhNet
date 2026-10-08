using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bai1_TinhCuocDichVu
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
            lblTieuDe = new Label();
            lblDonGia = new Label();
            txtDonGia = new TextBox();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            lblGiamGia = new Label();
            txtGiamGia = new TextBox();
            lblTongTienTitle = new Label();
            lblTongTien = new Label();
            btnTinhTien = new Button();
            btnLamMoi = new Button();
            SuspendLayout();
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(0, 84, 166);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(420, 35);
            lblTieuDe.TabIndex = 100;
            lblTieuDe.Text = "TÍNH CƯỚC DỊCH VỤ";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(30, 73);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(140, 20);
            lblDonGia.TabIndex = 101;
            lblDonGia.Text = "Đơn giá dịch vụ (đ):";
            txtDonGia.Location = new Point(200, 70);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(220, 27);
            txtDonGia.TabIndex = 0;
            txtDonGia.TextAlign = HorizontalAlignment.Right;
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(30, 113);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(110, 20);
            lblSoLuong.TabIndex = 102;
            lblSoLuong.Text = "Số lượng khách:";
            txtSoLuong.Location = new Point(200, 110);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(220, 27);
            txtSoLuong.TabIndex = 1;
            txtSoLuong.TextAlign = HorizontalAlignment.Right;
            lblGiamGia.AutoSize = true;
            lblGiamGia.Location = new Point(30, 153);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Size = new Size(150, 20);
            lblGiamGia.TabIndex = 103;
            lblGiamGia.Text = "Mã giảm giá (% giảm):";
            txtGiamGia.Location = new Point(200, 150);
            txtGiamGia.Name = "txtGiamGia";
            txtGiamGia.Size = new Size(220, 27);
            txtGiamGia.TabIndex = 2;
            txtGiamGia.TextAlign = HorizontalAlignment.Right;
            lblTongTienTitle.AutoSize = true;
            lblTongTienTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongTienTitle.Location = new Point(30, 203);
            lblTongTienTitle.Name = "lblTongTienTitle";
            lblTongTienTitle.Size = new Size(160, 23);
            lblTongTienTitle.TabIndex = 104;
            lblTongTienTitle.Text = "Tổng tiền thanh toán:";
            lblTongTien.BorderStyle = BorderStyle.FixedSingle;
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.Firebrick;
            lblTongTien.Location = new Point(200, 196);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(220, 36);
            lblTongTien.TabIndex = 105;
            lblTongTien.Text = "0 đ";
            lblTongTien.TextAlign = ContentAlignment.MiddleRight;
            btnTinhTien.Location = new Point(200, 255);
            btnTinhTien.Name = "btnTinhTien";
            btnTinhTien.Size = new Size(105, 36);
            btnTinhTien.TabIndex = 3;
            btnTinhTien.Text = "&Tính tiền";
            btnTinhTien.UseVisualStyleBackColor = true;
            btnTinhTien.Click += btnTinhTien_Click;
            btnLamMoi.Location = new Point(315, 255);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(105, 36);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "&Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            AcceptButton = btnTinhTien;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 315);
            Controls.Add(lblTieuDe);
            Controls.Add(lblDonGia);
            Controls.Add(txtDonGia);
            Controls.Add(lblSoLuong);
            Controls.Add(txtSoLuong);
            Controls.Add(lblGiamGia);
            Controls.Add(txtGiamGia);
            Controls.Add(lblTongTienTitle);
            Controls.Add(lblTongTien);
            Controls.Add(btnTinhTien);
            Controls.Add(btnLamMoi);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 1 - Máy tính cước dịch vụ & Giảm giá";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblDonGia;
        private TextBox txtDonGia;
        private Label lblSoLuong;
        private TextBox txtSoLuong;
        private Label lblGiamGia;
        private TextBox txtGiamGia;
        private Label lblTongTienTitle;
        private Label lblTongTien;
        private Button btnTinhTien;
        private Button btnLamMoi;
    }
}
