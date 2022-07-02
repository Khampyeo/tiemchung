using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DangKyTiemChung.DAL;

namespace DangKyTiemChung.GUI
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void dn_Click(object sender, EventArgs e)
        {
            string tk = taikhoan.Text.ToString();
            string mk = matkhau.Text.ToString();
            if (TaiKhoan.GetRole(tk, mk) == "nhanvien" && TaiKhoan.GetRoleNhanVien(tk, mk) == "Hướng dẫn")
            {
                TraCuu tc = new TraCuu();
                this.Hide();
                tc.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("tài khoản hoặc mật khẩu không đúng!");
        }
    }
}
