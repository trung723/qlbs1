using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Pages
{
    public partial class frmTacGia : Form
    {
        public frmTacGia()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maTacGia = txtMaTacGia.Text;
            string tenTacGia = txtTenTacGia.Text;


            if (!string.IsNullOrEmpty(maTacGia) && !string.IsNullOrEmpty(tenTacGia))
            {
                using (QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext())
                {
                    TacGia insert = new TacGia();

                    insert.MaTacGia = maTacGia;
                    insert.TenTacGia = tenTacGia;


                    db.TacGias.InsertOnSubmit(insert);


                    db.SubmitChanges();
                }


                LoadDatagridView();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập cả Mã Tác giả và Tên tác giả.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy mã tác giả từ TextBox
            string maTacGia = txtMaTacGia.Text.Trim();

            // Kiểm tra xem mã tác giả có được nhập hay không
            if (string.IsNullOrEmpty(maTacGia))
            {
                MessageBox.Show("Vui lòng chọn một tác giả để sửa.");
                return;
            }

            // Lấy tên tác giả từ TextBox
            string tenTacGia = txtTenTacGia.Text.Trim();

            using (QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext())
            {
                // Kiểm tra xem mã tác giả có tồn tại hay không
                var existingTacGia = db.TacGias.SingleOrDefault(tg => tg.MaTacGia == maTacGia);

                if (existingTacGia != null)
                {
                    // Cập nhật thông tin tên tác giả
                    existingTacGia.TenTacGia = tenTacGia;
                    db.SubmitChanges();

                    // Sau khi sửa, tải lại dữ liệu vào DataGridView
                    LoadDatagridView();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tác giả với mã đã chọn.");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (dgvTacGia.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");
                return;
            }

            int selectedRowIndex = dgvTacGia.SelectedCells[0].OwningRow.Index;

            // Lấy mã tác giả từ cột "MaTacGia" trong hàng đã chọn
            string maTacGia = dgvTacGia.Rows[selectedRowIndex].Cells["MaTacGia"].Value?.ToString();

            // Kiểm tra xem mã tác giả có tồn tại hay không
            if (string.IsNullOrWhiteSpace(maTacGia))
            {
                MessageBox.Show("Không tìm thấy Mã tác giả để xóa.");
                return;
            }

            using (QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext())
            {
                TacGia delete = db.TacGias.SingleOrDefault(p => p.MaTacGia.Equals(maTacGia));

                if (delete != null)
                {
                    db.TacGias.DeleteOnSubmit(delete);
                    db.SubmitChanges();
                    LoadDatagridView();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Tác giả với Mã tác giả đã chọn.");
                }
            }
        }

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            LoadDatagridView();
        }
        public void LoadDatagridView()
        {
            QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext();

            dgvTacGia.DataSource = db.TacGias.Select(d => d);
            dgvTacGia.Columns["MaTacGia"].HeaderText = "Mã tác giả";
            dgvTacGia.Columns["TenTacGia"].HeaderText = "Tên tác giả";
            dgvTacGia.RowHeadersVisible = false;
            dgvTacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTacGia.CellFormatting += dgvTacGia_CellFormatting;
        }
        private void dgvTacGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgvTacGia.Columns[e.ColumnIndex].Name == "MaTacGia")
            {
                e.CellStyle.ForeColor = Color.Blue;
            }

            else if (dgvTacGia.Columns[e.ColumnIndex].Name == "TenTacGia")
            {
                e.CellStyle.ForeColor = Color.Green;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (QuanLyCuaHangSachDataContext db = new QuanLyCuaHangSachDataContext())
            {
                string searchText = txtTimKiem.Text.Trim();

                // Tìm tác giả theo mã hoặc tên (cho phép tìm theo cả mã và tên)
                dgvTacGia.DataSource = db.TacGias
                    .Where(tg => tg.MaTacGia.Contains(searchText) || tg.TenTacGia.Contains(searchText))
                    .ToList();
            }
        }

        private void dgvTacGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private class NoRowSelectedException : Exception
        {
            public NoRowSelectedException() : base("Please select a valid row.")
            {
            }
        }
        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvTacGia.Rows.Count)
                {
                    DataGridViewRow row = dgvTacGia.Rows[e.RowIndex];

                    // Kiểm tra null trước khi truy cập giá trị
                    txtMaTacGia.Text = row.Cells["MaTacGia"].Value?.ToString() ?? "";
                    txtTenTacGia.Text = row.Cells["TenTacGia"].Value?.ToString() ?? "";
                }
                else
                {
                    throw new NoRowSelectedException();
                }
            }
            catch (NoRowSelectedException ex)
            {
                // Xử lý ngoại lệ khi không có hàng nào được chọn
                txtMaTacGia.Text = "";
                txtTenTacGia.Text = "";

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác (nếu có)
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
            txtMaTacGia.Text = "";
            txtTenTacGia.Text = "";
            LoadDatagridView();

        }
    }
}
