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
    public partial class frmTimTheLoai : Form
    {
        public frmTimTheLoai()
        {
            InitializeComponent();
        }

        private void frmTimTheLoai_Load(object sender, EventArgs e)
        {
            cboLuaChon.Items.AddRange(new string[]
             {
                "Mã thể loại",
                "Tên thể loại",
             });
            cboLuaChon.SelectedIndex = 0;

            LoadDGV();
            dgvTheLoai_Click(sender, e);
        }

        #region CustomDesign
        public void LoadUI(LoaiSach ls)
        {
            lblMaLoai.Text = ls.MaLoai;
            lblTenLoai.Text = ls.TenLoai;
        }

        public void LoadDGV()
        {
            dgvTheLoai.DataSource = TheLoaiBLL.SelectALL();
            lblTong.Text = string.Format("Tổng cộng: {0} loại sách", dgvTheLoai.Rows.Count);
        }

        public void ValidateSearch()
        {
            if(string.IsNullOrEmpty(txtTimKiem.Text))
                throw new ArgumentException("Vui lòng nhập thông tin vào ô tìm kiếm!");
        }
        #endregion

        #region DatagridView
        private void dgvTheLoai_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUI(TheLoaiBLL.Select(dgvTheLoai.SelectedRows[0].Cells["clMaLoai"].Value.ToString()));
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ButtonClick
        private void btnDatLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = string.Empty;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            try
            {
                ValidateSearch();
                dgvTheLoai.DataSource = TheLoaiBLL.SelectALL(txtTimKiem.Text, cboLuaChon.SelectedIndex);

                if(dgvTheLoai.Rows.Count > 0)
                {
                    dgvTheLoai_Click(sender, e);
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
                dgvTheLoai.Rows.Clear();
            }
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            LoadDGV();
            btnDatLai_Click(sender, e);
        }

        #endregion
    }
}
