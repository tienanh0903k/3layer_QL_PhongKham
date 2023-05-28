using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Entities;

namespace _3layer_QL_PhongKham
{
    public partial class frm_TaiKhoan : Form
    {
        ITaiKhoanBUS tk = new TaiKhoanBUS();
        public frm_TaiKhoan()
        {
            InitializeComponent();
        }


        public void LoadData()
        {
            dgvTaiKhoan.DataSource = tk.getAll();
        }


        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }



        private void exitForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTenTK.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int val;   
                val = tk.Insert(new TaiKhoan(txtMaTK.Text ,txtTenTK.Text, txtMatKhau.Text, cboQuyen.SelectedItem.ToString()));
                LoadData();
                Reset();
                if (val == -1)  
                {
                    MessageBox.Show("Thêm dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Đã thêm dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAdd.Text = "Thêm mới";
                }

            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int val = tk.Delete(txtMaTK.Text);
                LoadData();
                if (val == -1)
                    MessageBox.Show("Xóa dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Đã xóa dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không xóa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void Reset()
        {
            txtMaTK.Text = "";
            txtTenTK.Text = "";
            txtMatKhau.Text = "";
            cboQuyen.SelectedIndex = -1;
        }

        private void dgvTaiKhoan_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtMaTK.Text = row.Cells[0].Value.ToString();
                txtTenTK.Text = row.Cells[1].Value.ToString();
                txtMatKhau.Text = row.Cells[2].Value.ToString();
                string quyen = row.Cells[3].Value.ToString();
                cboQuyen.Items.Add(quyen);
                cboQuyen.SelectedItem = quyen;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            taikhoan.MaTK = txtMaTK.Text;
            taikhoan.TenTK = txtTenTK.Text;
            taikhoan.MatKhau = txtMatKhau.Text;
            taikhoan.Quyen = cboQuyen.SelectedItem.ToString();
           
            try
            {
                int val = tk.Update(taikhoan);
                LoadData();
                if (val == -1)
                    MessageBox.Show("Sửa dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Đã sửa dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Không sửa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            taikhoan.MaTK = txtMaTK.Text;
            taikhoan.TenTK = txtTenTK.Text;
            taikhoan.MatKhau = txtMatKhau.Text;
            taikhoan.Quyen = cboQuyen.SelectedItem.ToString();

            try
            {
                int val = tk.Update(taikhoan);
                LoadData();
                if (val == -1)
                    MessageBox.Show("Sửa dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Đã sửa dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Không sửa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
