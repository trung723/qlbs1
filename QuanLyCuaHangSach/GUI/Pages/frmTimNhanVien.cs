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
    public partial class frmTimNhanVien : Form
    {
        public frmTimNhanVien()
        {
            InitializeComponent();
        }

        private void frmTimNhanVien_Load(object sender, EventArgs e)
        {
            cboLuaChon.Items.AddRange(new string[]
            {
                "Mã nhân viên",
                "Tên nhân viên",
                "Giới tính",
            });
            cboLuaChon.SelectedIndex = 0;

            LoadDGV();
            dgvNhanVien_Click(sender, e);
        }

        #region CustomDesign
        public void LoadUI(NhanVien nv)
        {
            lblMaNV.Text = nv.MaNV;
            lblHoTen.Text = nv.HoTen;
            lblNgaySinh.Text = nv.NgaySinh.Date.ToShortDateString();
            lblGioiTinh.Text = nv.GioiTinh;
            lblDiaChi.Text = nv.DiaChi;
            lblSoDT.Text = nv.SoDT;
        }

        public void LoadDGV()
        {
            dgvNhanVien.DataSource = NhanVienBLL.SelectAll(); ;
            lblTong.Text = string.Format("Tổng cộng: {0} nhân viên", dgvNhanVien.Rows.Count);
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
                dgvNhanVien.DataSource = NhanVienBLL.SelectALL(txtTimKiem.Text, cboLuaChon.SelectedIndex);

                if (dgvNhanVien.Rows.Count > 0)
                {
                    dgvNhanVien_Click(sender, e);
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
                dgvNhanVien.Rows.Clear();
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

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUI(NhanVienBLL.Select(dgvNhanVien.SelectedRows[0].Cells["clMaNV"].Value.ToString()));
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
