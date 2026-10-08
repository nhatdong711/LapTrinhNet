using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bai3_QuanLyVatTu
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
            grpNhapLieu = new GroupBox();
            lblMaVT = new Label();
            txtMaVT = new TextBox();
            lblTenVT = new Label();
            txtTenVT = new TextBox();
            lblDVT = new Label();
            cboDonViTinh = new ComboBox();
            lblDonGia = new Label();
            txtDonGia = new TextBox();
            btnThem = new Button();
            btnCapNhat = new Button();
            btnXoaDong = new Button();
            btnXoaTatCa = new Button();
            grpDanhSach = new GroupBox();
            lvVatTu = new ListView();
            colMaVT = new ColumnHeader();
            colTenVT = new ColumnHeader();
            colDVT = new ColumnHeader();
            colDonGia = new ColumnHeader();
            lblSoLuong = new Label();
            grpNhapLieu.SuspendLayout();
            grpDanhSach.SuspendLayout();
            SuspendLayout();
            grpNhapLieu.Controls.Add(lblMaVT);
            grpNhapLieu.Controls.Add(txtMaVT);
            grpNhapLieu.Controls.Add(lblTenVT);
            grpNhapLieu.Controls.Add(txtTenVT);
            grpNhapLieu.Controls.Add(lblDVT);
            grpNhapLieu.Controls.Add(cboDonViTinh);
            grpNhapLieu.Controls.Add(lblDonGia);
            grpNhapLieu.Controls.Add(txtDonGia);
            grpNhapLieu.Controls.Add(btnThem);
            grpNhapLieu.Controls.Add(btnCapNhat);
            grpNhapLieu.Controls.Add(btnXoaDong);
            grpNhapLieu.Controls.Add(btnXoaTatCa);
            grpNhapLieu.Location = new Point(12, 12);
            grpNhapLieu.Name = "grpNhapLieu";
            grpNhapLieu.Size = new Size(320, 400);
            grpNhapLieu.TabIndex = 0;
            grpNhapLieu.TabStop = false;
            grpNhapLieu.Text = "Thông tin vật tư";
            lblMaVT.AutoSize = true;
            lblMaVT.Location = new Point(15, 35);
            lblMaVT.Name = "lblMaVT";
            lblMaVT.Size = new Size(85, 20);
            lblMaVT.Text = "Mã vật tư:";
            txtMaVT.CharacterCasing = CharacterCasing.Upper;
            txtMaVT.Location = new Point(120, 32);
            txtMaVT.Name = "txtMaVT";
            txtMaVT.Size = new Size(185, 27);
            txtMaVT.TabIndex = 0;
            lblTenVT.AutoSize = true;
            lblTenVT.Location = new Point(15, 75);
            lblTenVT.Name = "lblTenVT";
            lblTenVT.Size = new Size(85, 20);
            lblTenVT.Text = "Tên vật tư:";
            txtTenVT.Location = new Point(120, 72);
            txtTenVT.Name = "txtTenVT";
            txtTenVT.Size = new Size(185, 27);
            txtTenVT.TabIndex = 1;
            lblDVT.AutoSize = true;
            lblDVT.Location = new Point(15, 115);
            lblDVT.Name = "lblDVT";
            lblDVT.Size = new Size(85, 20);
            lblDVT.Text = "Đơn vị tính:";
            cboDonViTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDonViTinh.Items.AddRange(new object[] { "Cái", "Bộ", "Kg", "Mét" });
            cboDonViTinh.Location = new Point(120, 112);
            cboDonViTinh.Name = "cboDonViTinh";
            cboDonViTinh.Size = new Size(185, 28);
            cboDonViTinh.TabIndex = 2;
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(15, 155);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(100, 20);
            lblDonGia.Text = "Đơn giá nhập:";
            txtDonGia.Location = new Point(120, 152);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(185, 27);
            txtDonGia.TabIndex = 3;
            txtDonGia.TextAlign = HorizontalAlignment.Right;
            btnThem.Location = new Point(15, 210);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(140, 38);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            btnCapNhat.Location = new Point(165, 210);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(140, 38);
            btnCapNhat.TabIndex = 5;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            btnXoaDong.Location = new Point(15, 258);
            btnXoaDong.Name = "btnXoaDong";
            btnXoaDong.Size = new Size(140, 38);
            btnXoaDong.TabIndex = 6;
            btnXoaDong.Text = "Xóa dòng";
            btnXoaDong.UseVisualStyleBackColor = true;
            btnXoaDong.Click += btnXoaDong_Click;
            btnXoaTatCa.ForeColor = Color.Firebrick;
            btnXoaTatCa.Location = new Point(165, 258);
            btnXoaTatCa.Name = "btnXoaTatCa";
            btnXoaTatCa.Size = new Size(140, 38);
            btnXoaTatCa.TabIndex = 7;
            btnXoaTatCa.Text = "Xóa toàn bộ";
            btnXoaTatCa.UseVisualStyleBackColor = true;
            btnXoaTatCa.Click += btnXoaTatCa_Click;
            grpDanhSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDanhSach.Controls.Add(lvVatTu);
            grpDanhSach.Controls.Add(lblSoLuong);
            grpDanhSach.Location = new Point(345, 12);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(540, 400);
            grpDanhSach.TabIndex = 1;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách vật tư";
            lvVatTu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvVatTu.Columns.AddRange(new ColumnHeader[] { colMaVT, colTenVT, colDVT, colDonGia });
            lvVatTu.FullRowSelect = true;
            lvVatTu.GridLines = true;
            lvVatTu.HideSelection = false;
            lvVatTu.Location = new Point(15, 30);
            lvVatTu.MultiSelect = false;
            lvVatTu.Name = "lvVatTu";
            lvVatTu.Size = new Size(510, 330);
            lvVatTu.TabIndex = 0;
            lvVatTu.UseCompatibleStateImageBehavior = false;
            lvVatTu.View = View.Details;
            lvVatTu.SelectedIndexChanged += lvVatTu_SelectedIndexChanged;
            colMaVT.Text = "Mã VT";
            colMaVT.Width = 90;
            colTenVT.Text = "Tên VT";
            colTenVT.Width = 200;
            colDVT.Text = "Đơn vị tính";
            colDVT.Width = 95;
            colDonGia.Text = "Đơn giá";
            colDonGia.TextAlign = HorizontalAlignment.Right;
            colDonGia.Width = 110;
            lblSoLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(15, 368);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(120, 20);
            lblSoLuong.Text = "Tổng số: 0 vật tư";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 425);
            Controls.Add(grpNhapLieu);
            Controls.Add(grpDanhSach);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(918, 472);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 3 - Quản lý danh mục Vật tư / Linh kiện";
            Load += Form1_Load;
            grpNhapLieu.ResumeLayout(false);
            grpNhapLieu.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            grpDanhSach.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpNhapLieu;
        private Label lblMaVT;
        private TextBox txtMaVT;
        private Label lblTenVT;
        private TextBox txtTenVT;
        private Label lblDVT;
        private ComboBox cboDonViTinh;
        private Label lblDonGia;
        private TextBox txtDonGia;
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoaDong;
        private Button btnXoaTatCa;
        private GroupBox grpDanhSach;
        private ListView lvVatTu;
        private ColumnHeader colMaVT;
        private ColumnHeader colTenVT;
        private ColumnHeader colDVT;
        private ColumnHeader colDonGia;
        private Label lblSoLuong;
    }
}
