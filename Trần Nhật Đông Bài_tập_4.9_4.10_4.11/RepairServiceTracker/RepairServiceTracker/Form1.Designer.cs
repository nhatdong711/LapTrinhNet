namespace RepairServiceTracker;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private MenuStrip menuStrip;
    private ToolStripMenuItem fileMenu;
    private ToolStripMenuItem exportMenuItem;
    private ToolStripMenuItem exitMenuItem;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblSummary;
    private TableLayoutPanel mainLayout;
    private TableLayoutPanel detailsLayout;
    private TableLayoutPanel fieldsLayout;
    private Label lblOrderId, lblCustomerName, lblPhone, lblDeviceType, lblDescription, lblReceivedDate, lblCost, lblStatus, lblFilter;
    private TextBox txtOrderId, txtCustomerName, txtPhone, txtDescription, txtEstimatedCost, txtSearch;
    private ComboBox cboDeviceType, cboStatus, cboStatusFilter;
    private DateTimePicker dtpReceivedDate;
    private Button btnSave, btnDelete, btnClear, btnChooseImage;
    private PictureBox picDevice;
    private DataGridView dgvOrders;
    private Panel filterPanel;
    private ErrorProvider errorProvider;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip = new MenuStrip(); fileMenu = new ToolStripMenuItem(); exportMenuItem = new ToolStripMenuItem(); exitMenuItem = new ToolStripMenuItem();
        statusStrip = new StatusStrip(); lblSummary = new ToolStripStatusLabel(); mainLayout = new TableLayoutPanel(); detailsLayout = new TableLayoutPanel(); fieldsLayout = new TableLayoutPanel();
        lblOrderId = new Label(); lblCustomerName = new Label(); lblPhone = new Label(); lblDeviceType = new Label(); lblDescription = new Label(); lblReceivedDate = new Label(); lblCost = new Label(); lblStatus = new Label(); lblFilter = new Label(); filterPanel = new Panel();
        txtOrderId = new TextBox(); txtCustomerName = new TextBox(); txtPhone = new TextBox(); txtDescription = new TextBox(); txtEstimatedCost = new TextBox(); txtSearch = new TextBox();
        cboDeviceType = new ComboBox(); cboStatus = new ComboBox(); cboStatusFilter = new ComboBox(); dtpReceivedDate = new DateTimePicker(); btnSave = new Button(); btnDelete = new Button(); btnClear = new Button(); btnChooseImage = new Button(); picDevice = new PictureBox(); dgvOrders = new DataGridView(); errorProvider = new ErrorProvider(components);
        SuspendLayout();

        Text = "Repair Service Tracker"; StartPosition = FormStartPosition.CenterScreen; MinimumSize = new Size(900, 600); ClientSize = new Size(1200, 760);
        menuStrip.Items.AddRange([fileMenu]); fileMenu.Text = "Tệp"; fileMenu.DropDownItems.AddRange([exportMenuItem, new ToolStripSeparator(), exitMenuItem]);
        exportMenuItem.Text = "Xuất danh sách đang hiển thị ra CSV"; exportMenuItem.Click += ExportCsv_Click; exitMenuItem.Text = "Thoát"; exitMenuItem.Click += (_, _) => Close();
        MainMenuStrip = menuStrip; Controls.Add(mainLayout); Controls.Add(statusStrip); Controls.Add(menuStrip);
        statusStrip.Items.Add(lblSummary); lblSummary.Spring = true; lblSummary.TextAlign = ContentAlignment.MiddleLeft;
        mainLayout.Dock = DockStyle.Fill; mainLayout.Padding = new Padding(8); mainLayout.RowCount = 2; mainLayout.ColumnCount = 1; mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 43)); mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 57));
        mainLayout.Controls.Add(detailsLayout, 0, 0); mainLayout.Controls.Add(dgvOrders, 0, 1);

        detailsLayout.Dock = DockStyle.Fill; detailsLayout.ColumnCount = 2; detailsLayout.RowCount = 1; detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68)); detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32));
        detailsLayout.Controls.Add(fieldsLayout, 0, 0); detailsLayout.Controls.Add(CreateImagePanel(), 1, 0);
        fieldsLayout.Dock = DockStyle.Fill; fieldsLayout.Padding = new Padding(0, 0, 12, 0); fieldsLayout.ColumnCount = 4; fieldsLayout.RowCount = 6;
        fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125)); fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50)); fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125)); fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        for (int i = 0; i < 6; i++) fieldsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, i == 4 ? 30 : 14));
        AddField(lblOrderId, "Mã đơn *", txtOrderId, 0, 0); AddField(lblCustomerName, "Tên khách hàng *", txtCustomerName, 2, 0); AddField(lblPhone, "Số điện thoại *", txtPhone, 0, 1); AddField(lblDeviceType, "Loại thiết bị *", cboDeviceType, 2, 1);
        AddField(lblReceivedDate, "Ngày tiếp nhận", dtpReceivedDate, 0, 2); AddField(lblCost, "Chi phí dự kiến *", txtEstimatedCost, 2, 2); AddField(lblStatus, "Trạng thái", cboStatus, 0, 3);
        lblDescription.Text = "Mô tả lỗi *"; lblDescription.Dock = DockStyle.Fill; lblDescription.TextAlign = ContentAlignment.TopLeft; fieldsLayout.Controls.Add(lblDescription, 0, 4); fieldsLayout.SetColumnSpan(lblDescription, 1);
        txtDescription.Multiline = true; txtDescription.ScrollBars = ScrollBars.Vertical; txtDescription.Dock = DockStyle.Fill; fieldsLayout.Controls.Add(txtDescription, 1, 4); fieldsLayout.SetColumnSpan(txtDescription, 3);
        FlowLayoutPanel buttons = new() { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, WrapContents = false, Padding = new Padding(0, 5, 0, 0) }; buttons.Controls.AddRange([btnSave, btnDelete, btnClear]); fieldsLayout.Controls.Add(buttons, 0, 5); fieldsLayout.SetColumnSpan(buttons, 4);
        ConfigureButton(btnSave, "Thêm đơn", BtnSave_Click); ConfigureButton(btnDelete, "Xóa đơn", BtnDelete_Click); ConfigureButton(btnClear, "Làm mới", (_, _) => ClearForm());

        txtSearch.PlaceholderText = "Tìm theo mã đơn, tên khách hàng hoặc số điện thoại..."; txtSearch.Dock = DockStyle.Fill; txtSearch.TextChanged += FiltersChanged;
        cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList; cboStatusFilter.Dock = DockStyle.Left; cboStatusFilter.Width = 170; cboStatusFilter.SelectedIndexChanged += FiltersChanged;
        dgvOrders.Dock = DockStyle.Fill; dgvOrders.AutoGenerateColumns = false; dgvOrders.AllowUserToAddRows = false; dgvOrders.AllowUserToDeleteRows = false; dgvOrders.ReadOnly = true; dgvOrders.MultiSelect = false; dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgvOrders.RowHeadersVisible = false; dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;
        filterPanel.Dock = DockStyle.Top; filterPanel.Height = 38; filterPanel.Padding = new Padding(0, 3, 0, 3); filterPanel.Controls.Add(txtSearch); filterPanel.Controls.Add(lblFilter); filterPanel.Controls.Add(cboStatusFilter); dgvOrders.Controls.Add(filterPanel);
        lblFilter.Text = "Lọc trạng thái:"; lblFilter.AutoSize = true; lblFilter.Location = new Point(440, 8);
        txtSearch.Location = new Point(0, 3); txtSearch.Width = 420; txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        cboStatusFilter.Location = new Point(520, 3); cboStatusFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        dgvOrders.Columns.Clear();
        AddGridColumn("OrderId", "Mã đơn"); AddGridColumn("CustomerName", "Khách hàng"); AddGridColumn("Phone", "Điện thoại"); AddGridColumn("DeviceType", "Thiết bị"); AddGridColumn("ProblemDescription", "Mô tả lỗi"); AddGridColumn("ReceivedDate", "Ngày nhận", "dd/MM/yyyy"); AddGridColumn("EstimatedCost", "Chi phí dự kiến", "N0"); AddGridColumn("Status", "Trạng thái");
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        ResumeLayout(false); PerformLayout();
    }

    private Panel CreateImagePanel()
    {
        Panel panel = new() { Dock = DockStyle.Fill, Padding = new Padding(8, 0, 0, 0) };
        picDevice.Dock = DockStyle.Fill; picDevice.BorderStyle = BorderStyle.FixedSingle; picDevice.SizeMode = PictureBoxSizeMode.Zoom; picDevice.BackColor = Color.WhiteSmoke; panel.Controls.Add(picDevice);
        btnChooseImage.Text = "Chọn ảnh thiết bị"; btnChooseImage.Dock = DockStyle.Bottom; btnChooseImage.Height = 34; btnChooseImage.Click += BtnChooseImage_Click; panel.Controls.Add(btnChooseImage);
        return panel;
    }

    private void AddField(Label label, string text, Control control, int column, int row)
    {
        label.Text = text; label.Dock = DockStyle.Fill; label.TextAlign = ContentAlignment.MiddleLeft; fieldsLayout.Controls.Add(label, column, row); control.Dock = DockStyle.Fill; if (control is ComboBox combo) combo.DropDownStyle = ComboBoxStyle.DropDownList; fieldsLayout.Controls.Add(control, column + 1, row);
    }

    private void ConfigureButton(Button button, string text, EventHandler handler) { button.Text = text; button.AutoSize = true; button.Height = 30; button.Click += handler; }
    private void AddGridColumn(string property, string header, string? format = null)
    {
        DataGridViewTextBoxColumn column = new() { DataPropertyName = property, HeaderText = header, Name = "col" + property, FillWeight = property == "ProblemDescription" ? 180 : 100 };
        if (format != null) column.DefaultCellStyle = new DataGridViewCellStyle { Format = format, Alignment = DataGridViewContentAlignment.MiddleRight };
        dgvOrders.Columns.Add(column);
    }
}