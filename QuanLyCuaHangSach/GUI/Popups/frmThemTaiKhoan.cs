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
    public partial class frmThemTaiKhoan : Form
    {
        private NhanVien nhanVien;
        public frmThemTaiKhoan()
        {
            InitializeComponent();
        }
        public frmThemTaiKhoan(string maNV)
        {
            InitializeComponent();
            nhanVien = NhanVienBLL.Select(maNV);
        }

        private void frmThemTaiKhoan_Load(object sender, EventArgs e)
        {
            lblName.Text = nhanVien.HoTen;

            //load cboquyen
            cboQuyen.DataSource = QuyenBLL.SelectAll();
            cboQuyen.DisplayMember = "TenQuyen";
            cboQuyen.ValueMember = "MaQuyen";
        }

        public TaiKhoan LoadTK()
        {
            return new TaiKhoan()
            {
                TenTK = txtTenTK.Text,
                MatKhau = txtMatKhau.Text,
                MaNV = nhanVien.MaNV,
                MaQuyen = cboQuyen.SelectedValue.ToString(),
            };
        }

        #region ButtonClick
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txtTenTK.Text) && !string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    TaiKhoanBLL.Insert(LoadTK());

                    MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản và mật khẩu không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
