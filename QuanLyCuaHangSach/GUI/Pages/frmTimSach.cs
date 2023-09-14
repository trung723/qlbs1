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
    public partial class frmTimSach : Form
    {
        public frmTimSach()
        {
            InitializeComponent();
        }

        private void frmTimSach_Load(object sender, EventArgs e)
        {
            cboLuaChon.Items.AddRange(new string[]
            {
                "Mã sách",
                "Tên sách",
                "Tác giả",
                "Thể loại",
            });
            cboLuaChon.SelectedIndex = 0;

            LoadDGV();
            dgvSach_Click(sender, e);
        }

        #region CustomDesign
        public void LoadUI(Sach s)
        {
            lblMaSach.Text = s.MaSach;
            lblTheLoai.Text = TheLoaiBLL.SelectTenLoai(s.MaLoai);
            lblTenSach.Text = s.TenSach;
            lblTacGia.Text = s.Tacgia;
            //lblDonGia.Text = s.DonGia.ToString();
            lblSoLuong.Text = s.SoLuong.ToString();
        }

        public void LoadDGV()
        {
            dgvSach.DataSource = SachBLL.selectAndLoaiSach();
            lblTong.Text = string.Format("Tổng cộng: {0} sách", dgvSach.Rows.Count);
        }

        public void ValidateSearch()
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
                throw new ArgumentException("Vui lòng nhập thông tin vào ô tìm kiếm!");
        }
        #endregion

        #region ButtonClick
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();
                dgvSach.DataSource = SachBLL.SelectALL(txtTimKiem.Text, cboLuaChon.SelectedIndex);

                if (dgvSach.Rows.Count > 0)
                {
                    dgvSach_Click(sender, e);
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
                dgvSach.Rows.Clear();
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

        #region DataGV
        private void dgvSach_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUI(SachBLL.Select(dgvSach.SelectedRows[0].Cells["clMaSach"].Value.ToString()));
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
