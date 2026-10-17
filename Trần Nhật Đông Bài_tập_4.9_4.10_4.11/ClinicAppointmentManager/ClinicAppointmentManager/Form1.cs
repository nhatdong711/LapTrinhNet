using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace ClinicAppointmentManager;

public sealed class Appointment : INotifyPropertyChanged
{
    private string _id = string.Empty;
    private string _patientName = string.Empty;
    private string _phone = string.Empty;
    private DateTime _appointmentDate = DateTime.Now.AddHours(1);
    private string _doctor = string.Empty;
    private string _reason = string.Empty;
    private string _status = "Chờ khám";

    public string Id { get => _id; set => SetField(ref _id, value); }
    public string PatientName { get => _patientName; set => SetField(ref _patientName, value); }
    public string Phone { get => _phone; set => SetField(ref _phone, value); }
    public DateTime AppointmentDate { get => _appointmentDate; set => SetField(ref _appointmentDate, value); }
    public string Doctor { get => _doctor; set => SetField(ref _doctor, value); }
    public string Reason { get => _reason; set => SetField(ref _reason, value); }
    public string Status { get => _status; set => SetField(ref _status, value); }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void SetField<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public partial class Form1 : Form
{
    private readonly BindingList<Appointment> _appointments = new();
    private readonly BindingSource _bindingSource = new();
    private Appointment? _selectedAppointment;
    private bool _isLoading;

    private static readonly string[] Doctors = ["BS. Nguyễn Minh Anh", "BS. Trần Hoàng Nam", "BS. Lê Thu Hà", "BS. Phạm Quốc Bảo"];
    private static readonly string[] Statuses = ["Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy"];

    public Form1()
    {
        InitializeComponent();
        ConfigureData();
        LoadSampleData();
        ResetForm();
        ApplyFilters();
    }

    private void ConfigureData()
    {
        cboDoctor.Items.AddRange(Doctors);
        cboStatus.Items.AddRange(Statuses);
        cboFilterStatus.Items.Add("Tất cả trạng thái");
        cboFilterStatus.Items.AddRange(Statuses);
        cboFilterStatus.SelectedIndex = 0;
        dtpFilterDate.Value = DateTime.Today;
        dtpAppointmentDate.MinDate = DateTime.Today;
        dtpAppointmentDate.Value = DateTime.Now.AddHours(1);
        _bindingSource.DataSource = new BindingList<Appointment>();
        gridAppointments.DataSource = _bindingSource;
    }

    private void LoadSampleData()
    {
        _appointments.Add(new Appointment { Id = "LH-202501", PatientName = "Nguyễn Minh Tú", Phone = "0901234567", AppointmentDate = DateTime.Today.AddHours(9), Doctor = Doctors[0], Reason = "Khám tổng quát", Status = "Chờ khám" });
        _appointments.Add(new Appointment { Id = "LH-202502", PatientName = "Trần Ngọc Mai", Phone = "0912345678", AppointmentDate = DateTime.Today.AddHours(10.5), Doctor = Doctors[1], Reason = "Đau đầu kéo dài", Status = "Đang khám" });
        _appointments.Add(new Appointment { Id = "LH-202503", PatientName = "Lê Quốc Huy", Phone = "0987654321", AppointmentDate = DateTime.Today.AddHours(14), Doctor = Doctors[2], Reason = "Tái khám", Status = "Hoàn tất" });
    }

    private void ApplyFilters()
    {
        var keyword = txtSearch.Text.Trim();
        var date = dtpFilterDate.Value.Date;
        var status = cboFilterStatus.SelectedItem?.ToString();
        var filtered = _appointments.Where(a =>
            a.AppointmentDate.Date == date &&
            (string.IsNullOrWhiteSpace(keyword) || a.PatientName.Contains(keyword, StringComparison.OrdinalIgnoreCase) || a.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(status) || status == "Tất cả trạng thái" || a.Status == status))
            .OrderBy(a => a.AppointmentDate)
            .ToList();

        _bindingSource.DataSource = new BindingList<Appointment>(filtered);
        lblResultCount.Text = $"{filtered.Count} lịch hẹn đang hiển thị";
        lblFilterSummary.Text = $"Ngày {date:dd/MM/yyyy}  •  {filtered.Count} kết quả";
    }

    private void GridAppointments_SelectionChanged(object? sender, EventArgs e)
    {
        if (_isLoading || gridAppointments.CurrentRow?.DataBoundItem is not Appointment appointment) return;
        _selectedAppointment = appointment;
        _isLoading = true;
        txtAppointmentId.Text = appointment.Id;
        txtPatientName.Text = appointment.PatientName;
        txtPhone.Text = appointment.Phone;
        dtpAppointmentDate.Value = appointment.AppointmentDate < dtpAppointmentDate.MinDate ? dtpAppointmentDate.MinDate : appointment.AppointmentDate;
        cboDoctor.SelectedItem = appointment.Doctor;
        txtReason.Text = appointment.Reason;
        cboStatus.SelectedItem = appointment.Status;
        lblFormMode.Text = "ĐANG CHỈNH SỬA LỊCH HẸN";
        btnSave.Text = "  Lưu thay đổi";
        _isLoading = false;
    }

    private void SearchOrFilterChanged(object? sender, EventArgs e) => ApplyFilters();

    private void NewAppointment(object? sender, EventArgs e) => ResetForm();

    private void ResetForm()
    {
        _isLoading = true;
        _selectedAppointment = null;
        txtAppointmentId.Clear();
        txtPatientName.Clear();
        txtPhone.Clear();
        dtpAppointmentDate.Value = DateTime.Now.AddHours(1) < dtpAppointmentDate.MinDate ? dtpAppointmentDate.MinDate : DateTime.Now.AddHours(1);
        cboDoctor.SelectedIndex = 0;
        txtReason.Clear();
        cboStatus.SelectedIndex = 0;
        lblFormMode.Text = "TẠO LỊCH HẸN MỚI";
        btnSave.Text = "  Thêm lịch hẹn";
        errorProvider.Clear();
        _isLoading = false;
    }

    private bool ValidateAppointment()
    {
        errorProvider.Clear();
        var valid = true;
        if (string.IsNullOrWhiteSpace(txtAppointmentId.Text)) { errorProvider.SetError(txtAppointmentId, "Vui lòng nhập mã lịch hẹn."); valid = false; }
        else if (_appointments.Any(a => a.Id.Equals(txtAppointmentId.Text.Trim(), StringComparison.OrdinalIgnoreCase) && a != _selectedAppointment)) { errorProvider.SetError(txtAppointmentId, "Mã lịch hẹn đã tồn tại."); valid = false; }
        if (string.IsNullOrWhiteSpace(txtPatientName.Text)) { errorProvider.SetError(txtPatientName, "Vui lòng nhập họ tên bệnh nhân."); valid = false; }
        if (string.IsNullOrWhiteSpace(txtPhone.Text) || !IsValidPhone(txtPhone.Text)) { errorProvider.SetError(txtPhone, "Số điện thoại phải có 10–11 chữ số."); valid = false; }
        if (dtpAppointmentDate.Value < DateTime.Now) { errorProvider.SetError(dtpAppointmentDate, "Ngày giờ hẹn không được trong quá khứ."); valid = false; }
        if (string.IsNullOrWhiteSpace(txtReason.Text)) { errorProvider.SetError(txtReason, "Vui lòng nhập lý do khám."); valid = false; }
        return valid;
    }

    private static bool IsValidPhone(string phone) => phone.All(char.IsDigit) && phone.Length is >= 10 and <= 11 && phone[0] == '0';

    private void SaveAppointment(object? sender, EventArgs e)
    {
        if (!ValidateAppointment()) return;
        var appointment = _selectedAppointment ?? new Appointment();
        appointment.Id = txtAppointmentId.Text.Trim();
        appointment.PatientName = txtPatientName.Text.Trim();
        appointment.Phone = txtPhone.Text.Trim();
        appointment.AppointmentDate = dtpAppointmentDate.Value;
        appointment.Doctor = cboDoctor.Text;
        appointment.Reason = txtReason.Text.Trim();
        appointment.Status = cboStatus.Text;
        if (_selectedAppointment is null) _appointments.Add(appointment);
        MessageBox.Show(_selectedAppointment is null ? "Đã thêm lịch hẹn thành công." : "Đã cập nhật lịch hẹn.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ApplyFilters();
        ResetForm();
    }

    private void DeleteAppointment(object? sender, EventArgs e)
    {
        if (gridAppointments.CurrentRow?.DataBoundItem is not Appointment appointment) return;
        if (MessageBox.Show($"Bạn có chắc muốn xóa lịch hẹn của {appointment.PatientName}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
        _appointments.Remove(appointment);
        ApplyFilters();
        ResetForm();
    }

    private void ExportCsv(object? sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv", FileName = $"lich-hen-{DateTime.Now:yyyyMMdd-HHmm}.csv", Title = "Xuất danh sách lịch hẹn" };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        var appointments = (_bindingSource.List as IEnumerable<Appointment>) ?? [];
        var csv = new StringBuilder();
        csv.AppendLine("Mã lịch hẹn,Họ tên bệnh nhân,Số điện thoại,Ngày giờ hẹn,Bác sĩ,Lý do khám,Trạng thái");
        foreach (var a in appointments) csv.AppendLine(string.Join(',', new[] { a.Id, a.PatientName, a.Phone, a.AppointmentDate.ToString("dd/MM/yyyy HH:mm"), a.Doctor, a.Reason, a.Status }.Select(EscapeCsv)));
        File.WriteAllText(dialog.FileName, csv.ToString(), new UTF8Encoding(true));
        MessageBox.Show("Đã xuất danh sách ra tệp CSV.", "Xuất thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private static string EscapeCsv(string value) => $"\"{value.Replace("\"", "\"\"")}\"";
}
