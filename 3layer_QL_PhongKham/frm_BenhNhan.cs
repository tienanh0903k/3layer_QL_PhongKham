using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Entities;

namespace _3layer_QL_PhongKham
{
    public partial class frm_BenhNhan : Form
    {
        private string role;
        IBenhNhanBUS bn = new BenhNhanBUS();
        public frm_BenhNhan(string role)
        {
            InitializeComponent();
            this.role = role;
        }


        public void LoadData()
        {
            dgvBenhNhan.DataSource = bn.getAll();
        }

        private void frmBenhNhan_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (role == "admin")
            {

                if (txttenBN.Text == "" || txtGioitinh.Text == "")
                {
                    MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int val;
                    DateTime ngaySinh = dtpNgaySinh.Value; // Lấy giá trị ngày sinh từ DateTimePicker
                    int maBN = Int32.Parse(txtMaBN.Text);
                    val = bn.Insert(new BenhNhan(txttenBN.Text, ngaySinh, txtGioitinh.Text, txtDiaChi.Text, txtSDT.Text, maBN));
                    LoadData();
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
            else

            {
                MessageBox.Show("Ban ko co quyen them");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int val = bn.Delete(int.Parse(txtMaBN.Text));
                LoadData();
                if (val == -1)
                    MessageBox.Show("Xóa dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Xuất viện thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không xóa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvBenhNhan_Click(object sender, EventArgs e)
        {

            txtMaBN.Text = dgvBenhNhan[0, dgvBenhNhan.CurrentCell.RowIndex].Value.ToString();
            txttenBN.Text = dgvBenhNhan[1, dgvBenhNhan.CurrentCell.RowIndex].Value.ToString();
            DateTime ngaySinh;
            if (DateTime.TryParse(dgvBenhNhan[2, dgvBenhNhan.CurrentRow.Index].Value.ToString(), out ngaySinh))
            {
                dtpNgaySinh.Value = ngaySinh;
            }
            txtGioitinh.Text = dgvBenhNhan[3, dgvBenhNhan.CurrentCell.RowIndex].Value.ToString();
            txtDiaChi.Text = dgvBenhNhan[4, dgvBenhNhan.CurrentCell.RowIndex].Value.ToString();
            txtSDT.Text = dgvBenhNhan[5, dgvBenhNhan.CurrentCell.RowIndex].Value.ToString();

        }

        private void LamMoi_Click(object sender, EventArgs e)
        {
            txtMaBN.Text = "";
            txttenBN.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            txtGioitinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BenhNhan b = new BenhNhan();
            b.MaBN = int.Parse(txtMaBN.Text);
            b.TenBN = txttenBN.Text;
            b.Ngaysinh = dtpNgaySinh.Value;
            b.Gioitinh = txtGioitinh.Text;
            b.Diachi = txtDiaChi.Text;
            b.SoDT = txtSDT.Text;
            try
            {
                int val = bn.Update(b);
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
           
        private void btnKetXuatWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin lớp";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bn.KetXuatWord(@"Template\BenhNhan.docx", saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemBN.Text;
            IList<BenhNhan> danhSachBenhNhan = bn.TimKiem(tuKhoa);
            dgvBenhNhan.DataSource = danhSachBenhNhan;
        }
    }
}
