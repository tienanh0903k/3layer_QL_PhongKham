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
    public partial class frm_LichKham : Form
    {   
        ILichKhamBUS lk = new LichKhamBUS();
        IBenhNhanBUS bn = new BenhNhanBUS();
        IBacSiBUS bs = new BacSiBUS();
        public frm_LichKham()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dgvBenhNhan.DataSource = bn.getAll();
            dgvBacSi.DataSource = bs.getAll();
            IList<LichKham> list = lk.getAll();
            dgvLichKham.DataSource = list;
        }



        private void frm_LichKham_Load(object sender, EventArgs e)
        {
            dgvLichKham.AutoGenerateColumns = false;

            DataGridViewColumn maLKColumn = new DataGridViewTextBoxColumn();
            maLKColumn.DataPropertyName = "MaLK";
            maLKColumn.HeaderText = "Mã Lịch Khám";
            dgvLichKham.Columns.Add(maLKColumn);

            DataGridViewColumn maBNColumn = new DataGridViewTextBoxColumn();
            maBNColumn.DataPropertyName = "MaBN";
            maBNColumn.HeaderText = "Mã Bệnh Nhân";
            dgvLichKham.Columns.Add(maBNColumn);

            DataGridViewColumn tenBNColumn = new DataGridViewTextBoxColumn();
            tenBNColumn.DataPropertyName = "TenBN";
            tenBNColumn.HeaderText = "Tên Bệnh Nhân";
            dgvLichKham.Columns.Add(tenBNColumn);

            DataGridViewColumn maBSColumn = new DataGridViewTextBoxColumn();
            maBSColumn.DataPropertyName = "MaBS";
            maBSColumn.HeaderText = "Mã Bác Sĩ";
            dgvLichKham.Columns.Add(maBSColumn);

            DataGridViewColumn tenBSColumn = new DataGridViewTextBoxColumn();
            tenBSColumn.DataPropertyName = "TenBS";
            tenBSColumn.HeaderText = "Tên Bác Sĩ";
            dgvLichKham.Columns.Add(tenBSColumn);

            DataGridViewColumn ngayKhamColumn = new DataGridViewTextBoxColumn();
            ngayKhamColumn.DataPropertyName = "NgayKham";
            ngayKhamColumn.HeaderText = "Ngày Khám";
            dgvLichKham.Columns.Add(ngayKhamColumn);

            DataGridViewColumn gioKhamColumn = new DataGridViewTextBoxColumn();
            gioKhamColumn.DataPropertyName = "GioKham";
            gioKhamColumn.HeaderText = "Giờ Khám";
            dgvLichKham.Columns.Add(gioKhamColumn);
            LoadData();
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            lbDate.Text = currentDate;
        }

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBN.Text = dgvBenhNhan[0, dgvBenhNhan.CurrentCell.RowIndex].Value.ToString();
            txtTenBN.Text = dgvBenhNhan[1, dgvBenhNhan.CurrentCell.RowIndex].Value.ToString();
        }

        private void dgvBacSi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBS.Text = dgvBacSi[0, dgvBacSi.CurrentCell.RowIndex].Value.ToString();
            txtTenBS.Text = dgvBacSi[1, dgvBacSi.CurrentCell.RowIndex].Value.ToString();
        }

        private void dgvBenhNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMaLK.Text == "" || txtGioKham.Text == "")
            {
                MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int val;
                DateTime ngayHen = dptNgayHen.Value; // Lấy giá trị ngày sinh từ DateTimePicker
                int maLK = Int32.Parse(txtMaLK.Text);
                int maBN = Int32.Parse(txtMaBN.Text);
                int maBS = Int32.Parse(txtMaBS.Text);
                val = lk.Insert(new LichKham(maLK, maBN, maBS, ngayHen, txtGioKham.Text));
                LoadData();
                if (val == -1)
                {
                    MessageBox.Show("Đặt lịch không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Đặt lịch thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAdd.Text = "Thêm mới";
                }

            }
        }
    }
}
