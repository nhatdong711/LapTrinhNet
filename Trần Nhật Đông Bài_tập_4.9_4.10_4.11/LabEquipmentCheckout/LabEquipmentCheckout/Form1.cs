using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace LabEquipmentCheckout;

public enum CheckoutStatus
{
    DangMuon,
    DaTra,
    QuaHan
}

public sealed class CheckoutRecord
{
    public string MaPhieu { get; set; } = string.Empty;
    public string MaSinhVien { get; set; } = string.Empty;
    public string HoTenSinhVien { get; set; } = string.Empty;
    public string ThietBi { get; set; } = string.Empty;
    public int SoLuong { get; set; }
    public DateTime NgayMuon { get; set; }
    public DateTime HanTra { get; set; }
    public DateTime? NgayTraThucTe { get; set; }
    public CheckoutStatus Status => NgayTraThucTe.HasValue
        ? CheckoutStatus.DaTra
        : HanTra.Date < DateTime.Today ? CheckoutStatus.QuaHan : CheckoutStatus.DangMuon;
    public string TrangThai => Status switch
    {
        CheckoutStatus.DaTra => "Đã trả",
        CheckoutStatus.QuaHan => "Quá hạn",
        _ => "Đang mượn"
    };
}

public partial class Form1 : Form
{
    private readonly BindingList<CheckoutRecord> records = new();
    private readonly BindingSource bindingSource = new();
    private readonly ErrorProvider errorProvider = new();
    private readonly string[] equipment = { "Máy tính xách tay", "Máy chiếu", "Bộ Arduino", "Đồng hồ vạn năng", "Oscilloscope" };
    private CheckoutRecord? selectedRecord;

    public Form1()
    {
        InitializeComponent();
        cboEquipment.Items.AddRange(equipment);
        bindingSource.DataSource = new List<CheckoutRecord>();
        dgvCheckouts.DataSource = bindingSource;
        RefreshGrid();
        ClearEditor();
    }

    private void RefreshGrid()
    {
        var keyword = txtSearch.Text.Trim();
        var status = cboStatusFilter.SelectedItem?.ToString() ?? "Tất cả";
        var filtered = records.Where(record =>
            (keyword.Length == 0 || record.MaSinhVien.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
             record.ThietBi.Contains(keyword, StringComparison.OrdinalIgnoreCase)) &&
            (status == "Tất cả" || record.TrangThai == status)).ToList();

        bindingSource.DataSource = filtered;
        bindingSource.ResetBindings(false);
        lblTotal.Text = $"Tổng phiếu: {records.Count}";
        lblOverdue.Text = $"Quá hạn: {records.Count(record => record.Status == CheckoutStatus.QuaHan)}";
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        if (!ValidateEditor()) return;

        records.Add(ReadEditor());
        RefreshGrid();
        ClearEditor();
    }

    private void btnUpdate_Click(object? sender, EventArgs e)
    {
        if (selectedRecord is null || !ValidateEditor()) return;

        var updated = ReadEditor();
        selectedRecord.MaPhieu = updated.MaPhieu;
        selectedRecord.MaSinhVien = updated.MaSinhVien;
        selectedRecord.HoTenSinhVien = updated.HoTenSinhVien;
        selectedRecord.ThietBi = updated.ThietBi;
        selectedRecord.SoLuong = updated.SoLuong;
        selectedRecord.NgayMuon = updated.NgayMuon;
        selectedRecord.HanTra = updated.HanTra;
        selectedRecord.NgayTraThucTe = updated.NgayTraThucTe;
        RefreshGrid();
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        if (selectedRecord is null) return;
        if (MessageBox.Show("Bạn có chắc muốn xóa phiếu đang chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        records.Remove(selectedRecord);
        RefreshGrid();
        ClearEditor();
    }

    private void btnMarkReturned_Click(object? sender, EventArgs e)
    {
        if (selectedRecord is null) return;
        chkReturned.Checked = true;
        if (!ValidateEditor()) return;

        selectedRecord.NgayTraThucTe = dtpActualReturn.Value.Date;
        RefreshGrid();
        LoadEditor(selectedRecord);
    }

    private void dgvCheckouts_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvCheckouts.CurrentRow?.DataBoundItem is CheckoutRecord record)
        {
            selectedRecord = record;
            LoadEditor(record);
        }
    }

