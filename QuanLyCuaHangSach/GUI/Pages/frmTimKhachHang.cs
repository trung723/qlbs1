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
    public partial class frmTimKhachHang : Form
    {
        public frmTimKhachHang()
        {
            InitializeComponent();
        }

        private void frmTimKhachHang_Load(object sender, EventArgs e)
        {
            cboLuaChon.Items.AddRange(new string[]
            {
                "Mã khách hàng",
                "Tên khách hàng",
                "Tác giới tính",
            });
            cboLuaChon.SelectedIndex = 0;

            LoadDGV();
            dgvKhachHang_Click(sender, e);
        }

        #region CustomDesign
        public void LoadUI(KhachHang kh)
        {
            lblMaKH.Text = kh.MaKH;
            lblHoTen.Text = kh.HoTen;
            lblNgaySinh.Text = kh.NgaySinh.Date.ToShortDateString();
            lblGioiTinh.Text = kh.GioiTinh;
            lblDiaChi.Text = kh.DiaChi;
            lblSoDT.Text = kh.SoDT;
        }

        public void LoadDGV()
        {
            dgvKhachHang.DataSource = KhachHangBLL.SelectAll(); ;
            lblTong.Text = string.Format("Tổng cộng: {0} khách hàng", dgvKhachHang.Rows.Count);
        }

        public void ValidateSearch()
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
                throw new ArgumentException("Vui lòng nhập thông tin vào ô tìm kiếm!");
        }
        #endregion

        #region Buttonclick
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();
                dgvKhachHang.DataSource = KhachHangBLL.SelectALL(txtTimKiem.Text, cboLuaChon.SelectedIndex);

                if (dgvKhachHang.Rows.Count > 0)
                {
                    dgvKhachHang_Click(sender, e);
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
                dgvKhachHang.Rows.Clear();
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
        #endregion


        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUI(KhachHangBLL.Select(dgvKhachHang.SelectedRows[0].Cells["clMaKH"].Value.ToString()));
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void frmTimKhachHang_MaximumSizeChanged(object sender, EventArgs e)
        //{
        //    lblHoTen.MaximumSize = new Size(0, 0);
        //    dgvKhachHang_Click(sender,e);
        //    this.OnMaximumSizeChanged(e);
        //}
    }
}
