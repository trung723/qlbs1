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

namespace GUI.Pages
{
    public partial class frmKhachHang : Form
    {
        private bool isInsert = false;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;

            LockControls();
            LoadDGV();
            dgvKhachHang_Click(sender, e);
        }

        #region customDesign
        public void LockControls()
        {
            txtMaKH.Enabled = false;
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
            txtMaKH.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtSoDT.Text = string.Empty;
        }

        public void LoadUI(KhachHang kh)
        {
            txtMaKH.Text = kh.MaKH;
            txtHoTen.Text = kh.HoTen;
            dtpNgaySinh.Value = kh.NgaySinh;
            cboGioiTinh.Text = kh.GioiTinh;
            //cboGioiTinh.Text = kh.GioiTinh;
            txtDiaChi.Text = kh.DiaChi;
            txtSoDT.Text = kh.SoDT;
        }

        public KhachHang LoadKH()
        {
            return new KhachHang()
            {
                MaKH = txtMaKH.Text,
                HoTen = txtHoTen.Text,
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = cboGioiTinh.Text,
                DiaChi = txtDiaChi.Text,
                SoDT = txtSoDT.Text,
            };
        }

        public void LoadDGV()
        {
            dgvKhachHang.DataSource = KhachHangBLL.SelectAll();
        }

        public void ValidateKhachHang()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
                throw new ArgumentException("Họ tên không được để trống!");
        }
        #endregion

        #region DatagridViewEvents
        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUI(KhachHangBLL.Select(dgvKhachHang.SelectedRows[0].Cells["clMaKH"].Value.ToString()));
            }
            catch
            {
                ResetControls();
            }
        }

        private void dgvKhachHang_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void dgvKhachHang_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} khách hàng", dgvKhachHang.Rows.Count);
        }

        private void dgvKhachHang_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} khách hàng", dgvKhachHang.Rows.Count);
        }
        #endregion

        #region ButtonClickEvents

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateKhachHang();
                if (isInsert)
                {
                    KhachHangBLL.Insert(LoadKH());

                    MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KhachHangBLL.Update(LoadKH());

                    MessageBox.Show("Sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadDGV();
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
            dgvKhachHang_Click(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetControls();
            UnLockControls();
            txtMaKH.Text = KhachHangBLL.autoGenerateId();
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
                    KhachHangBLL.Delete(dgvKhachHang.SelectedRows[0].Cells["clMaKH"].Value.ToString());

                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDGV();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
