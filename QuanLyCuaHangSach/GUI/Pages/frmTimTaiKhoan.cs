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
    public partial class frmTimTaiKhoan : Form
    {
        public frmTimTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTimTaiKhoan_Load(object sender, EventArgs e)
        {
            cboLuaChon.Items.AddRange(new string[]
            {
                "Tên tài khoản",
                "Tên nhân viên",
                "Quyền",
            });
            cboLuaChon.SelectedIndex = 0;

            LoadDGV();
            dgvTaiKhoan_Click(sender, e);
        }

        #region CustomDesign
        public void LoadUI(TaiKhoan tk)
        {
            lblTenTK.Text = tk.TenTK;
            lblMatKhau.Text = tk.MatKhau;
            lblTenNhanVien.Text = tk.NhanVien.HoTen;
            lblQuyen.Text = tk.Quyen.TenQuyen;
        }

        public void LoadDGV()
        {
            dgvTaiKhoan.DataSource = TaiKhoanBLL.SelectTKNVQ(null);
            lblTong.Text = string.Format("Tổng cộng: {0} sách", dgvTaiKhoan.Rows.Count);
        }

        public void ValidateSearch()
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
                throw new ArgumentException("Vui lòng nhập thông tin vào ô tìm kiếm!");
        }
        #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();
                dgvTaiKhoan.DataSource = TaiKhoanBLL.SelectAll(txtTimKiem.Text, cboLuaChon.SelectedIndex);

                if (dgvTaiKhoan.Rows.Count > 0)
                {
                    dgvTaiKhoan_Click(sender, e);
                }
            }
            catch (ArgumentException exe)
            {
                MessageBox.Show(exe.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                dgvTaiKhoan.Rows.Clear();
            }
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            LoadDGV();
            btnDatLai_Click(sender, e);
        }

        private void dgvTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUI(TaiKhoanBLL.Select(dgvTaiKhoan.SelectedRows[0].Cells["clTenTK"].Value.ToString()));
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
