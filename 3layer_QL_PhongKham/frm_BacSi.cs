using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BUS;

namespace _3layer_QL_PhongKham
{
    public partial class frm_BacSi : Form
    {
        ITaiKhoanBUS tk = new TaiKhoanBUS();
        IBacSiBUS bs = new BacSiBUS();
        private string role;
        public frm_BacSi(string role)
        {
            InitializeComponent();
            this.role = role;
        }

        public void LoadData()
        {
            dgvBacSi.DataSource = bs.getAll();
            if (role == "admin")
            {
                txtDiaChi.Enabled = true;
            }
            else
            {
                txtDiaChi.Enabled = false;
            }
        }

        private void frm_BacSi_Load(object sender, EventArgs e)
        {
            IList<TaiKhoan> taiKhoans = tk.GetAllTaiKhoanID();

            foreach (TaiKhoan taiKhoan in taiKhoans)
            {
                cboListAccount.Items.Add(taiKhoan.MaTK);
            }
            LoadData();
            dgvBacSi.CellValueChanged += dgvBacSi_CellValueChanged;     

        }

        private void cboListAccount_TextChanged(object sender, EventArgs e)
        {
            string selectedMaTK = cboListAccount.SelectedItem.ToString();
            string tenTK = tk.GetTenTK(selectedMaTK);
            // Hiển thị tên tài khoản
            txtTenBS.Text = tenTK;
        }

        private void dgvBacSi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            
        }

        private void dgvBacSi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) // Giả sử cột Mã có chỉ số 0
            {
                string ma = dgvBacSi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Kiểm tra nếu mã đã tồn tại trong DataGridView
                if (ma == "DT02")
                {
                    // Ẩn mục trong ComboBox
                    cboListAccount.Items.Remove("DT02");
                }
                else
                {
                    // Đảm bảo rằng mục đã được thêm trước đó nếu chưa tồn tại trong ComboBox
                    if (!comboBox1.Items.Contains(ma))
                    {
                        cboListAccount.Items.Add(ma);
                    }
                }
            }
        }
    }
}
