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
using GUI.Properties;

namespace GUI.Popups
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(TaiKhoanBLL.IsValid(txtTenDangNhap.Text, txtMatKhau.Text))
            {
                TaiKhoan t = TaiKhoanBLL.Select(txtTenDangNhap.Text);
                GlobalSettings.userID = TaiKhoanBLL.fullUserID(t);
                GlobalSettings.userName = txtTenDangNhap.Text;
                GlobalSettings.userType = TaiKhoanBLL.fullUserType(t);

                Settings.Default.Log_UserName = txtTenDangNhap.Text;
                Settings.Default.Log_Password = txtMatKhau.Text;
                Settings.Default.Save();

                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không chính xác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHienMK.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 30; // Adjust the radius to control the corner roundness

            // Define the rounded rectangle
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            // Set the form's region to the rounded shape
            this.Region = new Region(path);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Tạo một instance của form ResetPasswordForm
           RePass resetPasswordForm = new RePass();

            // Ẩn form hiện tại
            this.Hide();

            // Hiển thị form ResetPasswordForm
            resetPasswordForm.ShowDialog();

            // Sau khi form ResetPasswordForm đóng, hiện lại form hiện tại
            this.Show();
        }
    }
}
