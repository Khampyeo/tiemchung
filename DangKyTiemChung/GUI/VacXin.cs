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
    public partial class MHVacXin : Form
    {
        public string mavx;
        public string tenvx;
        public int giatien;
        public static List<VacXin> listvx = new List<VacXin>();
        public MHVacXin()
        {
            InitializeComponent();
        }

        private void VacXin_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            VacXin.LayDS_VX().Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void them_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(mavx))
            {
                VacXin vx = new VacXin(mavx, tenvx, giatien);
                if (VacXin.CheckExist(MHVacXin.listvx, vx))
                {
                    MessageBox.Show("Đã có trong danh sách");
                }
                else
                {
                    listvx.Add(vx);
                    MessageBox.Show("Thêm thành công");
                }

            }
            else
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView1.CurrentRow.Selected = true;
                    mavx = dataGridView1.Rows[e.RowIndex].Cells["MaVX"].FormattedValue.ToString();
                    tenvx = dataGridView1.Rows[e.RowIndex].Cells["TenVacXin"].FormattedValue.ToString();
                    giatien = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["GiaTien"].FormattedValue.ToString());
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
