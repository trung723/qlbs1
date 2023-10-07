using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public static class TaiKhoanBLL
    {
        /// <summary>
        /// Kiem tra tai khoan va mat khau co hop le khong
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public static bool IsValid(string userName, string passWord)
        {
            try
            {
                return Select(userName).MatKhau == passWord;
            }catch
            {
                return false;
            }
        }

        /// <summary>
        /// Tra ve ID cua tai khoan
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        public static string fullUserID(TaiKhoan tk)
        {
            var a = (from t in Database.NhanViens
                     where t.MaNV == tk.MaNV
                     select t).SingleOrDefault();
            if (a != null)
                return a.MaNV;
            return null;
        }

        /// <summary>
        /// Tra ve ten day du cua nguoi dung
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        public static string fullUserName(TaiKhoan tk)
        {
            var a = (from t in Database.NhanViens
                     where t.MaNV == tk.MaNV
                     select t).Single();
            return a.HoTen;
        }

        public static TaiKhoan fullUserName(string tenTK)
        {
            return (from t in Database.TaiKhoans
                    from n in Database.NhanViens
                    where t.TenTK == tenTK && t.MaNV == n.MaNV
                    select t).Single();
        }


        /// <summary>
        /// Tra ve quyen cua nguoi dung cua ten tai khoan
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        public static string fullUserType(TaiKhoan tk)
        {
            var a = (from q in Database.Quyens
                     where q.MaQuyen == tk.MaQuyen
                     select q).Single();
            return a.TenQuyen;
        }

        /// <summary>
        /// Lay ra tat ca tai khoan
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from t in Database.TaiKhoans
                    select t).ToList();
        }

        /// <summary>
        /// tim kiem sach
        /// </summary>
        /// <param name="search"></param>
        /// <param name="cachTim"></param>
        /// <returns></returns>
        public static object SelectAll(string search, int cachTim)
        {
            return (from t in GlobalSettings.Database.TaiKhoans
                    where (cachTim == 0 ? t.TenTK.Contains(search) : true &&
                           cachTim == 1 ? t.NhanVien.HoTen.Contains(search) : true &&
                           cachTim == 2 ? t.Quyen.TenQuyen.Contains(search) : true)
                    select new
                    {
                        t.TenTK,
                        t.MatKhau,
                        t.NhanVien.HoTen,
                        t.Quyen.TenQuyen,
                    });
        }

        /// <summary>
        /// Lay ra tat ca tai khoan voi ten nhan vien va ten quyen cua tai khoan
        /// </summary>
        /// <returns></returns>
        public static object SelectTKNVQ(string tenTK)
        {
            switch(tenTK)
            {
                case null:
                    return (from t in Database.TaiKhoans
                            from n in Database.NhanViens
                            from q in Database.Quyens
                            where t.MaNV == n.MaNV && t.MaQuyen == q.MaQuyen
                            select new
                            {
                                t.TenTK,
                                t.MatKhau,
                                t.MaNV,
                                n.HoTen,
                                q.TenQuyen,
                            });
                default:
                    return (from t in Database.TaiKhoans
                            from n in Database.NhanViens
                            from q in Database.Quyens
                            where t.MaNV == n.MaNV && t.MaQuyen == q.MaQuyen && t.TenTK.Contains(tenTK)
                            select new
                            {
                                t.TenTK,
                                t.MatKhau,
                                t.MaNV,
                                n.HoTen,
                                q.TenQuyen,
                            });
            }
        }

        /// <summary>
        /// Lay ra thong tin tai khoan
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static TaiKhoan Select(string userName)
        {
            return (from t in Database.TaiKhoans
                    where t.TenTK == userName
                    select t).Single();
        }

        public static void Insert(TaiKhoan tk)
        {
            Database.TaiKhoans.InsertOnSubmit(tk);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Update full thong tin tai khoan
        /// </summary>
        /// <param name="tk"></param>
        public static void UpdateFull(TaiKhoan tk)
        {
            var tkCu = Select(tk.TenTK);

            tkCu.TenTK = tk.TenTK;
            tkCu.MatKhau = tk.MatKhau;
            tkCu.MaNV = tk.MaNV;
            tkCu.MaQuyen = tk.MaQuyen;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Update mat khau moi cho tai khoan
        /// </summary>
        /// <param name="tk"></param>
        public static void Update(TaiKhoan tk)
        {
            var temp = (from t in Database.TaiKhoans
                        where t.TenTK == tk.TenTK
                        select t).Single();
            temp.MatKhau = tk.MatKhau;
            Database.SubmitChanges();
        }

        /// <summary>
        /// Xoa tai khoan theo tenTK
        /// </summary>
        /// <param name="tenTK"></param>
        public static void Delete(string tenTK)
        {
            var tk = (from t in Database.TaiKhoans
                      where t.TenTK == tenTK
                      select t).Single();
            //Xoa cac bang co lien quan......

            Database.TaiKhoans.DeleteOnSubmit(tk);
            Database.SubmitChanges();
        }

        public static bool IsValid(string query)
        {
            throw new NotImplementedException();
        }
    }
}
