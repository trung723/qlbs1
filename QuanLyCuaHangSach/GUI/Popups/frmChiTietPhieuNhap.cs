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

namespace GUI.Popups
{
    public partial class frmChiTietPhieuNhap : Form
    {
        private string maPN;
        private bool isInsert = false;
        public frmChiTietPhieuNhap()
        {
            InitializeComponent();
        }

        public frmChiTietPhieuNhap(string maPhieuNhap)
        {
            InitializeComponent();
            this.maPN = maPhieuNhap;
        }

        private void frmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            //load combobox
            cboTenSach.DataSource = SachBLL.SelectAll();
            cboTenSach.DisplayMember = "TenSach";
            cboTenSach.ValueMember = "MaSach";

            dgvChiTietPhieuNhap.AutoGenerateColumns = false;

            LockControls();
            LoadDgv();
            dgvChiTietPhieuNhap_Click(sender, e);

            lblTong.Text = string.Format("Tổng tiền phiếu nhập: {0}", ChiTietPhieuNhapBLL.SelectTongTien(maPN));
        }

        #region customDesign

        //public void TongTien()
        //{
        //    try
        //    {
        //        double gia = double.Parse(numGiaNhap.Text);
        //        double soluong = double.Parse(numSoLuongNhap.Text);
        //        double sum = gia * soluong;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Giá và tổng tiền phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        public void LockControls()
        {
            txtMaPN.Enabled = false;
            cboTenSach.Enabled = false;
            numGiaNhap.Enabled = false;
            numSoLuongNhap.Enabled = false;
            txtTongTien.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void UnLockControls()
        {
            cboTenSach.Enabled = true;
            numGiaNhap.Enabled = true;
            numSoLuongNhap.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        public void ResetControls()
        {
            numGiaNhap.Value = 0;
            numSoLuongNhap.Value = 0;
            txtTongTien.Text = string.Empty;
        }

        public void LoadUI(ChiTietPhieuNhap pn)
        {
            txtMaPN.Text = pn.PhieuNhap.MaPN;
            cboTenSach.Text = SachBLL.Select(pn.MaSach).TenSach;
            numGiaNhap.Value = Convert.ToDecimal(pn.GiaNhap);
            numSoLuongNhap.Value = pn.SoLuongNhap;
            txtTongTien.Text = pn.TongTien.ToString();
        }

        public ChiTietPhieuNhap LoadCTPhieuNhap()
        {
            return new ChiTietPhieuNhap()
            {
                MaPN = txtMaPN.Text,
                MaSach = cboTenSach.SelectedValue.ToString(),
                GiaNhap = double.Parse(numGiaNhap.Text),
                SoLuongNhap = int.Parse(numSoLuongNhap.Text),
                TongTien = double.Parse(txtTongTien.Text),
            };
        }

        public void LoadDgv()
        {
            dgvChiTietPhieuNhap.DataSource = ChiTietPhieuNhapBLL.SelectAll(maPN);
            txtMaPN.Text = maPN;
        }

        public void ValidateSach()
        {
            if (numGiaNhap.Value <= 0)
                throw new ArgumentException("Giá nhập phải lớn hơn 0!");
            if (numSoLuongNhap.Value <= 0)
                throw new ArgumentException("Số lượng nhập phải lớn hơn 0!");
        }
        #endregion

        #region NumerValueChanged
        private void numSoLuongNhap_ValueChanged(object sender, EventArgs e)
        {
            txtTongTien.Text = (numGiaNhap.Value * numSoLuongNhap.Value).ToString();
        }

        private void numGiaNhap_ValueChanged(object sender, EventArgs e)
        {
            txtTongTien.Text = (numGiaNhap.Value * numSoLuongNhap.Value).ToString();
        }
        #endregion

        #region DatagridView
        private void dgvChiTietPhieuNhap_Click(object sender, EventArgs e)
        {
            LockControls();
            try
            {
                //LoadUI(ChiTietPhieuNhapBLL.SelectSub(maPN, cboTenSach.SelectedValue.ToString()));
                LoadUI(ChiTietPhieuNhapBLL.SelectSub(maPN, dgvChiTietPhieuNhap.SelectedRows[0].Cells["clMaSach"].Value.ToString()));
            }
            catch
            {
                ResetControls();
            }
        }

        private void dgvChiTietPhieuNhap_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void dgvChiTietPhieuNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng tiền phiếu nhập: {0}", ChiTietPhieuNhapBLL.SelectTongTien(maPN));
        }

        private void dgvChiTietPhieuNhap_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng tiền phiếu nhập: {0}", ChiTietPhieuNhapBLL.SelectTongTien(maPN));
        }
        #endregion

        #region ButtonClick
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSach();
                if (isInsert)
                {
                    if(ChiTietPhieuNhapBLL.SelectSub(txtMaPN.Text,cboTenSach.SelectedValue.ToString()) == null)
                    {
                        ChiTietPhieuNhapBLL.Insert(LoadCTPhieuNhap());

                        //SachBLL.UpdateSoLuongNhap(cboTenSach.SelectedValue.ToString(), (int)numSoLuongNhap.Value);

                        MessageBox.Show("Thêm chi tiết phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    ChiTietPhieuNhapBLL.Update(LoadCTPhieuNhap());

                    MessageBox.Show("Sửa chi tiết phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dgvChiTietPhieuNhap_Click(sender, e);
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
                    ChiTietPhieuNhapBLL.Delete(txtMaPN.Text, dgvChiTietPhieuNhap.SelectedRows[0].Cells["clMaSach"].Value.ToString());

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
