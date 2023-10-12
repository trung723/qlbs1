using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace GUI.Pages
{
    public partial class frmThongKeSoLuongNhap : Form
    {
        public frmThongKeSoLuongNhap()
        {
            InitializeComponent();
        }

        private void frmThongKeSoLuongNhap_Load(object sender, EventArgs e)
        {
            dgvPhieuNhap.AutoGenerateColumns = false;

            LoadDGV();

            lblTong.Text = string.Format("Tổng: {0} phiếu nhập", dgvPhieuNhap.Rows.Count);
        }

        public void LoadDGV()
        {
            dgvPhieuNhap.DataSource = PhieuNhapBLL.SelectNV(null);
        }

        public void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);

            for (int i = 0; i < dgvPhieuNhap.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dgvPhieuNhap.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
            {
                for (int j = 0; j < dgvPhieuNhap.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dgvPhieuNhap.Rows[i].Cells[j].Value;
                }
            }

            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Quit();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvPhieuNhap.DataSource = PhieuNhapBLL.BaoCaoNhapSach(dtpThang.Value.Month, dtpThang.Value.Year);
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

        private void dgvPhieuNhap_DoubleClick(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void dgvPhieuNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} phiếu nhập", dgvPhieuNhap.Rows.Count);
        }

        private void dgvPhieuNhap_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} phiếu nhập", dgvPhieuNhap.Rows.Count);
        }

        private void btnTKBCS_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form ResetPasswordForm
            frmTKBCSach resetPasswordForm = new frmTKBCSach();

            // Ẩn form hiện tại
            this.Hide();

            // Hiển thị form ResetPasswordForm
            resetPasswordForm.ShowDialog();

            // Sau khi form ResetPasswordForm đóng, hiện lại form hiện tại
            this.Show();
        }
    }
}
