using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3layer_QL_PhongKham
{
    public partial class frm_Main : Form
    {
        private Timer timer;

        private string username;
        private string quyen;
        public frm_Main(string username, string quyen)
        {
            InitializeComponent();
            this.username = username;
            this.quyen = quyen;
        }

        private void tsmUser_Click(object sender, EventArgs e)
        {
            if (quyen.Trim() == "admin")
            {
                frm_TaiKhoan tk = new frm_TaiKhoan();
                tk.ShowDialog();

            }

            else
            {
                tsmTaikhoan.Enabled = false;    
            }
           
          
        }
        frm_BenhNhan benhnhan = null;
        frm_BacSi bacsi = null;

        private void tSBenhNhan_Click(object sender, EventArgs e)
        {
            if (benhnhan == null || benhnhan.IsDisposed) // Kiểm tra form đã tồn tại hoặc đã bị hủy
            {
                string role = quyen.Trim();
                benhnhan = new frm_BenhNhan(role);
                benhnhan.MdiParent = this;
                benhnhan.Show();
            }
            else
            {
                benhnhan.BringToFront(); // Đưa form đã tồn tại lên phía trước
            }
        }

        private void tsHome_Click(object sender, EventArgs e)
        {
            Form activeChildForm = this.ActiveMdiChild;
            if (activeChildForm != null)
            {
                activeChildForm.Hide(); // Ẩn form con hiện tại
            }
            frm_BenhNhan benhnhan = null;
            frm_BacSi bacsi = null;

        }


        private void tsmLogout_Click(object sender, EventArgs e)
        {
            this.Close(); 
            Application.Restart();
        }


        private void tsBacSi_Click(object sender, EventArgs e)
        {
            if (bacsi == null) // Kiểm tra form đã tồn tại hoặc đã bị hủy
            {
                string role = quyen.Trim();
                bacsi = new frm_BacSi(role);
                bacsi.MdiParent = this;
                bacsi.Show();
            }
            else
            {
                bacsi.BringToFront(); // Đưa form đã tồn tại lên phía trước
            }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            lbUser.Text = username;
            lbRole.Text = quyen;

            if (quyen.Trim() == "admin")
            {
                tsmTaikhoan.Enabled = true;
            }

            else
            {
                tsmTaikhoan.Visible = false;
            }

            //Load thoi gian
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Cập nhật giá trị hiển thị của label thành giờ hiện tại
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }


        private void tsmLichKham_Click(object sender, EventArgs e)
        {
            if (quyen.Trim() == "admin")
            {
                frm_LichKham lk = new frm_LichKham();
                lk.Show();

            }
            else
            {
                MessageBox.Show($"Giá trị của quyền:'{quyen.Trim().Length}'");

            }
        }

        private void tsmThongke_Click(object sender, EventArgs e)
        {
            frm_ThongKe thongke = new frm_ThongKe();
            thongke.Show();
        }

        private void tsbThuoc_Click(object sender, EventArgs e)
        {
             
            
            frm_Thuoc thuoc = new frm_Thuoc();
            thuoc.MdiParent = this;
            thuoc.Show();
        }

        private void tsXetNghiem_Click(object sender, EventArgs e)
        {
            frm_XetNghiem xn = new frm_XetNghiem();
            xn.MdiParent = this;
            xn.Show();
        }

        private void tslPhieuKham_Click(object sender, EventArgs e)
        {
            frm_PhieuKham pk = new frm_PhieuKham();
            pk.MdiParent = this;
            pk.Show();
        }
    }
}

