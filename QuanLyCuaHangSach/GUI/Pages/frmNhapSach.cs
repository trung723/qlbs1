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
using GUI.Popups;
using GUI.Reports;
using Microsoft.Reporting.WinForms;

namespace GUI.Pages
{
    public partial class frmNhapSach : Form
    {
        private bool isInsert = false;

        public frmNhapSach()
        {
            InitializeComponent();
        }

        private void frmNhapSach_Load(object sender, EventArgs e)
        {
            LockControls();
            LoadDgv();
            dgvPhieuNhap_Click(sender, e);
        }

        private void btnChiTietPhieuNhap_Click(object sender, EventArgs e)
        {
            frmChiTietPhieuNhap f = new frmChiTietPhieuNhap(txtMaPN.Text);
            f.ShowDialog();
            btnXemTatCa_Click(sender, e);
        }

        #region CustomDesign
        public void LockControls()
        {
            txtMaPN.Enabled = false;
            dtpThoiDiemNhap.Enabled = false;
            txtGhiChu.Enabled = false;
            txtNhanVien.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void UnLockControls()
        {
            dtpThoiDiemNhap.Enabled = true;
            txtGhiChu.Enabled = true;
            //txtNhanVien.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        public void ResetControls()
        {
            txtMaPN.Text = string.Empty;
            dtpThoiDiemNhap.Value = System.DateTime.Now;
            txtGhiChu.Text = string.Empty;
            txtNhanVien.Text = string.Empty;
        }

        public void LoadUI(PhieuNhap pn)
        {
            txtMaPN.Text = pn.MaPN;
            dtpThoiDiemNhap.Value = pn.ThoiDiemNhap;
            txtGhiChu.Text = pn.GhiChu;
            txtNhanVien.Text = pn.NhanVien.HoTen;
        }

        public PhieuNhap LoadPhieuNhap()
        {
            return new PhieuNhap()
            {
                MaPN = txtMaPN.Text,
                ThoiDiemNhap = dtpThoiDiemNhap.Value.Date,
                GhiChu = txtGhiChu.Text,
                MaNV = (TaiKhoanBLL.Select(GlobalSettings.userName)).MaNV,
            };
        }

        public void LoadDgv()
        {
            dgvPhieuNhap.DataSource = PhieuNhapBLL.SelectNV(null);
        }

        public void ValidateSearch()
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
                throw new ArgumentException("Vui lòng nhập thông tin vào ô tìm kiếm!");
        }

        #endregion

        #region DatagridView
        private void dgvPhieuNhap_Click(object sender, EventArgs e)
        {
            LockControls();
            try
            {
                LoadUI(PhieuNhapBLL.Select(dgvPhieuNhap.SelectedRows[0].Cells["clMaPN"].Value.ToString()));
            }
            catch
            {
                ResetControls();
            }
        }

        private void dgvPhieuNhap_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void dgvPhieuNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} phiếu nhập", dgvPhieuNhap.Rows.Count);
        }

        private void dgvPhieuNhap_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} phiếu nhập", dgvPhieuNhap.Rows.Count);
        }
        #endregion

        #region ButtonChucNangChinhClick
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    PhieuNhapBLL.Insert(LoadPhieuNhap());

                    MessageBox.Show("Thêm phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    PhieuNhapBLL.Update(LoadPhieuNhap());

                    MessageBox.Show("Sửa phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadDgv();
                LockControls();
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
            dgvPhieuNhap_Click(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnLockControls();
            ResetControls();
            isInsert = true;
            txtMaPN.Text = PhieuNhapBLL.autoGenerateId();
            txtNhanVien.Text = (TaiKhoanBLL.fullUserName(GlobalSettings.userName)).NhanVien.HoTen;
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
                    PhieuNhapBLL.Delete(dgvPhieuNhap.SelectedRows[0].Cells["clMaPN"].Value.ToString());

                    MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgv();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ButtonChucNangTimKiemClick
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();

                dgvPhieuNhap.DataSource = PhieuNhapBLL.SelectAll(txtTimKiem.Text);

                dgvPhieuNhap_Click(sender, e);
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

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
            LoadDgv();
        }
        #endregion

        private void btnInPhieuNhap_Click(object sender, EventArgs e)
        {
            frmReport f = new frmReport();

            List<ReportParameter> _params = new List<ReportParameter>()
            {
                new ReportParameter("MaPN", dgvPhieuNhap.SelectedRows[0].Cells["clMaPN"].Value.ToString()),
                new ReportParameter("HoTenNV", dgvPhieuNhap.SelectedRows[0].Cells["clNhanVien"].Value.ToString()),
                new ReportParameter("TongTien", dgvPhieuNhap.SelectedRows[0].Cells["clTongTien"].Value.ToString()),
            };

            f.ReportViewer.LocalReport.ReportEmbeddedResource = "GUI.Reports.rptPhieuNhap.rdlc";
            dsSource.dtPhieuNhapDataTable dt = new dsSource.dtPhieuNhapDataTable();

            var query = ChiTietPhieuNhapBLL.SelectReport(dgvPhieuNhap.SelectedRows[0].Cells["clMaPN"].Value.ToString());
            foreach (var i in query)
            {
                dt.Rows.Add(i.MaPN, i.MaSach, i.TenSach, i.SoLuongNhap, i.GiaNhap, i.TongTien);
            }

            f.ReportViewer.LocalReport.DataSources.Clear();
            f.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ds", (DataTable)dt));

            f.ReportViewer.LocalReport.SetParameters(_params);
            f.ReportViewer.LocalReport.DisplayName = "Phiếu nhập";
            f.Text = "Phiếu nhập";

            f.ShowDialog();
        }
    }
}
