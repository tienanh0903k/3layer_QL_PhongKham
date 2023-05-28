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

namespace _3layer_QL_PhongKham
{
    public partial class frm_Login : Form
    {
         ITaiKhoanBUS tk = new TaiKhoanBUS();
        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtTenDN.Text.Trim();
            string password = txtMatKhau.Text;

            bool isAuthenticated = tk.CheckLogin(username, password);

            if (isAuthenticated)
            {
                
                // Lấy tên người đăng nhập
                string quyen = tk.GetQuyen(username, password);
                frm_Main main = new frm_Main(username, quyen);
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!");
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                // Hiển thị mật khẩu
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                // Ẩn mật khẩu
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
    }
}
