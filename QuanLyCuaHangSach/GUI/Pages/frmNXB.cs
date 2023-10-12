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
    public partial class frmNXB : Form
    {
        public frmNXB()
        {
            InitializeComponent();
        }

        
        private void frmNXB_Load(object sender, EventArgs e)
        {
            LoadDatagridView();
        }
        public void LoadDatagridView()
        {
            QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext();

            dgvNXB.DataSource = db.NXBs.Select(d => d);
          
            dgvNXB.Columns["MaNXB"].HeaderText = "Mã NXB";
            dgvNXB.Columns["TenNXB"].HeaderText = "Tên NXB";
            dgvNXB.RowHeadersVisible = false;
            dgvNXB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNXB.CellFormatting += dgvNXB_CellFormatting;
            dgvNXB.CellClick += dgvNXB_CellClick;
        }
        private class NoRowSelectedException : Exception
        {
            public NoRowSelectedException() : base("Please select a valid row.")
            {
            }
        }
        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvNXB.Rows.Count)
                {
                    DataGridViewRow row = dgvNXB.Rows[e.RowIndex];

                    // Kiểm tra null trước khi truy cập giá trị
                    txtMaNXB.Text = row.Cells["MaNXB"].Value?.ToString() ?? "";
                    txtTenNXB.Text = row.Cells["TenNXB"].Value?.ToString() ?? "";
                }
                else
                {
                    throw new NoRowSelectedException();
                }
            }
            catch (NoRowSelectedException ex)
            {
                // Xử lý ngoại lệ khi không có hàng nào được chọn
                txtMaNXB.Text = "";
                txtTenNXB.Text = "";

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác (nếu có)
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void dgvNXB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (dgvNXB.Columns[e.ColumnIndex].Name == "MaNXB")
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
          
            else if (dgvNXB.Columns[e.ColumnIndex].Name == "TenNXB")
            {
                e.CellStyle.ForeColor = Color.Green;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            string maNXB = txtMaNXB.Text;

            
            if (!string.IsNullOrEmpty(maNXB))
            {
                using (QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext())
                {
                    
                    NXB delete = db.NXBs.Where(p => p.MaNXB.Equals(maNXB)).SingleOrDefault();

                    if (delete != null)
                    {
                        
                        db.NXBs.DeleteOnSubmit(delete);

                        
                        db.SubmitChanges();

                        
                        LoadDatagridView();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy NXB với Mã NXB đã nhập.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Mã NXB để xóa.");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm.");
                return;  
            }

            using (QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext())
            {
                dgvNXB.DataSource = db.NXBs.Where(p => p.MaNXB.Contains(searchTerm) || p.TenNXB.Contains(searchTerm)).ToList();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            string maNXB = txtMaNXB.Text;
            string tenNXB = txtTenNXB.Text;

            
            if (!string.IsNullOrEmpty(maNXB) && !string.IsNullOrEmpty(tenNXB))
            {
                using (QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext())
                {
                   
                    NXB edit = db.NXBs.Where(p => p.MaNXB.Equals(maNXB)).SingleOrDefault();

                    if (edit != null)
                    {
                        edit.TenNXB = tenNXB;

                        
                        db.SubmitChanges();

                        
                        LoadDatagridView();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy NXB với Mã NXB đã nhập.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập cả Mã NXB và Tên NXB.");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            string maNXB = txtMaNXB.Text;
            string tenNXB = txtTenNXB.Text;

            
            if (!string.IsNullOrEmpty(maNXB) && !string.IsNullOrEmpty(tenNXB))
            {
                using (QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext())
                {
                    NXB insert = new NXB();

                    insert.MaNXB = maNXB;
                    insert.TenNXB = tenNXB;

                   
                    db.NXBs.InsertOnSubmit(insert);

                   
                    db.SubmitChanges();
                }

               
                LoadDatagridView();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập cả Mã NXB và Tên NXB.");
            }
        }

        private void lblTong_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNXB = txtMaNXB.Text.Trim();
            string tenNXB = txtTenNXB.Text.Trim();

            // Kiểm tra Mã NXB và Tên NXB không được để trống
            if (string.IsNullOrEmpty(maNXB) || string.IsNullOrEmpty(tenNXB))
            {
                MessageBox.Show("Vui lòng nhập cả Mã NXB và Tên NXB.");
                return;
            }

            using (QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext())
            {
                NXB existingNXB = db.NXBs.SingleOrDefault(p => p.MaNXB.Equals(maNXB));

                if (existingNXB != null)
                {
                    existingNXB.TenNXB = tenNXB;
                }
                else
                {
                    NXB newNXB = new NXB
                    {
                        MaNXB = maNXB,
                        TenNXB = tenNXB
                    };
                    db.NXBs.InsertOnSubmit(newNXB);
                }

                db.SubmitChanges();
                LoadDatagridView();
                ResetForm();
            }
        }
        private void ResetForm()
        {
            txtMaNXB.Clear();
            txtTenNXB.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadDatagridView();
        }
        private void ClearDataGridView()
        {
            dgvNXB.Rows.Clear();  // Xóa tất cả các hàng từ DataGridView
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            ClearDataGridView();
        }
    }

}
