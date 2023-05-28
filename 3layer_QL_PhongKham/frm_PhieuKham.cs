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
using Entities;
using BUS;


namespace _3layer_QL_PhongKham
{
    public partial class frm_PhieuKham : Form
    {
        IBenhNhanBUS bn = new BenhNhanBUS();
        IPhieuKhamBUS pk = new PhieuKhamBUS();
        IThuocBUS t = new ThuocBUS();
        public frm_PhieuKham()
        {
            InitializeComponent();
        }

        private void frm_PhieuKham_Load(object sender, EventArgs e)
        {
            cboMaPK.DisplayMember = "MaPK";
            cboMaPK.ValueMember = "MaPK";
            cboMaPK.DataSource = pk.GetAllPhieuKhamID();
            LoadData();
        }

        public void LoadData()
        {
            dgvThuoc.DataSource = t.GetAll();

        }
        private void btnIn_Click(object sender, EventArgs e)
        {


            //int maBN;
            //if (int.TryParse(txtMaBN.Text, out maBN))
            //{
            //    DataTable dt = bn.GetXetNghiemByMaBenhNhan(maBN);

            //    if (dt.Rows.Count > 0)
            //    {
            //        ChiTietHD r = new ChiTietHD();
            //        r.SetDataSource(dt);

            //        frmInPK f = new frmInPK();
            //        f.crystalReportViewer1.ReportSource = r;
            //        f.ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không tìm thấy thông tin xét nghiệm cho mã bệnh nhân này.");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng nhập mã bệnh nhân là một số nguyên.");
            //}


        }


        private void button1_Click(object sender, EventArgs e)
        {
            int maBN;
            if (int.TryParse(txtmaBN.Text, out maBN))
            {
                DataTable dt = bn.GetXetNghiemByMaBenhNhan(maBN);

                if (dt.Rows.Count > 0)
                {
                    ChiTietHD r = new ChiTietHD();
                    r.SetDataSource(dt);

                    frmInPK f = new frmInPK();
                    f.crystalReportViewer1.ReportSource = r;
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin xét nghiệm cho mã bệnh nhân này.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã bệnh nhân là một số nguyên.");
            }
        }

        private void cboMaPK_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maPhieuKham = Convert.ToInt32(cboMaPK.SelectedValue);
            DataTable phieuKhamInfo = pk.GetPhieuKhamInfo(maPhieuKham);
            string maBenhNhan = phieuKhamInfo.Rows[0]["ma_benh_nhan"].ToString();
            string ketQua = phieuKhamInfo.Rows[0]["ket_qua"].ToString();
            txtmaBN.Text = maBenhNhan;
            txtKetLuan.Text = ketQua;

        }

        private void cboMaPK_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int maPhieuKham = Convert.ToInt32(cboMaPK.SelectedValue);
            DataTable phieuKhamInfo = pk.GetPhieuKhamInfo(maPhieuKham);
            string maBenhNhan = phieuKhamInfo.Rows[0]["ma_benh_nhan"].ToString();
            string ketQua = phieuKhamInfo.Rows[0]["ket_qua"].ToString();
            decimal totalGiaXN = 0;
            foreach (DataRow row in phieuKhamInfo.Rows)
            {
                decimal giaXN = Convert.ToDecimal(row["gia_xn"]);
                totalGiaXN += giaXN;
            }
            txtmaBN.Text = maBenhNhan;
            txtKetLuan.Text = ketQua;
            txtGiaXN.Text = totalGiaXN.ToString();

            
        }


        private void dgvThuoc_Click(object sender, EventArgs e)
        {
            txtGiaThuoc.Text = dgvThuoc[5, dgvThuoc.CurrentCell.RowIndex].Value.ToString();
        }
        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void soLuong_ValueChanged(object sender, EventArgs e)
        {

            int donGia;
            int giaXN;

            if (int.TryParse(txtGiaThuoc.Text, out donGia) && int.TryParse(txtGiaXN.Text, out giaXN))
            {
                int sl = (int)soLuong.Value;
                int tongTien = donGia * sl + giaXN;
                txtTongTien.Text = tongTien.ToString();
            }
            else
            {
                MessageBox.Show("Vuot qua gioi han san pham!");
            }

        }








        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            int maBN;
            if (int.TryParse(txtmaBN.Text, out maBN))
            {
                DataTable dt = bn.GetXetNghiemByMaBenhNhan(maBN);

                if (dt.Rows.Count > 0)
                {
                    ChiTietHD r = new ChiTietHD();
                    r.SetDataSource(dt);

                    frmInPK f = new frmInPK();
                    f.crystalReportViewer1.ReportSource = r;
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin xét nghiệm cho mã bệnh nhân này.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã bệnh nhân là một số nguyên.");
            }
        }
    }
}
