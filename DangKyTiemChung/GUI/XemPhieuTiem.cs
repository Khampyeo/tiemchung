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
    public partial class XemPhieuTiem : Form
    {
        public XemPhieuTiem()
        {
            InitializeComponent();
        }

        private void XemPhieuTiem_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            PhieuTiem.LayTT_PT(TraCuu.makh).Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
