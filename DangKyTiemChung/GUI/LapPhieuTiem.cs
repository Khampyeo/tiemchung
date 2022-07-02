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
    public partial class LapPhieuTiem : Form
    {
        private int _stt = -1;

        public LapPhieuTiem()
        {
            InitializeComponent();
        }

        private void LapPhieuTiem_Load(object sender, EventArgs e)
        {
            MHVacXin.listvx.Clear();
            MHGoiTiem.listgt.Clear();
            radioButton1.Checked = true;
            ten.Text = TraCuu.hoten;
            makh.Text = TraCuu.makh;
            LoadData();
        }
        private void LoadData()
        {
            if (radioButton2.Checked == true)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("STT", typeof(int));
                dt.Columns.Add("ID", typeof(String));
                dt.Columns.Add("Name", typeof(String));
                dt.Columns.Add("Price", typeof(int));
                int stt = 1;
                foreach (var item in MHVacXin.listvx)
                {
                    dt.Rows.Add(stt,item._mavx, item._tenvx, item._giatien);
                    stt++;
                }
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("STT", typeof(int));
                dt.Columns.Add("ID", typeof(String));
                dt.Columns.Add("Name", typeof(String));
                dt.Columns.Add("Price", typeof(int));
                int stt = 1;
                foreach (var item in MHGoiTiem.listgt)
                {
                    dt.Rows.Add(stt,item._magoi, item._tengoi, item._giatien);
                    stt++;
                }
                dataGridView1.DataSource = dt;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                MHVacXin f = new MHVacXin();
                f.ShowDialog();
                LoadData();
            }
            else if(radioButton1.Checked == true)
            {
                MHGoiTiem f = new MHGoiTiem();
                f.ShowDialog();
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {

            string makh = TraCuu.makh;
            string mapt = "PT" + PhieuTiem.CountPT().ToString();
            DateTime thoigiantiem = dateTimePicker2.Value;
            PhieuTiem pt = new PhieuTiem(makh, mapt, MHGoiTiem.listgt, MHVacXin.listvx, thoigiantiem);
            try
            {
                bool checkpt = PhieuTiem.ThemPT(pt);
                if(checkpt == true)
                {
                    if(radioButton1.Checked == true)
                    {
                        int index = 0;
                        foreach(var item in pt._goitiem)
                        {
                            PhieuTiem.ThemCT_GT(pt, index);
                            index++;
                        }
                    }
                    else if(radioButton2.Checked == true){
                        int index = 0;
                        foreach (var item in pt._vacxin)
                        {
                            PhieuTiem.ThemCT_VX(pt, index);
                            index++;
                        }
                    }
                    MessageBox.Show("Thêm thành công");

                }
                else
                {
                    MessageBox.Show("ERROR!");
                }
            }
            catch (Exception ex)
            {

            }
            this.Close();
            }
            else
            {
                MessageBox.Show("Không đủ dữ liệu để lập phiếu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && _stt > 0 )
            {
                MHGoiTiem.listgt.RemoveAt(_stt-1);
                _stt = -1;
                LoadData();
            }
            else if(radioButton2.Checked == true && _stt > 0)
            {
                MHVacXin.listvx.RemoveAt(_stt - 1);
                _stt = -1;
                LoadData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView1.CurrentRow.Selected = true;
                    _stt = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["STT"].FormattedValue.ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
