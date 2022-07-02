using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DangKyTiemChung.BLL;

namespace DangKyTiemChung.GUI
{
    public partial class XemThongTinKH : Form
    {
        public XemThongTinKH()
        {
            InitializeComponent();
        }

        private void XemThongTinKH_Load(object sender, EventArgs e)
        {
            try
            {

            KhachHang kh = KhachHang.LayTT_KH(TraCuu.makh);         
            makh.Text = kh._makh;
            ten.Text = kh._hoten;
            diachi.Text = kh._diachi;
            sdt.Text = kh._sdt;
            dateTimePicker1.Value = kh._ngaysinh;
            if (kh._gioitinh == "Nam")
            {
                radioButton1.Checked = true;
            }
            else
                radioButton2.Checked = true;
            if(NguoiGiamHo.CheckNGH(TraCuu.makh) == true)
            {
                NguoiGiamHo ngh = NguoiGiamHo.LayTT_NGH(TraCuu.makh);
                tenngh.Text = ngh._hoten;
                mqh.Text = ngh._mqh;
                sdtngh.Text = ngh._sdt;
            }
            else
            {
                tenngh.Hide();
                mqh.Hide();
                sdtngh.Hide();
                label6.Hide();
                label7.Hide();
                label8.Hide();
                label10.Hide();
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR!");
                this.Close();
            }
                 
        }

        private void lapphieu_Click(object sender, EventArgs e)
        {
            XemPhieuTiem f = new XemPhieuTiem();
            f.ShowDialog();
        }
    }
}
