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
    public partial class MHGoiTiem : Form
    {
        public string magt;
        public string tengt;
        public int giatien;
        public static List<GoiTiem> listgt = new List<GoiTiem>();
        public MHGoiTiem()
        {
            InitializeComponent();
        }

        private void GoiTiem_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            GoiTiem.LayDS_GT().Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void them_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(magt))
            {
                GoiTiem gt = new GoiTiem(magt, tengt, giatien);
                if (GoiTiem.CheckExist(MHGoiTiem.listgt, gt))
                {
                    MessageBox.Show("Đã có trong danh sách");
                }
                else
                {
                    listgt.Add(gt);
                    MessageBox.Show("Thêm thành công");
                }

            }
            else
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                magt = dataGridView1.Rows[e.RowIndex].Cells["MaGTC"].FormattedValue.ToString();
                tengt = dataGridView1.Rows[e.RowIndex].Cells["TenGoiTiem"].FormattedValue.ToString();
                giatien = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["GiaTien"].FormattedValue.ToString());
            }
        }
    }
}
