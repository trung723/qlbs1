using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using GUI.Pages;
using GUI.Popups;
using BLL;

namespace GUI
{
    public partial class frmMain : Form
    {
        private Form activeForm = null;
        public frmMain()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
        }
        #region FormEvents
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DangNhap();
        }
        #endregion

        #region DangNhap

        public void DangNhap()
        {
            this.Hide();
            try
            {
                GlobalSettings.ConnectToDB();

                frmDangNhap f = new frmDangNhap();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadGiaoDien();
                    this.Show();
                }
            }
            catch
            {
                Reconnect();
            }
        }

        public void LoadGiaoDien()
        {
            resetControlStatus();
            customDesign();

            PhanQuyen(GlobalSettings.userType);
            panelContent.Controls.Clear();
        }

        private void PhanQuyen(string userType)
        {
            switch (userType)
            {
                case "NVBanHang":
                    btnQuanLy.Visible = false;
                    btnThongKe.Visible = false;

                    btnNhapSach.Visible = false;
                    panelKinhDoanhSubMenu.Height = 42;
                    btnTimNhanVien.Visible = false;
                    btnTimTaiKhoan.Visible = false;
                    panelTimKiemSubMenu.Height = 122;
                    break;

                case "NVKho":
                    btnQuanLy.Visible = false;
                    btnThongKe.Visible = false;

                    btnBanSach.Visible = false;
                    panelKinhDoanhSubMenu.Height = 42;
                    btnTimNhanVien.Visible = false;
                    btnTimTaiKhoan.Visible = false;
                    panelTimKiemSubMenu.Height = 122;
                    break;
                default:
                    break;
            }
        }

        public void Reconnect()
        {
            frmKetNoiDatabase f = new frmKetNoiDatabase();
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn cần khởi động lại chương trình để thay đổi có hiệu lực." + Environment.NewLine + "Khởi động ngay?", "Khởi động lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    Application.Restart();
                else
                    Application.Exit();
            }
            else
            {
                MessageBox.Show("Bạn không thể sử dụng chương trình nếu kết nối cơ sở dữ liệu chưa được thiết lập" + Environment.NewLine + "Hãy chạy lại chương trình vào lần tới để thiết lập lại kết nối cơ sở dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        #endregion

        #region CustomDesign
        private void customDesign()
        {
            panelQuanLySubMenu.Visible = false;
            panelKinhDoanhSubMenu.Visible = false;
            panelTimKiemSubMenu.Visible = false;
            panelThongKeSubMenu.Visible = false;
            lblFormName.Text = "";
            btnCloseChildForm.Visible = false;
            //lblTenDangNhap.Text = username;
            //showTrangMoDau();
        }

        /// <summary>
        /// Hien thi trang mo dau khi vua dang nhap vao he thong
        /// </summary>
        private void showTrangMoDau()
        {
            frmTrangMoDau f = new frmTrangMoDau();
            openChildForm(f);
        }

        private void resetControlStatus()
        {
            btnQuanLy.Visible = true;
            btnKinhDoanh.Visible = true;
            btnTimKiem.Visible = true;
            btnThongKe.Visible = true;
            btnDoiMatKhau.Visible = true;

            btnTheLoai.Visible = true;
            btnSach.Visible = true;
            btnNhanVien.Visible = true;
            btnKhachHang.Visible = true;
            btnTaiKhoan.Visible = true;

            btnNhapSach.Visible = true;
            btnBanSach.Visible = true;

            btnTimSach.Visible = true;
            btnTimTheLoai.Visible = true;
            btnTimNhanVien.Visible = true;
            btnTimKhachHang.Visible = true;
            btnTimTaiKhoan.Visible = true;

            btnThongKeDoanhThu.Visible = true;
            btnThongKeSoLuongNhap.Visible = true;

            panelKinhDoanhSubMenu.Height = 85;
            panelTimKiemSubMenu.Height = 205;
        }

        private void hideSubMenu()
        {
            if (panelQuanLySubMenu.Visible = true)
                panelQuanLySubMenu.Visible = false;
            if (panelKinhDoanhSubMenu.Visible = true)
                panelKinhDoanhSubMenu.Visible = false;
            if (panelTimKiemSubMenu.Visible = true)
                panelTimKiemSubMenu.Visible = false;
            if (panelThongKeSubMenu.Visible = true)
                panelThongKeSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            panelContent.BringToFront();
            childForm.Show();
            //thay doi text hien thi cua lable tren title
            lblFormName.Text = childForm.Text;
            //hien thi button tat form con 
            btnCloseChildForm.Visible = true;
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                btnCloseChildForm.Visible = false;
                lblFormName.Text = " ";
            }
        }
        #endregion

        #region ButtonMainClick
        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQuanLySubMenu);
        }

        private void btnKinhDoanh_Click(object sender, EventArgs e)
        {
            showSubMenu(panelKinhDoanhSubMenu);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTimKiemSubMenu);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            showSubMenu(panelThongKeSubMenu);
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            frmDoiMatKhau f = new frmDoiMatKhau(GlobalSettings.userName);
            f.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                DangNhap();
            }
        }
        #endregion

        #region ButtonChucNangQuanLyClick
        private void btnSach_Click(object sender, EventArgs e)
        {
            openChildForm(new frmSach());
            hideSubMenu();
        }

        private void btnTheLoai_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTheLoai());
            hideSubMenu();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhanVien());
            hideSubMenu();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmKhachHang());
            hideSubMenu();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTaiKhoan());
            hideSubMenu();
        }
        #endregion

        #region ButtonChucnangKinhDoanhClick
        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhapSach());
            hideSubMenu();
        }

        private void btnBanSach_Click(object sender, EventArgs e)
        {
            openChildForm(new frmBanSach());
            hideSubMenu();
        }

        #endregion

        #region ButtonChucNangTimKiemClick

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTimSach());
            hideSubMenu();
        }

        private void btnTimTheLoai_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTimTheLoai());
            hideSubMenu();
        }

        private void btnTimNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTimNhanVien());
            hideSubMenu();
        }

        private void btnTimKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTimKhachHang());
            hideSubMenu();
        }

        private void btnTimTaiKhoan_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTimTaiKhoan());
            hideSubMenu();
        }
        #endregion

        #region ButtonChucNangThongKeClick
        private void btnThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThongKeHoaDon());
            hideSubMenu();
        }

        private void btnThongKeSoLuongNhap_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThongKeSoLuongNhap());
            hideSubMenu();
        }
        #endregion

    }
}
