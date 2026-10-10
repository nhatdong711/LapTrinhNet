using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
namespace Bai_5._3
{
    public partial class Form1 : Form
    {
        List<Product> products = new List<Product>();
        BindingSource source = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboCategory.Items.Add("Điện tử");
            cboCategory.Items.Add("Gia dụng");
            cboCategory.Items.Add("Thực phẩm");
            cboCategory.SelectedIndex = 0;

            source.DataSource = products;
            dgvProducts.DataSource = source;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem số lượng có phải là số hợp lệ và lớn hơn hoặc bằng 0 không
            if (!int.TryParse(txtQuantity.Text.Trim(), out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên và không được nhỏ hơn 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }
            Product p = new Product();

            p.ProductId = txtProductId.Text;
            p.ProductName = txtProductName.Text;
            p.UnitPrice = double.Parse(txtUnitPrice.Text);
            p.Quantity = int.Parse(txtQuantity.Text);
            p.Category = cboCategory.Text;

            products.Add(p);
            source.ResetBindings(false);

            MessageBox.Show("Thêm sản phẩm thành công!");
            
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProductId.Text = dgvProducts.Rows[e.RowIndex]
                    .Cells["ProductId"].Value.ToString();

                txtProductName.Text = dgvProducts.Rows[e.RowIndex]
                    .Cells["ProductName"].Value.ToString();

                txtUnitPrice.Text = dgvProducts.Rows[e.RowIndex]
                    .Cells["UnitPrice"].Value.ToString();

                txtQuantity.Text = dgvProducts.Rows[e.RowIndex]
                    .Cells["Quantity"].Value.ToString();

                cboCategory.Text = dgvProducts.Rows[e.RowIndex]
                    .Cells["Category"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem số lượng có phải là số hợp lệ và lớn hơn hoặc bằng 0 không
            if (!int.TryParse(txtQuantity.Text.Trim(), out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên và không được nhỏ hơn 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }
            if (dgvProducts.CurrentRow == null ||
        dgvProducts.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sản phẩm này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                int index = dgvProducts.CurrentRow.Index;

                products.RemoveAt(index);
                source.ResetBindings(false);

                MessageBox.Show("Đã xóa sản phẩm!");
            }
        }
    }
}
