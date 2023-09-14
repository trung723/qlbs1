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

namespace GUI.Pages
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            //load cbo
            cboQuyen.DataSource = QuyenBLL.SelectAll();
            cboQuyen.DisplayMember = "TenQuyen";
            cboQuyen.ValueMember = "MaQuyen";

            dgvTaiKhoan.AutoGenerateColumns = false;

            LockControls();
            LoadDGV();
            dgvTaiKhoan_Click(sender, e);
            btnDatLai_Click(sender, e);

            lblTong.Text = string.Format("Tổng: {0} tài khoản", dgvTaiKhoan.Rows.Count);
        }

        #region customDesign
        public void LockControls()
        {
            txtTenTK.Enabled = false;
            txtMatKhau.Enabled = false;
            cboQuyen.Enabled = false;
            //cboNhanVien.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void UnLockControls()
        {
            cboQuyen.Enabled = true;
            txtMatKhau.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        public void ResetControls()
        {
            txtTenTK.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            txtTimKiem.Text = string.Empty;
        }

        public void LoadUI(TaiKhoan tk)
        {
            txtTenTK.Text = tk.TenTK;
            txtMatKhau.Text = tk.MatKhau;
            cboQuyen.Text = TaiKhoanBLL.fullUserType(tk);
        }

        public TaiKhoan LoadTK()
        {
            return new TaiKhoan()
            {
                TenTK = txtTenTK.Text,
                MatKhau = txtMatKhau.Text,
                MaNV = dgvTaiKhoan.SelectedRows[0].Cells["clMaNV"].Value.ToString(),
                MaQuyen = cboQuyen.SelectedValue.ToString(),
            };
        }

        public void LoadDGV()
        {
            dgvTaiKhoan.DataSource = TaiKhoanBLL.SelectTKNVQ(null);
        }

        public void ValidateTaiKhoan()
        {
            if (string.IsNullOrEmpty(txtTenTK.Text))
                throw new ArgumentException("Tên đăng nhập không được để trống!");
            if (string.IsNullOrEmpty(txtMatKhau.Text))
                throw new ArgumentException("Mật khẩu không được để trống!");
        }

        public void ValidateSearch()
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
                throw new ArgumentException("Vui lòng nhập thông tin vào ô tìm kiếm!");
        }
        #endregion

        #region DatagridView
        private void dgvTaiKhoan_Click(object sender, EventArgs e)
        {
            LockControls();
            try
            {
                LoadUI(TaiKhoanBLL.Select(dgvTaiKhoan.SelectedRows[0].Cells["clTenTK"].Value.ToString()));
            }
            catch
            {
                ResetControls();
            }
        }

        private void dgvTaiKhoan_DoubleClick(object sender, EventArgs e)
        {
            UnLockControls();
        }
        #endregion

        #region ButtonClickEvents
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateTaiKhoan();
                TaiKhoanBLL.UpdateFull(LoadTK());

                MessageBox.Show("Sửa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            dgvTaiKhoan_Click(sender, e);
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            LoadDGV();
            btnDatLai_Click(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();

                dgvTaiKhoan.DataSource = TaiKhoanBLL.SelectTKNVQ(txtTimKiem.Text);

                dgvTaiKhoan_Click(sender, e);
                UnLockControls();
            }
            catch(ArgumentException exe)
            {
                MessageBox.Show(exe.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
        }
        #endregion
    }
}
