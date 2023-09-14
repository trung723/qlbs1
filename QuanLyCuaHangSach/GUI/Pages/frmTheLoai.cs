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
    public partial class frmTheLoai : Form
    {
        private bool isInsert = false;
        public frmTheLoai()
        {
            InitializeComponent();
        }

        #region FormEvents
        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            dgvTheLoai.AutoGenerateColumns = false;

            LockControl();
            LoadDatagridView();
            dgvTheLoai_Click(sender, e);
        }
        #endregion

        #region customDesign
        public void LockControl()
        {
            txtMaTheLoai.Enabled = false;
            txtTenTheLoai.Enabled = false;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void UnLockControl()
        {
            //txtMaTheLoai.Enabled = true;
            txtTenTheLoai.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        public void ResetControl()
        {
            txtMaTheLoai.Text = string.Empty;
            txtTenTheLoai.Text = string.Empty;
        }

        public void LoadUI(LoaiSach ls)
        {
            txtMaTheLoai.Text = ls.MaLoai;
            txtTenTheLoai.Text = ls.TenLoai;
        }

        public LoaiSach LoadLoaiSach()
        {
            return new LoaiSach()
            {
                MaLoai = txtMaTheLoai.Text,
                TenLoai = txtTenTheLoai.Text,
            };
        }

        public void LoadDatagridView()
        {
            dgvTheLoai.DataSource = TheLoaiBLL.SelectALL();
        }

        public void ValidateTheLoai()
        {
            if (string.IsNullOrEmpty(txtTenTheLoai.Text))
                throw new ArgumentException("Tên thể loại không được để trống!");
        }
        #endregion

        #region Events

        #region ButtonClick

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateTheLoai();
                if(isInsert)
                {
                    TheLoaiBLL.Insert(LoadLoaiSach());

                    MessageBox.Show("Thêm loại sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else
                {
                    TheLoaiBLL.Update(LoadLoaiSach());

                    MessageBox.Show("Sửa loại sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadDatagridView();
                LockControl();
            }catch (ArgumentException exe)
            {
                MessageBox.Show(exe.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvTheLoai_Click(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnLockControl();
            ResetControl();
            txtMaTheLoai.Text = TheLoaiBLL.autoGenerateId();
            isInsert = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UnLockControl();
            isInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    TheLoaiBLL.Delete(dgvTheLoai.SelectedRows[0].Cells["clMaLoai"].Value.ToString());

                    MessageBox.Show("Xóa loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDatagridView();
                }
            }catch
            {
                MessageBox.Show("Có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DatagridViewEvents
        private void dgvTheLoai_Click(object sender, EventArgs e)
        {
            LockControl();

            try
            {
                LoadUI(TheLoaiBLL.Select(dgvTheLoai.SelectedRows[0].Cells["clMaLoai"].Value.ToString()));
            }
            catch
            {
                ResetControl();
            }
        }

        private void dgvTheLoai_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void dgvTheLoai_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} thể loại", dgvTheLoai.Rows.Count);
        }

        private void dgvTheLoai_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTong.Text = string.Format("Tổng: {0} thể loại", dgvTheLoai.Rows.Count);
        }

        #endregion

        #endregion


    }
}
