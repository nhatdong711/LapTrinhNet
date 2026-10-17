namespace ClinicAppointmentManager;

partial class Form1
{
    private System.ComponentModel.IContainer components = null!;
    private TableLayoutPanel mainLayout = null!;
    private TableLayoutPanel formLayout = null!;
    private TableLayoutPanel filterLayout = null!;
    private Panel headerPanel = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblFormMode = null!;
    private Label lblFilterSummary = null!;
    private Label lblResultCount = null!;
    private TextBox txtAppointmentId = null!;
    private TextBox txtPatientName = null!;
    private TextBox txtPhone = null!;
    private TextBox txtReason = null!;
    private DateTimePicker dtpAppointmentDate = null!;
    private DateTimePicker dtpFilterDate = null!;
    private ComboBox cboDoctor = null!;
    private ComboBox cboStatus = null!;
    private ComboBox cboFilterStatus = null!;
    private TextBox txtSearch = null!;
    private Button btnSave = null!;
    private Button btnNew = null!;
    private Button btnDelete = null!;
    private DataGridView gridAppointments = null!;
    private ErrorProvider errorProvider = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        mainLayout = new TableLayoutPanel();
        formLayout = new TableLayoutPanel();
        filterLayout = new TableLayoutPanel();
        headerPanel = new Panel();
        lblTitle = new Label();
        lblSubtitle = new Label();
        lblFormMode = new Label();
        lblFilterSummary = new Label();
        lblResultCount = new Label();
        txtAppointmentId = new TextBox();
        txtPatientName = new TextBox();
        txtPhone = new TextBox();
        txtReason = new TextBox();
        dtpAppointmentDate = new DateTimePicker();
        dtpFilterDate = new DateTimePicker();
        cboDoctor = new ComboBox();
        cboStatus = new ComboBox();
        cboFilterStatus = new ComboBox();
        txtSearch = new TextBox();
        btnSave = new Button();
        btnNew = new Button();
        btnDelete = new Button();
        gridAppointments = new DataGridView();
        errorProvider = new ErrorProvider(components);
        var menuStrip = new MenuStrip();
        var fileMenu = new ToolStripMenuItem("Tệp");
        var exportMenu = new ToolStripMenuItem("Xuất danh sách ra CSV", null, ExportCsv);
        var helpMenu = new ToolStripMenuItem("Trợ giúp");
        var aboutMenu = new ToolStripMenuItem("Về ứng dụng", null, (_, _) => MessageBox.Show("Clinic Appointment Manager\nQuản lý lịch hẹn phòng khám", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information));
        var statusStrip = new StatusStrip();
        var statusLabel = new ToolStripStatusLabel("●  Sẵn sàng");

        SuspendLayout();
        menuStrip.Items.AddRange([fileMenu, helpMenu]);
        fileMenu.DropDownItems.Add(exportMenu);
        helpMenu.DropDownItems.Add(aboutMenu);
        menuStrip.Dock = DockStyle.Top;
        menuStrip.RenderMode = ToolStripRenderMode.System;

        statusStrip.Items.Add(statusLabel);
        statusStrip.Items.Add(new ToolStripStatusLabel { Spring = true });
        statusStrip.Items.Add(new ToolStripStatusLabel("Clinic Appointment Manager  •  .NET 10"));
        statusStrip.Dock = DockStyle.Bottom;

