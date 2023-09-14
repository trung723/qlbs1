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

namespace GUI.Popups
{
    public partial class frmChiTietHoaDon : Form
    {
        private string maHD;
        private bool isInsert = false;
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }

        public frmChiTietHoaDon(string maHoaDon)
        {
            InitializeComponent();
            this.maHD = maHoaDon;
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            //load combobox
            cboTenSach.DataSource = SachBLL.SelectAll();
            cboTenSach.DisplayMember = "TenSach";
            cboTenSach.ValueMember = "MaSach";

            dgvChiTietHoaDon.AutoGenerateColumns = false;

            LockControls();
            LoadDgv();
            dgvChiTietHoaDon_Click(sender, e);

            lblTong.Text = string.Format("Tổng tiền hóa đơn: {0}", ChiTietHoaDonBLL.SelectTongTien(maHD));
        }

        #region CustomDesign
        public void LockControls()
        {
            txtMaHD.Enabled = false;
            cboTenSach.Enabled = false;
            numGiaBan.Enabled = false;
            numSoLuongBan.Enabled = false;
            txtTongTien.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void UnLockControls()
        {
            cboTenSach.Enabled = true;
            numGiaBan.Enabled = true;
            numSoLuongBan.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        public void ResetControls()
        {
            numGiaBan.Value = 0;
            numSoLuongBan.Value = 0;
            txtTongTien.Text = string.Empty;
        }

        public void LoadUI(ChiTietHoaDon hd)
        {
            txtMaHD.Text = hd.HoaDon.MaHD;
            cboTenSach.Text = SachBLL.Select(hd.MaSach).TenSach;
            numGiaBan.Value = Convert.ToDecimal(hd.GiaBan);
            numSoLuongBan.Value = hd.SoLuongBan;
            txtTongTien.Text = hd.TongTien.ToString();
        }

        public ChiTietHoaDon LoadCTHoaDon()
        {
            return new ChiTietHoaDon()
            {
                MaHD = txtMaHD.Text,
                MaSach = cboTenSach.SelectedValue.ToString(),
                GiaBan = double.Parse(numGiaBan.Text),
                SoLuongBan = int.Parse(numSoLuongBan.Text),
                TongTien = double.Parse(txtTongTien.Text),
            };
        }

        public void LoadDgv()
        {
            dgvChiTietHoaDon.DataSource = ChiTietHoaDonBLL.SelectAll(maHD);
            txtMaHD.Text = maHD;
        }

        public void ValidateSach()
        {
            if (numGiaBan.Value <= 0)
                throw new ArgumentException("Giá bán phải lớn hơn 0!");
            if (numSoLuongBan.Value <= 0)
                throw new ArgumentException("Số lượng bán phải lớn hơn 0!");
        }

        public void ValidateSoLuong(string maSach)
        {
            if (numSoLuongBan.Value > SachBLL.Select(maSach).SoLuong)
                throw new ArgumentException("Số lượng bán vượt quá số lượng tồn kho!");
        }
        #endregion

        #region DatagridView
        private void dgvChiTietHoaDon_Click(object sender, EventArgs e)
        {
            LockControls();
            try
            {
                //LoadUI(ChiTietHoaDonBLL.SelectSub(maHD, cboTenSach.SelectedValue.ToString()));
                LoadUI(ChiTietHoaDonBLL.SelectSub(maHD, dgvChiTietHoaDon.SelectedRows[0].Cells["clMaSach"].Value.ToString()));
            }
            catch
            {
                ResetControls();
            }
        }

        private void dgvChiTietHoaDon_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void dgvChiTietHoaDon_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng tiền hóa đơn: {0}", ChiTietHoaDonBLL.SelectTongTien(maHD));
        }

        private void dgvChiTietHoaDon_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng tiền hóa đơn: {0}", ChiTietHoaDonBLL.SelectTongTien(maHD));
        }
        #endregion

        #region NumericEvents
        private void numGiaBan_ValueChanged(object sender, EventArgs e)
        {
            txtTongTien.Text = (numGiaBan.Value * numSoLuongBan.Value).ToString();
        }

        private void numSoLuongBan_ValueChanged(object sender, EventArgs e)
        {
            txtTongTien.Text = (numGiaBan.Value * numSoLuongBan.Value).ToString();
        }
        #endregion

        #region ButtonClick
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSach();
                ValidateSoLuong(cboTenSach.SelectedValue.ToString());
                if (isInsert)
                {
                    if(ChiTietHoaDonBLL.SelectSub(txtMaHD.Text, cboTenSach.SelectedValue.ToString()) == null)
                    {
                        ChiTietHoaDonBLL.Insert(LoadCTHoaDon());

                        //SachBLL.UpdateSoLuongBan(cboTenSach.SelectedValue.ToString(), (int)numSoLuongBan.Value);

                        MessageBox.Show("Thêm chi tiết hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    ChiTietHoaDonBLL.Update(LoadCTHoaDon());

                    MessageBox.Show("Sửa chi tiết hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dgvChiTietHoaDon_Click(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnLockControls();
            ResetControls();
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
                    ChiTietHoaDonBLL.Delete(txtMaHD.Text, dgvChiTietHoaDon.SelectedRows[0].Cells["clMaSach"].Value.ToString());

                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgv();
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
