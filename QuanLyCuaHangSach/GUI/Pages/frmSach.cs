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
    public partial class frmSach : Form
    {
        private bool isInsert = false;
        public frmSach()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            //load the loai
            cboTheLoai.DataSource = TheLoaiBLL.SelectALL();
            cboTheLoai.DisplayMember = "TenLoai";
            cboTheLoai.ValueMember = "MaLoai";

            //load datagridView
            dgvSach.AutoGenerateColumns = false;

            LockControls();
            LoadDgv();
            dgvSach_Click(sender, e);
        }

        #region CustomDesign
        public void LockControls()
        {
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            //txtDonGia.Enabled = false;
            txtTacGia.Enabled = false;
            txtSoLuong.Enabled = false;
            cboTheLoai.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void UnLockControls()
        {
            //txtMaSach.Enabled = true;
            txtTenSach.Enabled = true;
            //txtDonGia.Enabled = true;
            txtTacGia.Enabled = true;
            txtSoLuong.Enabled = true;
            cboTheLoai.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        public void ResetControls()
        {
            txtMaSach.Text = string.Empty;
            txtTenSach.Text = string.Empty;
            txtTacGia.Text = string.Empty;
            //txtDonGia.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
        }

        public void LoadUI(Sach sa)
        {
            txtMaSach.Text = sa.MaSach;
            cboTheLoai.Text = TheLoaiBLL.SelectTenLoai(sa.MaLoai);
            txtTenSach.Text = sa.TenSach;
            txtTacGia.Text = sa.Tacgia;
            //txtDonGia.Text = sa.DonGia.ToString();
            txtSoLuong.Text = sa.SoLuong.ToString();
        }

        public Sach LoadSach()
        {
            return new Sach()
            {
                MaSach = txtMaSach.Text,
                //MaLoai = cboTheLoai.Text,
                MaLoai = cboTheLoai.SelectedValue.ToString(),
                TenSach = txtTenSach.Text,
                Tacgia = txtTacGia.Text,
                //DonGia = float.Parse(txtDonGia.Text),
                SoLuong = int.Parse(txtSoLuong.Text)
            };
        }

        public void LoadDgv()
        {
            dgvSach.DataSource = SachBLL.selectAndLoaiSach();
        }

        public void ValidateSach()
        {
            if (string.IsNullOrEmpty(txtTenSach.Text))
                throw new ArgumentException("Tên sách không được để trống!");
            if (string.IsNullOrEmpty(txtTacGia.Text))
                throw new ArgumentException("Tác giả không được để trống!");
            //if (string.IsNullOrEmpty(txtDonGia.Text))
            //    throw new ArgumentException("Đơn giá không được để trống!");
            if (string.IsNullOrEmpty(txtSoLuong.Text))
                throw new ArgumentException("Số lượng không được để trống!");
        }
        #endregion

        #region DatagridViewEvents
        private void dgvSach_Click(object sender, EventArgs e)
        {
            LockControls();
            try
            {
                LoadUI(SachBLL.Select(dgvSach.SelectedRows[0].Cells["clMaSach"].Value.ToString()));
            }catch
            {
                ResetControls();
            }
        }

        private void dgvSach_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void dgvSach_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} sách", dgvSach.Rows.Count);
        }

        private void dgvSach_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} sách", dgvSach.Rows.Count);
        }
        #endregion

        #region ButtonEvents
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSach();
                if (isInsert)
                {
                    SachBLL.Insert(LoadSach());

                    MessageBox.Show("Thêm sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SachBLL.Update(LoadSach());

                    MessageBox.Show("Sửa sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dgvSach_Click(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnLockControls();
            ResetControls();
            txtMaSach.Text = SachBLL.autoGenerateId();
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
                    SachBLL.Delete(dgvSach.SelectedRows[0].Cells["clMaSach"].Value.ToString());

                    MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDgv();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void cboTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTacGia_Click(object sender, EventArgs e)
        {
           
            frmTacGia frmTacGia = new frmTacGia();

           
            this.Hide();

         
            frmTacGia.ShowDialog();

            
            this.Show();
        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
            
            frmNXB frmNXB = new frmNXB();

            
            this.Hide();

            
            frmNXB.ShowDialog();

        
            this.Show();
        }
    }
}
