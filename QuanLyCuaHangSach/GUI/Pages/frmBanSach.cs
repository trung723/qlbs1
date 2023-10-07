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
using GUI.Reports;
using Microsoft.Reporting.WinForms;

namespace GUI.Pages
{
    public partial class frmBanSach : Form
    {
        private bool isInsert = false;

        public frmBanSach()
        {
            InitializeComponent();
        }

        private void frmBanSach_Load(object sender, EventArgs e)
        {
            //load combobox
            cboKhachHang.DataSource = KhachHangBLL.SelectAll();
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKH";

            dgvHoaDon.AutoGenerateColumns = false;

            LockControls();
            LoadDgv();
            dgvHoaDon_Click(sender, e);
        }
        private void btnChiTietHoaDon_Click(object sender, EventArgs e)
        {
            frmChiTietHoaDon f = new frmChiTietHoaDon(txtMaHD.Text);
            f.ShowDialog();
            btnXemTatCa_Click(sender, e);
        }

        #region CustomDesign
        public void LockControls()
        {
            txtMaHD.Enabled = false;
            dtpThoiDiemLapHD.Enabled = false;
            cboKhachHang.Enabled = false;
            txtNhanVien.Enabled = false;
            //txtTongTien.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void UnLockControls()
        {
            dtpThoiDiemLapHD.Enabled = true;
            cboKhachHang.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        public void ResetControls()
        {
            txtMaHD.Text = string.Empty;
            dtpThoiDiemLapHD.Value = System.DateTime.Now;
            //cboKhachHang.Text = string.Empty;
            //txtTongTien.Text = string.Empty;
        }

        public void LoadUI(HoaDon hd)
        {
            txtMaHD.Text = hd.MaHD;
            dtpThoiDiemLapHD.Value = hd.ThoiDiemLapHD;
            cboKhachHang.Text = hd.KhachHang.HoTen;
            txtNhanVien.Text = hd.NhanVien.HoTen;
        }

        public HoaDon LoadHoaDon()
        {
            return new HoaDon()
            {
                MaHD = txtMaHD.Text,
                ThoiDiemLapHD = dtpThoiDiemLapHD.Value.Date,
                MaKH = cboKhachHang.SelectedValue.ToString(),
                MaNV = (TaiKhoanBLL.Select(GlobalSettings.userName)).MaNV,
            };
        }

        public void LoadDgv()
        {
            dgvHoaDon.DataSource = HoaDonBLL.SelectNVKH(null);
        }

        public void ValidateSearch()
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
                throw new ArgumentException("Vui lòng nhập thông tin vào ô tìm kiếm!");
        }

        #endregion

        #region DataGridView
        private void dgvHoaDon_Click(object sender, EventArgs e)
        {
            LockControls();
            try
            {
                LoadUI(HoaDonBLL.Select(dgvHoaDon.SelectedRows[0].Cells["clMaHD"].Value.ToString()));
            }
            catch
            {
                ResetControls();
            }
        }

        private void dgvHoaDon_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void dgvHoaDon_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} hoá đơn", dgvHoaDon.Rows.Count);
        }

        private void dgvHoaDon_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} hoá đơn", dgvHoaDon.Rows.Count);
        }
        #endregion

        #region ButtonChucNangChinhClick
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    HoaDonBLL.Insert(LoadHoaDon());

                    MessageBox.Show("Thêm hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HoaDonBLL.Update(LoadHoaDon());

                    MessageBox.Show("Sửa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dgvHoaDon_Click(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnLockControls();
            ResetControls();
            isInsert = true;
            txtMaHD.Text = HoaDonBLL.autoGenerateId();
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
                    HoaDonBLL.Delete(dgvHoaDon.SelectedRows[0].Cells["clMaHD"].Value.ToString());

                    MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                dgvHoaDon.DataSource = HoaDonBLL.SelectAll(txtTimKiem.Text);

                dgvHoaDon_Click(sender, e);
                UnLockControls();
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

        //private void btnDatLai_Click(object sender, EventArgs e)
        //{
        //    txtTimKiem.Text = string.Empty;
        //}


        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
            LoadDgv();
        }
        #endregion

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            frmReport f = new frmReport();

            List<ReportParameter> _params = new List<ReportParameter>()
            {
                new ReportParameter("MaHD", dgvHoaDon.SelectedRows[0].Cells["clMaHD"].Value.ToString()),
                new ReportParameter("HoTenNV", dgvHoaDon.SelectedRows[0].Cells["clNhanVien"].Value.ToString()),
                new ReportParameter("HoTenKH", dgvHoaDon.SelectedRows[0].Cells["clKhachHang"].Value.ToString()),
                new ReportParameter("TongTien", dgvHoaDon.SelectedRows[0].Cells["clTongTien"].Value.ToString()),
            };

            f.ReportViewer.LocalReport.ReportEmbeddedResource = "GUI.Reports.rptHoaDon.rdlc";
            dsSource.dtHoaDonDataTable dt = new dsSource.dtHoaDonDataTable();

            var query = ChiTietHoaDonBLL.SelectReport(dgvHoaDon.SelectedRows[0].Cells["clMaHD"].Value.ToString());
            foreach(var i in query)
            {
                dt.Rows.Add(i.MaHD, i.MaSach, i.TenSach, i.SoLuong, i.GiaBan, i.TongTien);
            }

            f.ReportViewer.LocalReport.DataSources.Clear();
            f.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ds", (DataTable)dt));

            f.ReportViewer.LocalReport.SetParameters(_params);
            f.ReportViewer.LocalReport.DisplayName = "Hoá đơn";
            f.Text = "Hóa đơn";

            f.ShowDialog();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = string.Empty;
            txtNhanVien.Text = string.Empty;
            txtTimKiem.Text = string.Empty;
        }
    }
}
