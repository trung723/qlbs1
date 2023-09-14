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
    public partial class frmDoiMatKhau : Form
    {
        private TaiKhoan currentUser;

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        public frmDoiMatKhau(string userName)
        {
            InitializeComponent();
            currentUser = TaiKhoanBLL.Select(userName);
        }

        #region FormEvents
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            lblName.Text = TaiKhoanBLL.fullUserName(currentUser);
            txtTenDangNhap.Text = GlobalSettings.userName;
        }
        #endregion

        #region ButtonEvents
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
               if (txtMatKhauCu.Text == currentUser.MatKhau)
               {
                    if(!string.IsNullOrEmpty(txtMatKhauMoi.Text) && txtMatKhauMoi.Text == txtNhapLaiMatKhau.Text)
                    {
                        currentUser.MatKhau = txtMatKhauMoi.Text;
                        TaiKhoanBLL.Update(currentUser);

                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới trống hoặc không khớp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
               }
               else
               {
                    MessageBox.Show("Mật khẩu không chính xác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }
            }catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