    private CheckoutRecord ReadEditor() => new()
    {
        MaPhieu = txtReceiptCode.Text.Trim(),
        MaSinhVien = txtStudentCode.Text.Trim(),
        HoTenSinhVien = txtStudentName.Text.Trim(),
        ThietBi = cboEquipment.Text.Trim(),
        SoLuong = (int)nudQuantity.Value,
        NgayMuon = dtpBorrowDate.Value.Date,
        HanTra = dtpDueDate.Value.Date,
        NgayTraThucTe = chkReturned.Checked ? dtpActualReturn.Value.Date : null
    };

    private bool ValidateEditor()
    {
        errorProvider.Clear();
        var valid = true;
        if (string.IsNullOrWhiteSpace(txtReceiptCode.Text)) { errorProvider.SetError(txtReceiptCode, "Mã phiếu không được để trống."); valid = false; }
        if (records.Any(record => record != selectedRecord && record.MaPhieu.Equals(txtReceiptCode.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
        { errorProvider.SetError(txtReceiptCode, "Mã phiếu đã tồn tại."); valid = false; }
        if (string.IsNullOrWhiteSpace(txtStudentCode.Text)) { errorProvider.SetError(txtStudentCode, "Mã sinh viên không được để trống."); valid = false; }
        if (string.IsNullOrWhiteSpace(cboEquipment.Text)) { errorProvider.SetError(cboEquipment, "Thiết bị không được để trống."); valid = false; }
        if (nudQuantity.Value <= 0) { errorProvider.SetError(nudQuantity, "Số lượng phải lớn hơn 0."); valid = false; }
        if (dtpDueDate.Value.Date < dtpBorrowDate.Value.Date) { errorProvider.SetError(dtpDueDate, "Hạn trả không được trước ngày mượn."); valid = false; }
        if (chkReturned.Checked && dtpActualReturn.Value.Date < dtpBorrowDate.Value.Date)
        { errorProvider.SetError(dtpActualReturn, "Ngày trả thực tế không được trước ngày mượn."); valid = false; }
        return valid;
    }

    private void LoadEditor(CheckoutRecord record)
    {
        txtReceiptCode.Text = record.MaPhieu;
        txtStudentCode.Text = record.MaSinhVien;
        txtStudentName.Text = record.HoTenSinhVien;
        cboEquipment.SelectedItem = record.ThietBi;
        if (cboEquipment.SelectedIndex < 0) cboEquipment.Text = record.ThietBi;
        nudQuantity.Value = record.SoLuong;
        dtpBorrowDate.Value = record.NgayMuon;
        dtpDueDate.Value = record.HanTra;
        chkReturned.Checked = record.NgayTraThucTe.HasValue;
        dtpActualReturn.Value = record.NgayTraThucTe ?? DateTime.Today;
    }

    private void ClearEditor()
    {
        selectedRecord = null;
        errorProvider.Clear();
        txtReceiptCode.Clear();
        txtStudentCode.Clear();
        txtStudentName.Clear();
        cboEquipment.SelectedIndex = -1;
        nudQuantity.Value = 1;
        dtpBorrowDate.Value = DateTime.Today;
        dtpDueDate.Value = DateTime.Today.AddDays(7);
        chkReturned.Checked = false;
        dtpActualReturn.Value = DateTime.Today;
        dgvCheckouts.ClearSelection();
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e) => RefreshGrid();
    private void cboStatusFilter_SelectedIndexChanged(object? sender, EventArgs e) => RefreshGrid();
    private void chkReturned_CheckedChanged(object? sender, EventArgs e) => dtpActualReturn.Enabled = chkReturned.Checked;

    private void btnExport_Click(object? sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*", FileName = "phieu-muon-thiet-bi.csv" };
        if (dialog.ShowDialog() != DialogResult.OK) return;

        var visibleRecords = bindingSource.List.Cast<CheckoutRecord>();
        using var writer = new StreamWriter(dialog.FileName, false, new UTF8Encoding(true));
        writer.WriteLine("Mã phiếu,Mã sinh viên,Họ tên,Thiết bị,Số lượng,Ngày mượn,Hạn trả,Ngày trả thực tế,Tình trạng");
        foreach (var record in visibleRecords)
        {
            writer.WriteLine(string.Join(',', new[] { record.MaPhieu, record.MaSinhVien, record.HoTenSinhVien, record.ThietBi,
                record.SoLuong.ToString(CultureInfo.InvariantCulture), record.NgayMuon.ToString("dd/MM/yyyy"), record.HanTra.ToString("dd/MM/yyyy"),
                record.NgayTraThucTe?.ToString("dd/MM/yyyy") ?? string.Empty, record.TrangThai }.Select(EscapeCsv)));
        }
    }

    private static string EscapeCsv(string value) => $"\"{value.Replace("\"", "\"\"")}\"";
}