        headerPanel.BackColor = Color.FromArgb(24, 93, 150);
        headerPanel.Dock = DockStyle.Fill;
        headerPanel.Padding = new Padding(28, 18, 28, 16);
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(28, 14);
        lblTitle.Text = "Quản lý lịch hẹn";
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 9.5F);
        lblSubtitle.ForeColor = Color.FromArgb(218, 237, 252);
        lblSubtitle.Location = new Point(31, 52);
        lblSubtitle.Text = "Theo dõi lịch khám và chăm sóc bệnh nhân hiệu quả";
        lblFormMode.AutoSize = true;
        lblFormMode.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblFormMode.ForeColor = Color.FromArgb(218, 237, 252);
        lblFormMode.Location = new Point(31, 78);
        lblFormMode.Text = "TẠO LỊCH HẸN MỚI";
        headerPanel.Controls.AddRange([lblTitle, lblSubtitle, lblFormMode]);

        mainLayout.ColumnCount = 1;
        mainLayout.RowCount = 3;
        mainLayout.Dock = DockStyle.Fill;
        mainLayout.Padding = new Padding(18, 14, 18, 12);
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 104F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 202F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        formLayout.ColumnCount = 8;
        formLayout.RowCount = 3;
        formLayout.Dock = DockStyle.Fill;
        formLayout.BackColor = Color.White;
        formLayout.Padding = new Padding(16, 10, 16, 10);
        for (var i = 0; i < 8; i++) formLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, i % 2 == 0 ? 10 : 15));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
        formLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
        AddField(formLayout, "Mã lịch hẹn", txtAppointmentId, 0, 0);
        AddField(formLayout, "Họ tên bệnh nhân", txtPatientName, 2, 0);
        AddField(formLayout, "Số điện thoại", txtPhone, 4, 0);
        AddField(formLayout, "Ngày giờ hẹn", dtpAppointmentDate, 6, 0);
        AddField(formLayout, "Bác sĩ phụ trách", cboDoctor, 0, 1);
        AddField(formLayout, "Trạng thái", cboStatus, 2, 1);
        AddField(formLayout, "Lý do khám", txtReason, 4, 1, 3);
        ConfigureTextBox(txtAppointmentId, "VD: LH-202504");
        ConfigureTextBox(txtPatientName, "Nhập họ tên bệnh nhân");
        ConfigureTextBox(txtPhone, "VD: 0901234567");
        ConfigureTextBox(txtReason, "Mô tả lý do khám...");
        txtReason.Multiline = true;
        txtReason.Height = 46;
        ConfigureCombo(cboDoctor);
        ConfigureCombo(cboStatus);
        dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
        dtpAppointmentDate.CustomFormat = "dd/MM/yyyy  HH:mm";
        dtpAppointmentDate.ShowUpDown = true;
        dtpAppointmentDate.Dock = DockStyle.Fill;
        btnNew.Text = "  Làm mới";
        btnSave.Text = "  Thêm lịch hẹn";
        btnDelete.Text = "  Xóa lịch hẹn";
        StyleButton(btnNew, Color.FromArgb(235, 242, 248), Color.FromArgb(40, 79, 111));
        StyleButton(btnSave, Color.FromArgb(24, 126, 92), Color.White);
        StyleButton(btnDelete, Color.FromArgb(222, 75, 75), Color.White);
        formLayout.Controls.Add(btnNew, 0, 2); formLayout.SetColumnSpan(btnNew, 2);
        formLayout.Controls.Add(btnSave, 2, 2); formLayout.SetColumnSpan(btnSave, 2);
        formLayout.Controls.Add(btnDelete, 4, 2); formLayout.SetColumnSpan(btnDelete, 2);

        filterLayout.ColumnCount = 6;
        filterLayout.RowCount = 2;
        filterLayout.Dock = DockStyle.Fill;
        filterLayout.BackColor = Color.FromArgb(247, 249, 252);
        filterLayout.Padding = new Padding(16, 8, 16, 8);
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
        filterLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
        filterLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
        var searchLabel = CreateLabel("Tìm kiếm"); filterLayout.Controls.Add(searchLabel, 0, 0);
        ConfigureTextBox(txtSearch, "Tên bệnh nhân hoặc số điện thoại"); filterLayout.Controls.Add(txtSearch, 1, 0);
        var dateLabel = CreateLabel("Ngày hẹn"); filterLayout.Controls.Add(dateLabel, 2, 0);
        dtpFilterDate.Format = DateTimePickerFormat.Custom; dtpFilterDate.CustomFormat = "dd/MM/yyyy"; dtpFilterDate.Dock = DockStyle.Fill; filterLayout.Controls.Add(dtpFilterDate, 3, 0);
        var statusLabel2 = CreateLabel("Trạng thái"); filterLayout.Controls.Add(statusLabel2, 4, 0);
        ConfigureCombo(cboFilterStatus); filterLayout.Controls.Add(cboFilterStatus, 5, 0);
        lblFilterSummary.AutoSize = true; lblFilterSummary.ForeColor = Color.FromArgb(91, 105, 120); lblFilterSummary.Font = new Font("Segoe UI", 8.5F); filterLayout.Controls.Add(lblFilterSummary, 0, 1); filterLayout.SetColumnSpan(lblFilterSummary, 3);
        lblResultCount.AutoSize = true; lblResultCount.Anchor = AnchorStyles.Right; lblResultCount.ForeColor = Color.FromArgb(24, 93, 150); lblResultCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold); filterLayout.Controls.Add(lblResultCount, 3, 1); filterLayout.SetColumnSpan(lblResultCount, 3);

        gridAppointments.Dock = DockStyle.Fill;
        gridAppointments.BackgroundColor = Color.White;
        gridAppointments.BorderStyle = BorderStyle.None;
        gridAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridAppointments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        gridAppointments.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(24, 93, 150), ForeColor = Color.White, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Padding = new Padding(8, 0, 0, 0) };
        gridAppointments.ColumnHeadersHeight = 40;
        gridAppointments.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.White, ForeColor = Color.FromArgb(45, 55, 65), SelectionBackColor = Color.FromArgb(218, 237, 252), SelectionForeColor = Color.FromArgb(20, 55, 85), Font = new Font("Segoe UI", 9F), Padding = new Padding(8, 0, 0, 0) };
        gridAppointments.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(247, 250, 253) };
        gridAppointments.RowTemplate.Height = 38;
        gridAppointments.AutoGenerateColumns = false;
        gridAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridAppointments.MultiSelect = false;
        gridAppointments.ReadOnly = true;
        gridAppointments.AllowUserToAddRows = false;
        gridAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        AddGridColumn("Mã lịch", "Id", 80); AddGridColumn("Bệnh nhân", "PatientName", 140); AddGridColumn("Số điện thoại", "Phone", 105); AddGridColumn("Ngày giờ hẹn", "AppointmentDate", 125, "dd/MM/yyyy HH:mm"); AddGridColumn("Bác sĩ", "Doctor", 145); AddGridColumn("Lý do khám", "Reason", 160); AddGridColumn("Trạng thái", "Status", 100);

        mainLayout.Controls.Add(headerPanel, 0, 0);
        mainLayout.Controls.Add(formLayout, 0, 1);
        mainLayout.Controls.Add(gridAppointments, 0, 2);
        Controls.Add(mainLayout); Controls.Add(menuStrip); Controls.Add(statusStrip);
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.Icon = SystemIcons.Warning;
        BackColor = Color.FromArgb(247, 249, 252);
        ClientSize = new Size(1240, 760);
        MinimumSize = new Size(980, 620);
        Font = new Font("Segoe UI", 9F);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Clinic Appointment Manager";
        gridAppointments.SelectionChanged += GridAppointments_SelectionChanged;
        txtSearch.TextChanged += SearchOrFilterChanged; dtpFilterDate.ValueChanged += SearchOrFilterChanged; cboFilterStatus.SelectedIndexChanged += SearchOrFilterChanged;
        btnNew.Click += NewAppointment; btnSave.Click += SaveAppointment; btnDelete.Click += DeleteAppointment;
        ResumeLayout(false); PerformLayout();
    }

    private static Label CreateLabel(string text) => new() { Text = text, AutoSize = true, Anchor = AnchorStyles.Left, ForeColor = Color.FromArgb(75, 88, 102), Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), Margin = new Padding(0, 6, 8, 0) };

    private static void AddField(TableLayoutPanel layout, string label, Control control, int column, int row, int span = 1)
    {
        layout.Controls.Add(CreateLabel(label), column, row);
        layout.Controls.Add(control, column + 1, row); layout.SetColumnSpan(control, span * 2 - 1);
    }

    private static void ConfigureTextBox(TextBox textBox, string placeholder) { textBox.Dock = DockStyle.Fill; textBox.BorderStyle = BorderStyle.FixedSingle; textBox.Margin = new Padding(3, 5, 12, 5); textBox.PlaceholderText = placeholder; }
    private static void ConfigureCombo(ComboBox combo) { combo.Dock = DockStyle.Fill; combo.DropDownStyle = ComboBoxStyle.DropDownList; combo.FlatStyle = FlatStyle.Flat; combo.Margin = new Padding(3, 5, 12, 5); }
    private static void StyleButton(Button button, Color backColor, Color foreColor) { button.Dock = DockStyle.Fill; button.BackColor = backColor; button.ForeColor = foreColor; button.FlatStyle = FlatStyle.Flat; button.FlatAppearance.BorderSize = 0; button.Font = new Font("Segoe UI", 9F, FontStyle.Bold); button.Margin = new Padding(3, 5, 12, 5); button.Cursor = Cursors.Hand; }
    private void AddGridColumn(string header, string property, float width, string? format = null) { var column = new DataGridViewTextBoxColumn { HeaderText = header, DataPropertyName = property, FillWeight = width }; if (format is not null) column.DefaultCellStyle.Format = format; gridAppointments.Columns.Add(column); }
}