namespace LabEquipmentCheckout;

partial class Form1
{
    private System.ComponentModel.IContainer components = null!;
    private TableLayoutPanel mainLayout = null!;
    private GroupBox editorGroup = null!;
    private TableLayoutPanel editorLayout = null!;
    private TextBox txtReceiptCode = null!;
    private TextBox txtStudentCode = null!;
    private TextBox txtStudentName = null!;
    private ComboBox cboEquipment = null!;
    private NumericUpDown nudQuantity = null!;
    private DateTimePicker dtpBorrowDate = null!;
    private DateTimePicker dtpDueDate = null!;
    private DateTimePicker dtpActualReturn = null!;
    private CheckBox chkReturned = null!;
    private Button btnAdd = null!;
    private Button btnUpdate = null!;
    private Button btnDelete = null!;
    private Button btnMarkReturned = null!;
    private Button btnClear = null!;
    private GroupBox listGroup = null!;
    private TableLayoutPanel listLayout = null!;
    private TextBox txtSearch = null!;
    private ComboBox cboStatusFilter = null!;
    private Button btnExport = null!;
    private DataGridView dgvCheckouts = null!;
    private StatusStrip statusStrip = null!;
    private ToolStripStatusLabel lblTotal = null!;
    private ToolStripStatusLabel lblOverdue = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        mainLayout = new TableLayoutPanel();
        editorGroup = new GroupBox();
        editorLayout = new TableLayoutPanel();
        txtReceiptCode = new TextBox();
        txtStudentCode = new TextBox();
        txtStudentName = new TextBox();
        cboEquipment = new ComboBox();
        nudQuantity = new NumericUpDown();
        dtpBorrowDate = new DateTimePicker();
        dtpDueDate = new DateTimePicker();
        dtpActualReturn = new DateTimePicker();
        chkReturned = new CheckBox();
        btnAdd = new Button(); btnUpdate = new Button(); btnDelete = new Button(); btnMarkReturned = new Button(); btnClear = new Button();
        listGroup = new GroupBox();
        listLayout = new TableLayoutPanel();
        txtSearch = new TextBox();
        cboStatusFilter = new ComboBox();
        btnExport = new Button();
        dgvCheckouts = new DataGridView();
        statusStrip = new StatusStrip();
        lblTotal = new ToolStripStatusLabel();
        lblOverdue = new ToolStripStatusLabel();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvCheckouts).BeginInit();
        SuspendLayout();

        Text = "Quản lý mượn trả thiết bị";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(900, 600);
        ClientSize = new Size(1200, 760);

        mainLayout.Dock = DockStyle.Fill;
        mainLayout.Padding = new Padding(10);
        mainLayout.RowCount = 2;
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 205));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        mainLayout.Controls.Add(editorGroup, 0, 0);
        mainLayout.Controls.Add(listGroup, 0, 1);

        editorGroup.Dock = DockStyle.Fill;
        editorGroup.Text = "Thông tin phiếu mượn";
        editorGroup.Padding = new Padding(8);
        editorGroup.Controls.Add(editorLayout);
        editorLayout.Dock = DockStyle.Fill;
        editorLayout.ColumnCount = 6;
        editorLayout.RowCount = 3;
        for (var i = 0; i < 6; i++) editorLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, i % 2 == 0 ? 12 : 21));
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 34));
        AddField("Mã phiếu", txtReceiptCode, 0, 0);
        AddField("Mã sinh viên", txtStudentCode, 2, 0);
        AddField("Họ tên sinh viên", txtStudentName, 4, 0);
        AddField("Thiết bị", cboEquipment, 0, 1);
        AddField("Số lượng", nudQuantity, 2, 1);
        AddField("Ngày mượn", dtpBorrowDate, 4, 1);
        AddField("Hạn trả", dtpDueDate, 0, 2);
        AddField("Ngày trả thực tế", dtpActualReturn, 2, 2);
        chkReturned.Text = "Đã trả";
        chkReturned.Anchor = AnchorStyles.Left;
        chkReturned.AutoSize = true;
        editorLayout.Controls.Add(chkReturned, 4, 2);
        dtpActualReturn.Enabled = false;
        cboEquipment.DropDownStyle = ComboBoxStyle.DropDownList;
        nudQuantity.Minimum = 1; nudQuantity.Maximum = 10000; nudQuantity.Value = 1;
        foreach (var picker in new[] { dtpBorrowDate, dtpDueDate, dtpActualReturn }) picker.Format = DateTimePickerFormat.Short;

        var buttonPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = false, FlowDirection = FlowDirection.LeftToRight };
        ConfigureButton(btnAdd, "Thêm", btnAdd_Click);
        ConfigureButton(btnUpdate, "Cập nhật", btnUpdate_Click);
        ConfigureButton(btnDelete, "Xóa", btnDelete_Click);
        ConfigureButton(btnMarkReturned, "Đánh dấu đã trả", btnMarkReturned_Click);
        ConfigureButton(btnClear, "Nhập mới", (_, _) => ClearEditor());
        buttonPanel.Controls.AddRange(new Control[] { btnAdd, btnUpdate, btnDelete, btnMarkReturned, btnClear });
        editorLayout.RowCount = 4;
        editorLayout.Controls.Add(buttonPanel, 0, 3);
        editorLayout.SetColumnSpan(buttonPanel, 6);
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38));

        listGroup.Dock = DockStyle.Fill;
        listGroup.Text = "Danh sách phiếu mượn";
        listGroup.Padding = new Padding(8);
        listGroup.Controls.Add(listLayout);
        listLayout.Dock = DockStyle.Fill;
        listLayout.ColumnCount = 3;
        listLayout.RowCount = 2;
        listLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
        listLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
        listLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        listLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
        listLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        txtSearch.Dock = DockStyle.Fill;
        txtSearch.PlaceholderText = "Tìm theo mã sinh viên hoặc tên thiết bị...";
        txtSearch.TextChanged += txtSearch_TextChanged;
        cboStatusFilter.Dock = DockStyle.Fill;
        cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboStatusFilter.Items.AddRange(new object[] { "Tất cả", "Đang mượn", "Quá hạn", "Đã trả" });
        cboStatusFilter.SelectedIndex = 0;
        cboStatusFilter.SelectedIndexChanged += cboStatusFilter_SelectedIndexChanged;
        ConfigureButton(btnExport, "Xuất CSV", btnExport_Click);
        btnExport.Dock = DockStyle.Fill;
        listLayout.Controls.Add(txtSearch, 0, 0);
        listLayout.Controls.Add(cboStatusFilter, 1, 0);
        listLayout.Controls.Add(btnExport, 2, 0);
        dgvCheckouts.Dock = DockStyle.Fill;
        dgvCheckouts.AllowUserToAddRows = false;
        dgvCheckouts.AllowUserToDeleteRows = false;
        dgvCheckouts.AutoGenerateColumns = false;
        dgvCheckouts.ReadOnly = true;
        dgvCheckouts.MultiSelect = false;
        dgvCheckouts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCheckouts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCheckouts.SelectionChanged += dgvCheckouts_SelectionChanged;
        AddColumn("Mã phiếu", "MaPhieu"); AddColumn("Mã sinh viên", "MaSinhVien"); AddColumn("Họ tên", "HoTenSinhVien");
        AddColumn("Thiết bị", "ThietBi"); AddColumn("SL", "SoLuong"); AddColumn("Ngày mượn", "NgayMuon", "dd/MM/yyyy");
        AddColumn("Hạn trả", "HanTra", "dd/MM/yyyy"); AddColumn("Ngày trả", "NgayTraThucTe", "dd/MM/yyyy"); AddColumn("Tình trạng", "TrangThai");
        listLayout.Controls.Add(dgvCheckouts, 0, 1);
        listLayout.SetColumnSpan(dgvCheckouts, 3);

        statusStrip.Items.Add(lblTotal); statusStrip.Items.Add(new ToolStripStatusLabel { Spring = true }); statusStrip.Items.Add(lblOverdue);
        lblTotal.Text = "Tổng phiếu: 0"; lblOverdue.Text = "Quá hạn: 0";
        Controls.Add(mainLayout);
        Controls.Add(statusStrip);
        ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvCheckouts).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private void AddField(string labelText, Control control, int column, int row)
    {
        var label = new Label { Text = labelText, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, AutoSize = true };
        control.Dock = DockStyle.Fill;
        editorLayout.Controls.Add(label, column, row);
        editorLayout.Controls.Add(control, column + 1, row);
    }

    private void ConfigureButton(Button button, string text, EventHandler handler)
    {
        button.Text = text; button.AutoSize = true; button.Padding = new Padding(8, 0, 8, 0); button.Click += handler;
    }

    private void AddColumn(string header, string property, string? format = null)
    {
        dgvCheckouts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = header, DataPropertyName = property, DefaultCellStyle = new DataGridViewCellStyle { Format = format ?? string.Empty } });
    }
}