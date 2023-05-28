using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Entities;


namespace _3layer_QL_PhongKham
{
    public partial class frm_XetNghiem : Form
    {
        IBenhNhanBUS bn = new BenhNhanBUS();
        IXetNghiemBUS xn = new XetNghiemBUS();
        public frm_XetNghiem()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            dgvXetNghiem.DataSource = xn.GetAll();
            dgvBenhNhan.DataSource = bn.getAll();
            
        }
        private void frm_XetNghiem_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtHoTenTK.Text;

            // Gọi phương thức tìm kiếm từ BLL
            IList<BenhNhan> danhSachBenhNhan = bn.TimKiem(tuKhoa);
            dgvBenhNhan.DataSource = danhSachBenhNhan;

            dgvBenhNhan.Rows[0].Selected = true;
            dgvBenhNhan.CurrentCell = dgvBenhNhan.Rows[0].Cells[0];
            dgvBenhNhan_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
            
            

        }

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBenhNhan.Rows.Count)
            {
                txtMaBN.Text = dgvBenhNhan[0, e.RowIndex].Value.ToString();
                txtHoTen.Text = dgvBenhNhan[1, e.RowIndex].Value.ToString();
                txtGioiTinh.Text = dgvBenhNhan[3, e.RowIndex].Value.ToString();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            IList<BenhNhan> danhSachBenhNhan = bn.getAll();
            dgvBenhNhan.DataSource = danhSachBenhNhan;
            // Xóa lựa chọn hiện tại
            dgvBenhNhan.ClearSelection();
        }
    }
}
