
namespace GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnDoiMatKhau = new FontAwesome.Sharp.IconButton();
            this.panelThongKeSubMenu = new System.Windows.Forms.Panel();
            this.btnThongKeSoLuongNhap = new System.Windows.Forms.Button();
            this.btnThongKeDoanhThu = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThongKe = new FontAwesome.Sharp.IconButton();
            this.panelTimKiemSubMenu = new System.Windows.Forms.Panel();
            this.btnTimTaiKhoan = new System.Windows.Forms.Button();
            this.btnTimKhachHang = new System.Windows.Forms.Button();
            this.btnTimNhanVien = new System.Windows.Forms.Button();
            this.btnTimTheLoai = new System.Windows.Forms.Button();
            this.btnTimSach = new System.Windows.Forms.Button();
            this.btnTimKiem = new FontAwesome.Sharp.IconButton();
            this.panelKinhDoanhSubMenu = new System.Windows.Forms.Panel();
            this.btnBanSach = new System.Windows.Forms.Button();
            this.btnNhapSach = new System.Windows.Forms.Button();
            this.btnKinhDoanh = new FontAwesome.Sharp.IconButton();
            this.panelQuanLySubMenu = new System.Windows.Forms.Panel();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnSach = new System.Windows.Forms.Button();
            this.btnTheLoai = new System.Windows.Forms.Button();
            this.btnQuanLy = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlWorkSpace = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.lblFormName = new System.Windows.Forms.Label();
            this.panelSideMenu.SuspendLayout();
            this.panelThongKeSubMenu.SuspendLayout();
            this.panelTimKiemSubMenu.SuspendLayout();
            this.panelKinhDoanhSubMenu.SuspendLayout();
            this.panelQuanLySubMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlWorkSpace.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panelSideMenu.Controls.Add(this.btnDoiMatKhau);
            this.panelSideMenu.Controls.Add(this.panelThongKeSubMenu);
            this.panelSideMenu.Controls.Add(this.btnDangXuat);
            this.panelSideMenu.Controls.Add(this.btnThongKe);
            this.panelSideMenu.Controls.Add(this.panelTimKiemSubMenu);
            this.panelSideMenu.Controls.Add(this.btnTimKiem);
            this.panelSideMenu.Controls.Add(this.panelKinhDoanhSubMenu);
            this.panelSideMenu.Controls.Add(this.btnKinhDoanh);
            this.panelSideMenu.Controls.Add(this.panelQuanLySubMenu);
            this.panelSideMenu.Controls.Add(this.btnQuanLy);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 758);
            this.panelSideMenu.TabIndex = 1;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDoiMatKhau.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDoiMatKhau.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            this.btnDoiMatKhau.IconColor = System.Drawing.Color.White;
            this.btnDoiMatKhau.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoiMatKhau.IconSize = 35;
            this.btnDoiMatKhau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(0, 919);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(233, 45);
            this.btnDoiMatKhau.TabIndex = 10;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoiMatKhau.UseVisualStyleBackColor = false;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // panelThongKeSubMenu
            // 
            this.panelThongKeSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.panelThongKeSubMenu.Controls.Add(this.btnThongKeSoLuongNhap);
            this.panelThongKeSubMenu.Controls.Add(this.btnThongKeDoanhThu);
            this.panelThongKeSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThongKeSubMenu.Location = new System.Drawing.Point(0, 829);
            this.panelThongKeSubMenu.Name = "panelThongKeSubMenu";
            this.panelThongKeSubMenu.Size = new System.Drawing.Size(233, 90);
            this.panelThongKeSubMenu.TabIndex = 9;
            // 
            // btnThongKeSoLuongNhap
            // 
            this.btnThongKeSoLuongNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKeSoLuongNhap.FlatAppearance.BorderSize = 0;
            this.btnThongKeSoLuongNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeSoLuongNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeSoLuongNhap.ForeColor = System.Drawing.Color.LightGray;
            this.btnThongKeSoLuongNhap.Location = new System.Drawing.Point(0, 40);
            this.btnThongKeSoLuongNhap.Name = "btnThongKeSoLuongNhap";
            this.btnThongKeSoLuongNhap.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnThongKeSoLuongNhap.Size = new System.Drawing.Size(233, 40);
            this.btnThongKeSoLuongNhap.TabIndex = 2;
            this.btnThongKeSoLuongNhap.Text = "Số lượng nhập";
            this.btnThongKeSoLuongNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKeSoLuongNhap.UseVisualStyleBackColor = true;
            this.btnThongKeSoLuongNhap.Click += new System.EventHandler(this.btnThongKeSoLuongNhap_Click);
            // 
            // btnThongKeDoanhThu
            // 
            this.btnThongKeDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKeDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnThongKeDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeDoanhThu.ForeColor = System.Drawing.Color.LightGray;
            this.btnThongKeDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.btnThongKeDoanhThu.Name = "btnThongKeDoanhThu";
            this.btnThongKeDoanhThu.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnThongKeDoanhThu.Size = new System.Drawing.Size(233, 40);
            this.btnThongKeDoanhThu.TabIndex = 1;
            this.btnThongKeDoanhThu.Text = "Doanh thu";
            this.btnThongKeDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKeDoanhThu.UseVisualStyleBackColor = true;
            this.btnThongKeDoanhThu.Click += new System.EventHandler(this.btnThongKeDoanhThu_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.LightGray;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 964);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(233, 45);
            this.btnDangXuat.TabIndex = 8;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnThongKe.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            this.btnThongKe.IconColor = System.Drawing.Color.White;
            this.btnThongKe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongKe.IconSize = 35;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(0, 784);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(233, 45);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // panelTimKiemSubMenu
            // 
            this.panelTimKiemSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.panelTimKiemSubMenu.Controls.Add(this.btnTimTaiKhoan);
            this.panelTimKiemSubMenu.Controls.Add(this.btnTimKhachHang);
            this.panelTimKiemSubMenu.Controls.Add(this.btnTimNhanVien);
            this.panelTimKiemSubMenu.Controls.Add(this.btnTimTheLoai);
            this.panelTimKiemSubMenu.Controls.Add(this.btnTimSach);
            this.panelTimKiemSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTimKiemSubMenu.Location = new System.Drawing.Point(0, 574);
            this.panelTimKiemSubMenu.Name = "panelTimKiemSubMenu";
            this.panelTimKiemSubMenu.Size = new System.Drawing.Size(233, 210);
            this.panelTimKiemSubMenu.TabIndex = 6;
            // 
            // btnTimTaiKhoan
            // 
            this.btnTimTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTimTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimTaiKhoan.ForeColor = System.Drawing.Color.LightGray;
            this.btnTimTaiKhoan.Location = new System.Drawing.Point(0, 160);
            this.btnTimTaiKhoan.Name = "btnTimTaiKhoan";
            this.btnTimTaiKhoan.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTimTaiKhoan.Size = new System.Drawing.Size(233, 40);
            this.btnTimTaiKhoan.TabIndex = 5;
            this.btnTimTaiKhoan.Text = "Tài khoản";
            this.btnTimTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTimTaiKhoan.Click += new System.EventHandler(this.btnTimTaiKhoan_Click);
            // 
            // btnTimKhachHang
            // 
            this.btnTimKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimKhachHang.FlatAppearance.BorderSize = 0;
            this.btnTimKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKhachHang.ForeColor = System.Drawing.Color.LightGray;
            this.btnTimKhachHang.Location = new System.Drawing.Point(0, 120);
            this.btnTimKhachHang.Name = "btnTimKhachHang";
            this.btnTimKhachHang.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTimKhachHang.Size = new System.Drawing.Size(233, 40);
            this.btnTimKhachHang.TabIndex = 4;
            this.btnTimKhachHang.Text = "Khách hàng";
            this.btnTimKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKhachHang.UseVisualStyleBackColor = true;
            this.btnTimKhachHang.Click += new System.EventHandler(this.btnTimKhachHang_Click);
            // 
            // btnTimNhanVien
            // 
            this.btnTimNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimNhanVien.FlatAppearance.BorderSize = 0;
            this.btnTimNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimNhanVien.ForeColor = System.Drawing.Color.LightGray;
            this.btnTimNhanVien.Location = new System.Drawing.Point(0, 80);
            this.btnTimNhanVien.Name = "btnTimNhanVien";
            this.btnTimNhanVien.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTimNhanVien.Size = new System.Drawing.Size(233, 40);
            this.btnTimNhanVien.TabIndex = 3;
            this.btnTimNhanVien.Text = "Nhân viên";
            this.btnTimNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimNhanVien.UseVisualStyleBackColor = true;
            this.btnTimNhanVien.Click += new System.EventHandler(this.btnTimNhanVien_Click);
            // 
            // btnTimTheLoai
            // 
            this.btnTimTheLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimTheLoai.FlatAppearance.BorderSize = 0;
            this.btnTimTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimTheLoai.ForeColor = System.Drawing.Color.LightGray;
            this.btnTimTheLoai.Location = new System.Drawing.Point(0, 40);
            this.btnTimTheLoai.Name = "btnTimTheLoai";
            this.btnTimTheLoai.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTimTheLoai.Size = new System.Drawing.Size(233, 40);
            this.btnTimTheLoai.TabIndex = 2;
            this.btnTimTheLoai.Text = "Thể loại";
            this.btnTimTheLoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimTheLoai.UseVisualStyleBackColor = true;
            this.btnTimTheLoai.Click += new System.EventHandler(this.btnTimTheLoai_Click);
            // 
            // btnTimSach
            // 
            this.btnTimSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimSach.FlatAppearance.BorderSize = 0;
            this.btnTimSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimSach.ForeColor = System.Drawing.Color.LightGray;
            this.btnTimSach.Location = new System.Drawing.Point(0, 0);
            this.btnTimSach.Name = "btnTimSach";
            this.btnTimSach.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTimSach.Size = new System.Drawing.Size(233, 40);
            this.btnTimSach.TabIndex = 1;
            this.btnTimSach.Text = "Sách";
            this.btnTimSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimSach.UseVisualStyleBackColor = true;
            this.btnTimSach.Click += new System.EventHandler(this.btnTimSach_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTimKiem.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnTimKiem.IconColor = System.Drawing.Color.White;
            this.btnTimKiem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTimKiem.IconSize = 35;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(0, 529);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(233, 45);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panelKinhDoanhSubMenu
            // 
            this.panelKinhDoanhSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.panelKinhDoanhSubMenu.Controls.Add(this.btnBanSach);
            this.panelKinhDoanhSubMenu.Controls.Add(this.btnNhapSach);
            this.panelKinhDoanhSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKinhDoanhSubMenu.Location = new System.Drawing.Point(0, 439);
            this.panelKinhDoanhSubMenu.Name = "panelKinhDoanhSubMenu";
            this.panelKinhDoanhSubMenu.Size = new System.Drawing.Size(233, 90);
            this.panelKinhDoanhSubMenu.TabIndex = 4;
            // 
            // btnBanSach
            // 
            this.btnBanSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanSach.FlatAppearance.BorderSize = 0;
            this.btnBanSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanSach.ForeColor = System.Drawing.Color.LightGray;
            this.btnBanSach.Location = new System.Drawing.Point(0, 40);
            this.btnBanSach.Name = "btnBanSach";
            this.btnBanSach.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnBanSach.Size = new System.Drawing.Size(233, 40);
            this.btnBanSach.TabIndex = 2;
            this.btnBanSach.Text = "Bán sách";
            this.btnBanSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanSach.UseVisualStyleBackColor = true;
            this.btnBanSach.Click += new System.EventHandler(this.btnBanSach_Click);
            // 
            // btnNhapSach
            // 
            this.btnNhapSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapSach.FlatAppearance.BorderSize = 0;
            this.btnNhapSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapSach.ForeColor = System.Drawing.Color.LightGray;
            this.btnNhapSach.Location = new System.Drawing.Point(0, 0);
            this.btnNhapSach.Name = "btnNhapSach";
            this.btnNhapSach.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnNhapSach.Size = new System.Drawing.Size(233, 40);
            this.btnNhapSach.TabIndex = 1;
            this.btnNhapSach.Text = "Nhập sách";
            this.btnNhapSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapSach.UseVisualStyleBackColor = true;
            this.btnNhapSach.Click += new System.EventHandler(this.btnNhapSach_Click);
            // 
            // btnKinhDoanh
            // 
            this.btnKinhDoanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnKinhDoanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKinhDoanh.FlatAppearance.BorderSize = 0;
            this.btnKinhDoanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKinhDoanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKinhDoanh.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnKinhDoanh.IconChar = FontAwesome.Sharp.IconChar.BusinessTime;
            this.btnKinhDoanh.IconColor = System.Drawing.Color.White;
            this.btnKinhDoanh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKinhDoanh.IconSize = 35;
            this.btnKinhDoanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKinhDoanh.Location = new System.Drawing.Point(0, 394);
            this.btnKinhDoanh.Name = "btnKinhDoanh";
            this.btnKinhDoanh.Size = new System.Drawing.Size(233, 45);
            this.btnKinhDoanh.TabIndex = 3;
            this.btnKinhDoanh.Text = "Kinh doanh";
            this.btnKinhDoanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKinhDoanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKinhDoanh.UseVisualStyleBackColor = false;
            this.btnKinhDoanh.Click += new System.EventHandler(this.btnKinhDoanh_Click);
            // 
            // panelQuanLySubMenu
            // 
            this.panelQuanLySubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.panelQuanLySubMenu.Controls.Add(this.btnTaiKhoan);
            this.panelQuanLySubMenu.Controls.Add(this.btnKhachHang);
            this.panelQuanLySubMenu.Controls.Add(this.btnNhanVien);
            this.panelQuanLySubMenu.Controls.Add(this.btnSach);
            this.panelQuanLySubMenu.Controls.Add(this.btnTheLoai);
            this.panelQuanLySubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuanLySubMenu.Location = new System.Drawing.Point(0, 184);
            this.panelQuanLySubMenu.Name = "panelQuanLySubMenu";
            this.panelQuanLySubMenu.Size = new System.Drawing.Size(233, 210);
            this.panelQuanLySubMenu.TabIndex = 2;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.LightGray;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 160);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTaiKhoan.Size = new System.Drawing.Size(233, 44);
            this.btnTaiKhoan.TabIndex = 5;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.LightGray;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 120);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnKhachHang.Size = new System.Drawing.Size(233, 40);
            this.btnKhachHang.TabIndex = 4;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.LightGray;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 80);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnNhanVien.Size = new System.Drawing.Size(233, 40);
            this.btnNhanVien.TabIndex = 3;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnSach
            // 
            this.btnSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSach.FlatAppearance.BorderSize = 0;
            this.btnSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSach.ForeColor = System.Drawing.Color.LightGray;
            this.btnSach.Location = new System.Drawing.Point(0, 40);
            this.btnSach.Name = "btnSach";
            this.btnSach.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSach.Size = new System.Drawing.Size(233, 40);
            this.btnSach.TabIndex = 2;
            this.btnSach.Text = "Sách";
            this.btnSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSach.UseVisualStyleBackColor = true;
            this.btnSach.Click += new System.EventHandler(this.btnSach_Click);
            // 
            // btnTheLoai
            // 
            this.btnTheLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTheLoai.FlatAppearance.BorderSize = 0;
            this.btnTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheLoai.ForeColor = System.Drawing.Color.LightGray;
            this.btnTheLoai.Location = new System.Drawing.Point(0, 0);
            this.btnTheLoai.Name = "btnTheLoai";
            this.btnTheLoai.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTheLoai.Size = new System.Drawing.Size(233, 40);
            this.btnTheLoai.TabIndex = 1;
            this.btnTheLoai.Text = "Thể loại";
            this.btnTheLoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTheLoai.UseVisualStyleBackColor = true;
            this.btnTheLoai.Click += new System.EventHandler(this.btnTheLoai_Click);
            // 
            // btnQuanLy
            // 
            this.btnQuanLy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnQuanLy.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLy.FlatAppearance.BorderSize = 0;
            this.btnQuanLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLy.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQuanLy.IconChar = FontAwesome.Sharp.IconChar.UserCog;
            this.btnQuanLy.IconColor = System.Drawing.Color.White;
            this.btnQuanLy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLy.IconSize = 35;
            this.btnQuanLy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLy.Location = new System.Drawing.Point(0, 139);
            this.btnQuanLy.Name = "btnQuanLy";
            this.btnQuanLy.Size = new System.Drawing.Size(233, 45);
            this.btnQuanLy.TabIndex = 1;
            this.btnQuanLy.Text = "Quản lý";
            this.btnQuanLy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLy.UseVisualStyleBackColor = false;
            this.btnQuanLy.Click += new System.EventHandler(this.btnQuanLy_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.picLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(233, 139);
            this.panelLogo.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Blue;
            this.picLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogo.BackgroundImage")));
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(233, 139);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 7;
            this.picLogo.TabStop = false;
            // 
            // pnlWorkSpace
            // 
            this.pnlWorkSpace.BackColor = System.Drawing.Color.White;
            this.pnlWorkSpace.Controls.Add(this.panelContent);
            this.pnlWorkSpace.Controls.Add(this.panelTitle);
            this.pnlWorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkSpace.Location = new System.Drawing.Point(250, 0);
            this.pnlWorkSpace.Name = "pnlWorkSpace";
            this.pnlWorkSpace.Size = new System.Drawing.Size(925, 758);
            this.pnlWorkSpace.TabIndex = 2;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelContent.BackgroundImage")));
            this.panelContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 45);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(925, 713);
            this.panelContent.TabIndex = 6;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Navy;
            this.panelTitle.Controls.Add(this.btnCloseChildForm);
            this.panelTitle.Controls.Add(this.lblFormName);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(925, 45);
            this.panelTitle.TabIndex = 5;
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCloseChildForm.Location = new System.Drawing.Point(868, 0);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(57, 45);
            this.btnCloseChildForm.TabIndex = 8;
            this.btnCloseChildForm.Text = "X";
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // lblFormName
            // 
            this.lblFormName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormName.ForeColor = System.Drawing.Color.White;
            this.lblFormName.Location = new System.Drawing.Point(0, 0);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(211, 45);
            this.lblFormName.TabIndex = 7;
            this.lblFormName.Text = "<tenformcon>";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 758);
            this.Controls.Add(this.pnlWorkSpace);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1175, 758);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cửa hàng sách";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelThongKeSubMenu.ResumeLayout(false);
            this.panelTimKiemSubMenu.ResumeLayout(false);
            this.panelKinhDoanhSubMenu.ResumeLayout(false);
            this.panelQuanLySubMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlWorkSpace.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnDangXuat;
        private FontAwesome.Sharp.IconButton btnThongKe;
        private System.Windows.Forms.Panel panelTimKiemSubMenu;
        private System.Windows.Forms.Button btnTimKhachHang;
        private System.Windows.Forms.Button btnTimNhanVien;
        private System.Windows.Forms.Button btnTimTheLoai;
        private System.Windows.Forms.Button btnTimSach;
        private FontAwesome.Sharp.IconButton btnTimKiem;
        private System.Windows.Forms.Panel panelKinhDoanhSubMenu;
        private System.Windows.Forms.Button btnBanSach;
        private System.Windows.Forms.Button btnNhapSach;
        private FontAwesome.Sharp.IconButton btnKinhDoanh;
        private System.Windows.Forms.Panel panelQuanLySubMenu;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnSach;
        private System.Windows.Forms.Button btnTheLoai;
        private FontAwesome.Sharp.IconButton btnQuanLy;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlWorkSpace;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.Button btnTimTaiKhoan;
        private System.Windows.Forms.Panel panelThongKeSubMenu;
        private System.Windows.Forms.Button btnThongKeSoLuongNhap;
        private System.Windows.Forms.Button btnThongKeDoanhThu;
        private FontAwesome.Sharp.IconButton btnDoiMatKhau;
    }
}