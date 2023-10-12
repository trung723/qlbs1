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
    public partial class frmTKBCSach : Form
    {
        public frmTKBCSach()
        {
            InitializeComponent();
        }
        

        public void LoadDGV()
        {
            dgvSach.DataSource = HoaDonBLL.SelectNVKH(null);
        }

        public void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);

            for (int i = 0; i < dgvSach.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dgvSach.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvSach.Rows.Count; i++)
            {
                for (int j = 0; j < dgvSach.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dgvSach.Rows[i].Cells[j].Value;
                }
            }

            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Quit();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvSach.DataSource = HoaDonBLL.BaoCaoDoanhThu(dtpThang.Value.Month, dtpThang.Value.Year);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exe)
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
            lblTong.Text = string.Format("Tổng: {0} hoá đơn", dgvSach.Rows.Count);
        }

        private void dgvHoaDon_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} hoá đơn", dgvSach.Rows.Count);
        }

        private void frmTKBCSach_Load(object sender, EventArgs e)
        {
            dgvSach.AutoGenerateColumns = false;

            LoadDGV();

            lblTong.Text = string.Format("Tổng: {0} hoá đơn", dgvSach.Rows.Count);
        }
    }
}
