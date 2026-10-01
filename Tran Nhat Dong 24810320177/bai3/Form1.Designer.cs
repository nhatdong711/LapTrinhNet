namespace Bai3_TechMartProductManager
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exportCsvToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            tlpMain = new TableLayoutPanel();
            tlpInput = new TableLayoutPanel();
            lblProductId = new Label();
            txtProductId = new TextBox();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblUnitPrice = new Label();
            txtUnitPrice = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            picAvatar = new PictureBox();
            btnChooseImage = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            flpButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnExportCsv = new Button();
            dgvProducts = new DataGridView();
            colProductId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tlpMain.SuspendLayout();
            tlpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            flpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // menuStrip1
            //
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1000, 24);
            //
            // fileToolStripMenuItem
            //
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportCsvToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Text = "File";
            //
            // exportCsvToolStripMenuItem
            //
            exportCsvToolStripMenuItem.Name = "exportCsvToolStripMenuItem";
            exportCsvToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            exportCsvToolStripMenuItem.Text = "Export CSV";
            exportCsvToolStripMenuItem.Click += btnExportCsv_Click;
            //
            // exitToolStripMenuItem
            //
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            //
            // statusStrip1
            //
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Name = "statusStrip1";
            //
            // lblStatus
            //
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Tổng số sản phẩm: 0";
            //
            // tlpMain: 2 cột 35% - 65%
            //
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(tlpInput, 0, 0);
            tlpMain.Controls.Add(dgvProducts, 1, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Name = "tlpMain";
            //
            // tlpInput: Khung nhập liệu (cột trái)
            //
            tlpInput.ColumnCount = 2;
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpInput.RowCount = 8;
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tlpInput.Controls.Add(lblProductId, 0, 0);
            tlpInput.Controls.Add(txtProductId, 1, 0);
            tlpInput.Controls.Add(lblProductName, 0, 1);
            tlpInput.Controls.Add(txtProductName, 1, 1);
            tlpInput.Controls.Add(lblCategory, 0, 2);
            tlpInput.Controls.Add(cboCategory, 1, 2);
            tlpInput.Controls.Add(lblUnitPrice, 0, 3);
            tlpInput.Controls.Add(txtUnitPrice, 1, 3);
            tlpInput.Controls.Add(lblQuantity, 0, 4);
            tlpInput.Controls.Add(txtQuantity, 1, 4);
            tlpInput.Controls.Add(picAvatar, 1, 5);
            tlpInput.Controls.Add(btnChooseImage, 0, 5);
            tlpInput.Controls.Add(lblSearch, 0, 6);
            tlpInput.Controls.Add(txtSearch, 1, 6);
            tlpInput.Controls.Add(flpButtons, 0, 7);
            tlpInput.SetColumnSpan(flpButtons, 2);
            tlpInput.Dock = DockStyle.Fill;
            tlpInput.Name = "tlpInput";
            //
            // Labels
            //
            lblProductId.Text = "Mã SP";
            lblProductId.Anchor = AnchorStyles.Left;
            lblProductId.AutoSize = true;
            lblProductName.Text = "Tên SP";
            lblProductName.Anchor = AnchorStyles.Left;
            lblProductName.AutoSize = true;
            lblCategory.Text = "Danh mục";
            lblCategory.Anchor = AnchorStyles.Left;
            lblCategory.AutoSize = true;
            lblUnitPrice.Text = "Đơn giá";
            lblUnitPrice.Anchor = AnchorStyles.Left;
            lblUnitPrice.AutoSize = true;
            lblQuantity.Text = "Số lượng";
            lblQuantity.Anchor = AnchorStyles.Left;
            lblQuantity.AutoSize = true;
            lblSearch.Text = "Tìm kiếm";
            lblSearch.Anchor = AnchorStyles.Left;
            lblSearch.AutoSize = true;
            //
            // TextBoxes / ComboBox (co giãn theo chiều ngang)
            //
            txtProductId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtProductId.Name = "txtProductId";
            txtProductName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtProductName.Name = "txtProductName";
            cboCategory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Name = "cboCategory";
            txtUnitPrice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUnitPrice.Name = "txtUnitPrice";
            txtQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtQuantity.Name = "txtQuantity";
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Name = "txtSearch";
            txtSearch.TextChanged += txtSearch_TextChanged;
            //
            // picAvatar
            //
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Dock = DockStyle.Fill;
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.Name = "picAvatar";
            //
            // btnChooseImage
            //
            btnChooseImage.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            btnChooseImage.Size = new Size(74, 28);
            btnChooseImage.Text = "Chọn Ảnh";
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Click += btnChooseImage_Click;
            //
            // flpButtons
            //
            flpButtons.Controls.Add(btnAdd);
            flpButtons.Controls.Add(btnUpdate);
            flpButtons.Controls.Add(btnDelete);
            flpButtons.Controls.Add(btnExportCsv);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Name = "flpButtons";
            //
            // Buttons
            //
            btnAdd.Size = new Size(90, 30);
            btnAdd.Text = "Thêm mới";
            btnAdd.Name = "btnAdd";
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Size = new Size(90, 30);
            btnUpdate.Text = "Cập nhật";
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Size = new Size(90, 30);
            btnDelete.Text = "Xóa";
            btnDelete.Name = "btnDelete";
            btnDelete.Click += btnDelete_Click;
            btnExportCsv.Size = new Size(90, 30);
            btnExportCsv.Text = "Xuất CSV";
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Click += btnExportCsv_Click;
            //
            // dgvProducts
            //
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colCategory, colUnitPrice, colQuantity });
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.CellClick += dgvProducts_CellClick;
            //
            // Columns
            //
            colProductId.DataPropertyName = "ProductId";
            colProductId.HeaderText = "Mã SP";
            colProductId.Name = "colProductId";
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Tên SP";
            colProductName.Name = "colProductName";
            colCategory.DataPropertyName = "CategoryName";
            colCategory.HeaderText = "Danh Mục";
            colCategory.Name = "colCategory";
            colUnitPrice.DataPropertyName = "UnitPrice";
            colUnitPrice.HeaderText = "Đơn Giá";
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.DefaultCellStyle.Format = "N0";
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Số Lượng";
            colQuantity.Name = "colQuantity";
            //
            // errorProvider1
            //
            errorProvider1.ContainerControl = this;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(tlpMain);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "TechMart Product Manager";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tlpMain.ResumeLayout(false);
            tlpInput.ResumeLayout(false);
            tlpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            flpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exportCsvToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private TableLayoutPanel tlpMain;
        private TableLayoutPanel tlpInput;
        private Label lblProductId;
        private TextBox txtProductId;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblUnitPrice;
        private TextBox txtUnitPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private PictureBox picAvatar;
        private Button btnChooseImage;
        private Label lblSearch;
        private TextBox txtSearch;
        private FlowLayoutPanel flpButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnExportCsv;
        private DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colProductId;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private BindingSource bindingSource1;
        private ErrorProvider errorProvider1;
    }
}
