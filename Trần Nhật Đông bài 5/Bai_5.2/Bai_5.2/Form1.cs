namespace Bai_5._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void CapNhatTien()
        {
            double tongTien = 0;

            foreach (string dichVu in lstSelectedServices.Items)
            {
                string[] tach = dichVu.Split('-');

                double gia = double.Parse(tach[tach.Length - 1]);

                tongTien += gia;
            }

            double chietKhau;

            if (!double.TryParse(txtDiscount.Text, out chietKhau))
                chietKhau = 0;

            if (chietKhau < 0)
                chietKhau = 0;

            if (chietKhau > 100)
                chietKhau = 100;

            double thanhTien = tongTien * (100 - chietKhau) / 100;

            txtSubtotal.Text = tongTien.ToString("N0");
            txtTotal.Text = thanhTien.ToString("N0");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cboCategory.Items.Add("Khám bệnh");
            cboCategory.Items.Add("Xét nghiệm");
            cboCategory.Items.Add("Chụp X-Quang");
            cboCategory.Items.Add("Vắc-xin");

            cboCategory.SelectedIndex = 0;

            txtSubtotal.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtDiscount.Text = "0";
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableServices.Items.Clear();

            if (cboCategory.Text == "Khám bệnh")
            {
                lstAvailableServices.Items.Add("Khám tổng quát - 200000");
                lstAvailableServices.Items.Add("Khám chuyên khoa - 150000");
            }
            else if (cboCategory.Text == "Xét nghiệm")
            {
                lstAvailableServices.Items.Add("Xét nghiệm máu - 100000");
                lstAvailableServices.Items.Add("Xét nghiệm nước tiểu - 80000");
            }
            else if (cboCategory.Text == "Chụp X-Quang")
            {
                lstAvailableServices.Items.Add("X-Quang tay - 120000");
                lstAvailableServices.Items.Add("X-Quang ngực - 180000");
            }
            else if (cboCategory.Text == "Vắc-xin")
            {
                lstAvailableServices.Items.Add("Vắc-xin cúm - 300000");
                lstAvailableServices.Items.Add("Vắc-xin viêm gan B - 250000");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedItem != null)
            {
                string dichVu = lstAvailableServices.SelectedItem.ToString();

                lstSelectedServices.Items.Add(dichVu);

                CapNhatTien();
            }
        }

        private void lstAvailableServices_DoubleClick(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedItem != null)
            {
                string dichVu = lstAvailableServices.SelectedItem.ToString();

                lstSelectedServices.Items.Add(dichVu);

                CapNhatTien();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelectedServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Remove(
                    lstSelectedServices.SelectedItem
                );

                CapNhatTien();
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lstSelectedServices.Items.Clear();

            CapNhatTien();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CapNhatTien();
        }
    }
}
