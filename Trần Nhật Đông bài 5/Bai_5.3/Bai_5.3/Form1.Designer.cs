namespace Bai_5._3
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
            grpProduct = new GroupBox();
            cboCategory = new ComboBox();
            lblCategory = new Label();
            txtQuantity = new TextBox();
            lblQuantity = new Label();
            txtUnitPrice = new TextBox();
            lblUnitPrice = new Label();
            txtProductName = new TextBox();
            lblProductName = new Label();
            txtProductId = new TextBox();
            lblProductId = new Label();
            grpFunctions = new GroupBox();
            btnSearch = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvProducts = new DataGridView();
            grpProduct.SuspendLayout();
            grpFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(348, 9);
            label1.Name = "label1";
            label1.Size = new Size(384, 31);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ DANH SÁCH SẢN PHẨM";
            // 
            // grpProduct
            // 
            grpProduct.Controls.Add(cboCategory);
            grpProduct.Controls.Add(lblCategory);
            grpProduct.Controls.Add(txtQuantity);
            grpProduct.Controls.Add(lblQuantity);
            grpProduct.Controls.Add(txtUnitPrice);
            grpProduct.Controls.Add(lblUnitPrice);
            grpProduct.Controls.Add(txtProductName);
            grpProduct.Controls.Add(lblProductName);
            grpProduct.Controls.Add(txtProductId);
            grpProduct.Controls.Add(lblProductId);
            grpProduct.Location = new Point(27, 43);
            grpProduct.Name = "grpProduct";
            grpProduct.Size = new Size(334, 242);
            grpProduct.TabIndex = 1;
            grpProduct.TabStop = false;
            grpProduct.Text = "Thông tin sản phẩm";
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(101, 189);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(151, 28);
            cboCategory.TabIndex = 9;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(15, 189);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(76, 20);
            lblCategory.TabIndex = 8;
            lblCategory.Text = "Danh mục";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(101, 152);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(125, 27);
            txtQuantity.TabIndex = 7;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(15, 152);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(69, 20);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Số lượng";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(101, 116);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(125, 27);
            txtUnitPrice.TabIndex = 5;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(15, 119);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(62, 20);
            lblUnitPrice.TabIndex = 4;
            lblUnitPrice.Text = "Đơn giá";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(101, 76);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(125, 27);
            txtProductName.TabIndex = 3;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(15, 78);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(52, 20);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Tên SP";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(101, 43);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(125, 27);
            txtProductId.TabIndex = 1;
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(15, 41);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(50, 20);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "Mã SP";
            // 
            // grpFunctions
            // 
            grpFunctions.Controls.Add(btnSearch);
            grpFunctions.Controls.Add(btnDelete);
            grpFunctions.Controls.Add(btnEdit);
            grpFunctions.Controls.Add(btnAdd);
            grpFunctions.Location = new Point(27, 291);
            grpFunctions.Name = "grpFunctions";
            grpFunctions.Size = new Size(334, 147);
            grpFunctions.TabIndex = 2;
            grpFunctions.TabStop = false;
            grpFunctions.Text = "Chức năng";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(169, 89);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(27, 89);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(169, 36);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(27, 36);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(367, 55);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(680, 383);
            dgvProducts.TabIndex = 3;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 450);
            Controls.Add(dgvProducts);
            Controls.Add(grpFunctions);
            Controls.Add(grpProduct);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            grpProduct.ResumeLayout(false);
            grpProduct.PerformLayout();
            grpFunctions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox grpProduct;
        private Label lblUnitPrice;
        private TextBox txtProductName;
        private Label lblProductName;
        private TextBox txtProductId;
        private Label lblProductId;
        private ComboBox cboCategory;
        private Label lblCategory;
        private TextBox txtQuantity;
        private Label lblQuantity;
        private TextBox txtUnitPrice;
        private GroupBox grpFunctions;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnSearch;
        private Button btnDelete;
        private DataGridView dgvProducts;
    }
}
