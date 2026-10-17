using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace RepairServiceTracker;

public sealed class RepairOrder
{
    public string OrderId { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string DeviceType { get; set; } = string.Empty;
    public string ProblemDescription { get; set; } = string.Empty;
    public DateTime ReceivedDate { get; set; }
    public decimal EstimatedCost { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? ImagePath { get; set; }
}

public partial class Form1 : Form
{
    private readonly BindingList<RepairOrder> allOrders = new();
    private readonly BindingList<RepairOrder> visibleOrders = new();
    private readonly BindingSource orderSource = new();
    private RepairOrder? selectedOrder;
    private string? selectedImagePath;
    private bool isUpdatingForm;

    private static readonly string[] Statuses =
    ["Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy"];

    public Form1()
    {
        InitializeComponent();
        InitializeApplication();
    }

    private void InitializeApplication()
    {
        cboDeviceType.Items.AddRange(["Điện thoại", "Máy tính bảng", "Laptop", "Máy tính để bàn", "Tivi", "Thiết bị khác"]);
        cboStatus.Items.AddRange(Statuses);
        cboStatusFilter.Items.Add("Tất cả trạng thái");
        cboStatusFilter.Items.AddRange(Statuses);
        cboStatusFilter.SelectedIndex = 0;
        cboStatus.SelectedIndex = 0;
        dtpReceivedDate.Value = DateTime.Today;
        orderSource.DataSource = visibleOrders;
        dgvOrders.DataSource = orderSource;
        UpdateGrid();
        UpdateStatusBar();
    }

    private void UpdateGrid()
    {
        string search = txtSearch.Text.Trim();
        string status = cboStatusFilter.SelectedIndex <= 0 ? string.Empty : cboStatusFilter.Text;
        visibleOrders.RaiseListChangedEvents = false;
        visibleOrders.Clear();
        foreach (RepairOrder order in allOrders)
        {
            bool matchesSearch = search.Length == 0 ||
                order.OrderId.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                order.CustomerName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                order.Phone.Contains(search, StringComparison.OrdinalIgnoreCase);
            if (matchesSearch && (status.Length == 0 || order.Status == status))
                visibleOrders.Add(order);
        }
        visibleOrders.RaiseListChangedEvents = true;
        orderSource.ResetBindings(false);
        UpdateStatusBar();
    }

    private void UpdateStatusBar()
    {
        decimal unfinishedTotal = allOrders.Where(order => order.Status != "Hoàn tất" && order.Status != "Đã hủy")
            .Sum(order => order.EstimatedCost);
        lblSummary.Text = $"Đang hiển thị: {visibleOrders.Count} đơn | Tổng chi phí dự kiến chưa hoàn tất: {unfinishedTotal:N0} đ";
    }

    private void ClearForm()
    {
        isUpdatingForm = true;
        selectedOrder = null;
        selectedImagePath = null;
        txtOrderId.Clear();
        txtCustomerName.Clear();
        txtPhone.Clear();
        cboDeviceType.SelectedIndex = -1;
        txtDescription.Clear();
        dtpReceivedDate.Value = DateTime.Today;
        txtEstimatedCost.Text = "0";
        cboStatus.SelectedIndex = 0;
        errorProvider.Clear();
        SetPreviewImage(null);
        isUpdatingForm = false;
        btnSave.Text = "Thêm đơn";
        txtOrderId.Focus();
    }

    private void LoadOrder(RepairOrder order)
    {
        isUpdatingForm = true;
        selectedOrder = order;
        selectedImagePath = order.ImagePath;
        txtOrderId.Text = order.OrderId;
        txtCustomerName.Text = order.CustomerName;
        txtPhone.Text = order.Phone;
        cboDeviceType.Text = order.DeviceType;
        txtDescription.Text = order.ProblemDescription;
        dtpReceivedDate.Value = order.ReceivedDate;
        txtEstimatedCost.Text = order.EstimatedCost.ToString("0.##", CultureInfo.CurrentCulture);
        cboStatus.Text = order.Status;
        SetPreviewImage(order.ImagePath);
        errorProvider.Clear();
        isUpdatingForm = false;
        btnSave.Text = "Cập nhật";
    }

    private bool ValidateForm()
    {
        errorProvider.Clear();
        bool valid = true;
        if (string.IsNullOrWhiteSpace(txtOrderId.Text)) { errorProvider.SetError(txtOrderId, "Mã đơn không được để trống."); valid = false; }
        else if (selectedOrder == null && allOrders.Any(order => order.OrderId.Equals(txtOrderId.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
        { errorProvider.SetError(txtOrderId, "Mã đơn đã tồn tại."); valid = false; }
        if (string.IsNullOrWhiteSpace(txtCustomerName.Text)) { errorProvider.SetError(txtCustomerName, "Tên khách hàng không được để trống."); valid = false; }
        if (string.IsNullOrWhiteSpace(txtPhone.Text)) { errorProvider.SetError(txtPhone, "Số điện thoại không được để trống."); valid = false; }
        if (string.IsNullOrWhiteSpace(cboDeviceType.Text)) { errorProvider.SetError(cboDeviceType, "Hãy chọn loại thiết bị."); valid = false; }
        if (string.IsNullOrWhiteSpace(txtDescription.Text)) { errorProvider.SetError(txtDescription, "Mô tả lỗi là bắt buộc."); valid = false; }
        if (!decimal.TryParse(txtEstimatedCost.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal cost) || cost < 0)
        { errorProvider.SetError(txtEstimatedCost, "Chi phí phải là số không âm."); valid = false; }
        if (string.IsNullOrWhiteSpace(cboStatus.Text)) { errorProvider.SetError(cboStatus, "Hãy chọn trạng thái."); valid = false; }
        return valid;
    }

    private RepairOrder ReadForm() => new()
    {
        OrderId = txtOrderId.Text.Trim(), CustomerName = txtCustomerName.Text.Trim(), Phone = txtPhone.Text.Trim(),
        DeviceType = cboDeviceType.Text, ProblemDescription = txtDescription.Text.Trim(), ReceivedDate = dtpReceivedDate.Value.Date,
        EstimatedCost = decimal.Parse(txtEstimatedCost.Text, NumberStyles.Number, CultureInfo.CurrentCulture), Status = cboStatus.Text,
        ImagePath = selectedImagePath
    };

    private void BtnSave_Click(object? sender, EventArgs e)
    {
        if (!ValidateForm()) return;
        RepairOrder formOrder = ReadForm();
        if (selectedOrder == null) allOrders.Add(formOrder);
        else
        {
            selectedOrder.OrderId = formOrder.OrderId; selectedOrder.CustomerName = formOrder.CustomerName; selectedOrder.Phone = formOrder.Phone;
            selectedOrder.DeviceType = formOrder.DeviceType; selectedOrder.ProblemDescription = formOrder.ProblemDescription;
            selectedOrder.ReceivedDate = formOrder.ReceivedDate; selectedOrder.EstimatedCost = formOrder.EstimatedCost;
            selectedOrder.Status = formOrder.Status; selectedOrder.ImagePath = formOrder.ImagePath;
        }
        UpdateGrid();
        ClearForm();
    }

    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (selectedOrder == null) { MessageBox.Show("Hãy chọn một đơn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        if (MessageBox.Show($"Xóa đơn {selectedOrder.OrderId}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
        allOrders.Remove(selectedOrder);
        UpdateGrid();
        ClearForm();
    }

    private void DgvOrders_SelectionChanged(object? sender, EventArgs e)
    {
        if (!isUpdatingForm && dgvOrders.CurrentRow?.DataBoundItem is RepairOrder order) LoadOrder(order);
    }

    private void FiltersChanged(object? sender, EventArgs e) { if (!isUpdatingForm) UpdateGrid(); }

    private void BtnChooseImage_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog dialog = new() { Filter = "Tệp ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả tệp|*.*", Title = "Chọn ảnh thiết bị" };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        SetPreviewImage(dialog.FileName);
        selectedImagePath = dialog.FileName;
        if (selectedOrder != null) selectedOrder.ImagePath = dialog.FileName;
    }

    private void SetPreviewImage(string? path)
    {
        Image? oldImage = picDevice.Image;
        picDevice.Image = null;
        oldImage?.Dispose();
        if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
        {
            using Image source = Image.FromFile(path);
            picDevice.Image = new Bitmap(source);
        }
    }

    private void ExportCsv_Click(object? sender, EventArgs e)
    {
        using SaveFileDialog dialog = new() { Filter = "CSV (*.csv)|*.csv", FileName = "danh-sach-don-sua-chua.csv" };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        StringBuilder csv = new("Mã đơn,Tên khách hàng,Số điện thoại,Loại thiết bị,Mô tả lỗi,Ngày tiếp nhận,Chi phí dự kiến,Trạng thái\r\n");
        foreach (RepairOrder order in visibleOrders)
            csv.AppendLine(string.Join(",", new[] { order.OrderId, order.CustomerName, order.Phone, order.DeviceType, order.ProblemDescription,
                order.ReceivedDate.ToString("dd/MM/yyyy"), order.EstimatedCost.ToString("N0"), order.Status }.Select(EscapeCsv)));
        File.WriteAllText(dialog.FileName, csv.ToString(), new UTF8Encoding(true));
        MessageBox.Show("Đã xuất danh sách đang hiển thị.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private static string EscapeCsv(string value) => $"\"{value.Replace("\"", "\"\"")}\"";

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        picDevice.Image?.Dispose();
        base.OnFormClosed(e);
    }
}
