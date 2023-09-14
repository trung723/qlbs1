using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace GUI.Pages
{
    public partial class frmThongKeHoaDon : Form
    {
        public frmThongKeHoaDon()
        {
            InitializeComponent();
        }

        private void frmThongKeHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            LoadDGV();

            lblTong.Text = string.Format("Tổng: {0} hoá đơn", dgvHoaDon.Rows.Count);
        }

        public void LoadDGV()
        {
            dgvHoaDon.DataSource = HoaDonBLL.SelectNVKH(null);
        }

        public void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);

            for (int i = 0; i < dgvHoaDon.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dgvHoaDon.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
            {
                for(int j = 0; j < dgvHoaDon.Columns.Count; j ++)
                {
                    application.Cells[i + 2, j + 1] = dgvHoaDon.Rows[i].Cells[j].Value;
                }
            }

            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Quit();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = HoaDonBLL.BaoCaoDoanhThu(dtpThang.Value.Month, dtpThang.Value.Year);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception exe)
                {
                    MessageBox.Show("Xuất excel thất bại!\n" + exe.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvHoaDon_DoubleClick(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void dgvHoaDon_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} hoá đơn", dgvHoaDon.Rows.Count);
        }

        private void dgvHoaDon_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} hoá đơn", dgvHoaDon.Rows.Count);
        }
    }
}
