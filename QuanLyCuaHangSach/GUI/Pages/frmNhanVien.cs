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
using GUI.Popups;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace GUI.Pages
{
    public partial class frmNhanVien : Form
    {
        private bool isInsert = false;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            //load combobox
            //cboGioiTinh.DataSource = NhanVienBLL.SelectAll();
            //cboGioiTinh.DisplayMember = "GioiTinh";

            //load DGV
            dgvNhanVien.AutoGenerateColumns = false;
            lockControls();
            LoadDgv();
            dgvNhanVien_Click(sender, e);
        }

        public void ThemTaiKhoanNV()
        {
            frmThemTaiKhoan f = new frmThemTaiKhoan(txtMaNV.Text);
            f.ShowDialog();
        }

        #region customDesign
        public void lockControls()
        {
            txtMaNV.Enabled = false;
            txtHoTen.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cboGioiTinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSoDT.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }
        public void UnLockControls()
        {
            txtHoTen.Enabled = true;
            dtpNgaySinh.Enabled = true;
            cboGioiTinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSoDT.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        public void ResetControls()
        {
            txtMaNV.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            dtpNgaySinh.Value = DateTime.Now;
            //cboGioiTinh
            txtDiaChi.Text = string.Empty;
            txtSoDT.Text = string.Empty;
        }

        public void LoadUI(NhanVien nv)
        {
            txtMaNV.Text = nv.MaNV;
            txtHoTen.Text = nv.HoTen;
            dtpNgaySinh.Value = (DateTime)nv.NgaySinh;
            cboGioiTinh.Text = nv.GioiTinh;
            txtDiaChi.Text = nv.DiaChi;
            txtSoDT.Text = nv.SoDT;
        }

        public NhanVien LoadNV()
        {
            return new NhanVien()
            {
                MaNV = txtMaNV.Text,
                HoTen = txtHoTen.Text,
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = cboGioiTinh.Text,
                DiaChi = txtDiaChi.Text,
                SoDT = txtSoDT.Text,
            };

        }

        public void ValidateNhanVien()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
                throw new ArgumentException("Họ tên không được để trống!");
        }

        public void LoadDgv()
        {
            dgvNhanVien.DataSource = NhanVienBLL.SelectAll();
        }

        public void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();

            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dgvNhanVien.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dgvNhanVien.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            {
                for (int j = 0; j < dgvNhanVien.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = "'" + dgvNhanVien.Rows[i].Cells[j].Value;
                }
            }

            //application.Columns.ColumnWidth = 25;
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveAs(path);
            application.ActiveWorkbook.Saved = true;
            application.Quit();
        }
        #endregion

        #region ButtonClick
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateNhanVien();
                if (isInsert)
                {
                    NhanVienBLL.Insert(LoadNV());

                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ThemTaiKhoanNV();
                }
                else
                {
                    NhanVienBLL.Update(LoadNV());

                    MessageBox.Show("Sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadDgv();
                lockControls();
            }
            catch (ArgumentException exe)
            {
                MessageBox.Show(exe.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvNhanVien_Click(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetControls();
            UnLockControls();
            txtMaNV.Text = NhanVienBLL.autoGenerateId();
            isInsert = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UnLockControls();
            isInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhanVienBLL.Delete(dgvNhanVien.SelectedRows[0].Cells["clMaNV"].Value.ToString());

                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgv();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        #endregion

        #region DatagridViewEvents
        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            lockControls();
            try
            {
                LoadUI(NhanVienBLL.Select(dgvNhanVien.SelectedRows[0].Cells["clMaNV"].Value.ToString()));
            }
            catch
            {
                ResetControls();
            }
        }

        private void dgvNhanVien_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void dgvNhanVien_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} nhân viên", dgvNhanVien.Rows.Count);
        }

        private void dgvNhanVien_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} nhân viên", dgvNhanVien.Rows.Count);
        }


        #endregion

    }
}
