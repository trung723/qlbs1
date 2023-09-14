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

namespace GUI.Popups
{
    public partial class frmKetNoiDatabase : Form
    {
        private string strcnn;
        public frmKetNoiDatabase()
        {
            InitializeComponent();
        }

        private void frmKetNoiDatabase_Load(object sender, EventArgs e)
        {
            cboKieuXacThuc.Items.AddRange(new string[]
            {
                "Windows Authentication",
                "Sql Server Authentication"
            });

            cboKieuXacThuc.SelectedIndex = 0;

            //luu ten va danh sach sever vao global setting
            txtServerName.Text = GlobalSettings.severName;
            cboDatabase.Text = GlobalSettings.severCatalog;
        }

        private void cboKieuXacThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenDangNhap.Enabled = txtMatKhau.Enabled = cboKieuXacThuc.SelectedIndex == 1;
        }

        private void btnKiemtra_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                    throw new ArgumentException("Tên đăng nhập không được để trống");

                strcnn = string.Format("Data Source = {0}; Initial Catalog = master; ", txtServerName.Text);
                if (cboKieuXacThuc.SelectedIndex == 0)
                    strcnn += "Integrated Security=True; ";
                else
                    strcnn += string.Format("User Id = {0}; Password = {1};", txtTenDangNhap.Text, txtMatKhau.Text);

                cboDatabase.DataSource = GlobalSettings.GetDatabaseList(strcnn);
                MessageBox.Show("Kết nối thành công!" + Environment.NewLine + "Vui lòng chọn cơ cở dữ liệu.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDatabase.Enabled = true;
                btnLuu.Enabled = true;
            }catch (ArgumentException exe)
            {
                MessageBox.Show(exe.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }catch
            {
                MessageBox.Show("Kết nối thất bại!" + Environment.NewLine + "Vui lòng thử lại một lần nữa.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            strcnn = string.Format("Data Source = {0}; Initial Catalog = {1}; ", txtServerName.Text, cboDatabase.Text);
            
            if (cboKieuXacThuc.SelectedIndex == 0)
                strcnn += "Integrated Security = True; ";
            else
                strcnn += string.Format("User Id = {0}; Password = {1};", txtTenDangNhap.Text, txtMatKhau.Text);

            GlobalSettings.connectionString = strcnn;
            GlobalSettings.severName = txtServerName.Text;
            GlobalSettings.severCatalog = cboDatabase.Text;

            GlobalSettings.SaveDatabaseConnection();

            MessageBox.Show("Lưu kết nối CSDL thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        } 
    }
}
