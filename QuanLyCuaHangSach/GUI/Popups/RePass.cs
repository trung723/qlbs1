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
    public partial class RePass : Form
    {
        public RePass()
        {
            InitializeComponent();
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string manv = txbMa.Text.Trim();

            if (string.IsNullOrEmpty(manv))
            {
                MessageBox.Show("Vui lòng nhập mã NV đăng ký!");
            }
            else
            {
                string query = "Select * from TaiKhoan where manv = '" + manv + "'";

                if (manv == "NV01")
                {
                    label1.ForeColor = Color.Blue;
                    label1.Text = "Mật khẩu: 123456";
                }
                else if (TaiKhoanBLL.IsValid(query))
                {
                    // Hiển thị mật khẩu đã lưu trong Settings
                    label1.ForeColor = Color.Blue;
                    label1.Text = "Mật khẩu: " + Settings.Default.Log_Password;
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "Mã NV này chưa được đăng ký!";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
