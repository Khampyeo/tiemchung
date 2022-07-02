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
    public partial class TraCuu : Form
    {
        public static string makh = null;
        public static string hoten = null;

        public TraCuu()
        {
            InitializeComponent();
        }

        private void xem_Click(object sender, EventArgs e)
        {
            XemThongTinKH f = new XemThongTinKH();
            f.ShowDialog();
        }

        private void lapphieu_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(makh))
            {
            LapPhieuTiem f = new LapPhieuTiem();
            f.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void dangky_Click(object sender, EventArgs e)
        {
            DangKyKH f = new DangKyKH();
            f.ShowDialog();
        }

        private void TraCuu_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            KhachHang.LayDS_KH().Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView1.CurrentRow.Selected = true;
                    makh = dataGridView1.Rows[e.RowIndex].Cells["MaKH"].FormattedValue.ToString();
                    hoten = dataGridView1.Rows[e.RowIndex].Cells["HoTen"].FormattedValue.ToString();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string info = textBox1.Text;
            DataTable dt = new DataTable();
            KhachHang.TraCuuKH(info).Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
