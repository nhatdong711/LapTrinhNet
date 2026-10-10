namespace Bai_5._2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            cboCategory = new ComboBox();
            label3 = new Label();
            lstAvailableServices = new ListBox();
            label4 = new Label();
            lstSelectedServices = new ListBox();
            btnSelect = new Button();
            btnRemove = new Button();
            btnClearAll = new Button();
            txtSubtotal = new TextBox();
            label5 = new Label();
            label6 = new Label();
            txtDiscount = new TextBox();
            label7 = new Label();
            txtTotal = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(82, 9);
            label1.Name = "label1";
            label1.Size = new Size(608, 31);
            label1.TabIndex = 0;
            label1.Text = "BẢNG TÍNH TIỀN DỊCH VỤ VÀ CHIẾT KHẤU ĐƠN HÀNG";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(228, 62);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 1;
            label2.Text = "Loại dịch vụ";
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(337, 62);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(151, 28);
            cboCategory.TabIndex = 2;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(184, 93);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 3;
            label3.Text = "Dịch vụ có sẵn";
            // 
            // lstAvailableServices
            // 
            lstAvailableServices.FormattingEnabled = true;
            lstAvailableServices.Location = new Point(184, 116);
            lstAvailableServices.Name = "lstAvailableServices";
            lstAvailableServices.Size = new Size(192, 144);
            lstAvailableServices.TabIndex = 4;
            lstAvailableServices.DoubleClick += lstAvailableServices_DoubleClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(382, 93);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 5;
            label4.Text = "Dịch vụ có sẵn";
            // 
            // lstSelectedServices
            // 
            lstSelectedServices.FormattingEnabled = true;
            lstSelectedServices.Location = new Point(382, 116);
            lstSelectedServices.Name = "lstSelectedServices";
            lstSelectedServices.Size = new Size(186, 144);
            lstSelectedServices.TabIndex = 6;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(222, 276);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(94, 29);
            btnSelect.TabIndex = 7;
            btnSelect.Text = ">";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(334, 276);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(94, 29);
            btnRemove.TabIndex = 8;
            btnRemove.Text = "<";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(443, 276);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(94, 29);
            btnClearAll.TabIndex = 9;
            btnClearAll.Text = "<<";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(382, 319);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.Size = new Size(125, 27);
            txtSubtotal.TabIndex = 10;
            txtSubtotal.TextChanged += txtSubtotal_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(228, 319);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 11;
            label5.Text = "Tổng tiền";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(228, 368);
            label6.Name = "label6";
            label6.Size = new Size(104, 20);
            label6.TabIndex = 12;
            label6.Text = "Chiết khấu (%)";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(382, 365);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(125, 27);
            txtDiscount.TabIndex = 13;
            txtDiscount.TextChanged += txtDiscount_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(228, 403);
            label7.Name = "label7";
            label7.Size = new Size(78, 20);
            label7.TabIndex = 14;
            label7.Text = "Thành tiền";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(382, 403);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(125, 27);
            txtTotal.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 450);
            Controls.Add(txtTotal);
            Controls.Add(label7);
            Controls.Add(txtDiscount);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtSubtotal);
            Controls.Add(btnClearAll);
            Controls.Add(btnRemove);
            Controls.Add(btnSelect);
            Controls.Add(lstSelectedServices);
            Controls.Add(label4);
            Controls.Add(lstAvailableServices);
            Controls.Add(label3);
            Controls.Add(cboCategory);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cboCategory;
        private Label label3;
        private ListBox lstAvailableServices;
        private Label label4;
        private ListBox lstSelectedServices;
        private Button btnSelect;
        private Button btnRemove;
        private Button btnClearAll;
        private TextBox txtSubtotal;
        private Label label5;
        private Label label6;
        private TextBox txtDiscount;
        private Label label7;
        private TextBox txtTotal;
    }
}
