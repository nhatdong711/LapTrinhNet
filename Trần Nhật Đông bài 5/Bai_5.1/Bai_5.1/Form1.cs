namespace Bai_5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Xóa các lỗi cũ
            epCheck.Clear();

            bool hopLe = true;

            // 1. Kiểm tra tên đăng nhập
            if (txtUsername.Text.Trim() == "")
            {
                epCheck.SetError(txtUsername, "Vui lòng nhập tên đăng nhập!");
                hopLe = false;
            }

            // 2. Kiểm tra mật khẩu
            if (txtPassword.Text == "")
            {
                epCheck.SetError(txtPassword, "Vui lòng nhập mật khẩu!");
                hopLe = false;
            }

            // 3. Kiểm tra xác nhận mật khẩu
            if (txtConfirmPassword.Text == "")
            {
                epCheck.SetError(txtConfirmPassword, "Vui lòng xác nhận mật khẩu!");
                hopLe = false;
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                epCheck.SetError(txtConfirmPassword, "Mật khẩu xác nhận không khớp!");
                hopLe = false;
            }

            // 4. Tính tuổi từ ngày sinh
            DateTime ngaySinh = dtpBirthDate.Value.Date;

            int tuoi = DateTime.Today.Year - ngaySinh.Year;

            if (ngaySinh > DateTime.Today.AddYears(-tuoi))
            {
                tuoi--;
            }

            if (tuoi < 18)
            {
                epCheck.SetError(dtpBirthDate, "Bạn phải đủ 18 tuổi!");
                hopLe = false;
            }

            // 5. Kiểm tra đồng ý điều khoản
            if (!chkTerms.Checked)
            {
                epCheck.SetError(chkTerms, "Bạn phải đồng ý với điều khoản!");
                hopLe = false;
            }

            // 6. Thông báo kết quả
            if (hopLe)
            {
                MessageBox.Show(
                    "Đăng ký tài khoản thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            dtpBirthDate.Value = DateTime.Today;

            rdoMale.Checked = false;
            rdoFemale.Checked = false;

            chkTerms.Checked = false;

            epCheck.Clear();

            txtUsername.Focus();
        }
    }
}
