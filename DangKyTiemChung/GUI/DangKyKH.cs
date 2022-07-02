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
    public partial class DangKyKH : Form
    {
        public DangKyKH()
        {
            InitializeComponent();
        }

        private void DangKyKH_Load(object sender, EventArgs e)
        {
            label10.Hide();
            label7.Hide();
            label8.Hide();
            mqh.Hide();
            sdtngh.Hide();
            tenngh.Hide();

        }

        private void xacnhan_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ten.Text) || String.IsNullOrEmpty(diachi.Text) || String.IsNullOrEmpty(sdt.Text))
            {
                MessageBox.Show("Vui lòng nhập đâỳ đủ thông tin");
            }
            else if (radioButton3.Checked == true && (String.IsNullOrEmpty(tenngh.Text) || String.IsNullOrEmpty(sdtngh.Text)))
            {
                MessageBox.Show("Vui lòng nhập đâỳ đủ thông tin");

            }
            else
            {

                string _hoten = ten.Text;
                string _gioitinh = null;
                DateTime _ngaysinh = ngaysinh.Value.Date;
                if (radioButton1.Checked == true)
                {
                    _gioitinh = "Nam";
                }
                else if (radioButton2.Checked == true)
                {
                    _gioitinh = "Nữ";

                }
                string _diachi = diachi.Text;
                string _sdt = sdt.Text;
                string _hoten_ngh = tenngh.Text;
                string _mqh = mqh.Text;
                string _sdt_ngh = sdtngh.Text;
                string _makh = "KH" + (KhachHang.CountKH() + 1).ToString();
                KhachHang kh = new KhachHang(_makh, _hoten, _gioitinh, _ngaysinh, _diachi, _sdt);
                try
                {
                    bool checkkh = KhachHang.ThemKH(kh);
                    bool checkngh = false;
                    if (radioButton3.Checked == true)
                    {
                        NguoiGiamHo ngh = new NguoiGiamHo(_makh, _hoten_ngh, _mqh, _sdt_ngh);
                        checkngh = NguoiGiamHo.ThemNGH(ngh);
                    }
                    if (checkkh == true && checkngh == true)
                    {
                        MessageBox.Show("Thêm thành công!");
                    }
                    else if (checkkh == true && radioButton3.Checked == false)
                    {
                        MessageBox.Show("Thêm thành công!");
                    }
                    else
                        MessageBox.Show("ERROR!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR!");
                }
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                radioButton3.Checked = false;
                label10.Hide();
                label7.Hide();
                label8.Hide();
                mqh.Hide();
                sdtngh.Hide();
                tenngh.Hide();
            }
            else
            {
                radioButton3.Checked = true;
                label10.Show();
                label7.Show();
                label8.Show();
                mqh.Show();
                sdtngh.Show();
                tenngh.Show();
            }
        }

        private void sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sdtngh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
