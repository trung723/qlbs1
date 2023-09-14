using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public static class NhanVienBLL
    {

        /// <summary>
        /// Lay ra tat ca Nhan vien
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from t in Database.NhanViens
                    select t).ToList();
        }

        /// <summary>
        /// Tim kiem nhan vien theo thong tin nhan vien
        /// </summary>
        /// <param name="search">Thong tin can tim</param>
        /// <returns></returns>
        public static object SelectALL(string search, int cachTim)
        {
            return (from t in GlobalSettings.Database.NhanViens
                    where (cachTim == 0 ? t.MaNV.Contains(search) : true &&
                           cachTim == 1 ? t.HoTen.Contains(search) : true &&
                           cachTim == 2 ? t.GioiTinh.Contains(search) : true)
                    select t).ToList();
        }

        /// <summary>
        /// Lay ra Nhan vien theo MaNV
        /// </summary>
        /// <param name="nv"></param>
        /// <returns></returns>
        public static NhanVien Select(string maNV)
        {
            return (from t in Database.NhanViens
                     where t.MaNV == maNV
                     select t).Single();
        }

        /// <summary>
        /// Them 1 nhan vien moi
        /// </summary>
        /// <param name="nv">Doi tuong nhan vien can them</param>
        public static void Insert(NhanVien nv)
        {
            Database.NhanViens.InsertOnSubmit(nv);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Sua thong tin cua nhan vien
        /// </summary>
        /// <param name="nv">Doi tuong nhan vien can sua</param>
        public static void Update(NhanVien nv)
        {
            var nvCu = Select(nv.MaNV);

            nvCu.MaNV = nv.MaNV;
            nvCu.HoTen = nv.HoTen;
            nvCu.NgaySinh = nv.NgaySinh;
            nvCu.GioiTinh = nv.GioiTinh;
            nvCu.DiaChi = nv.DiaChi;
            nvCu.SoDT = nv.SoDT;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Xoa 1 nhan vien theo maNV
        /// </summary>
        /// <param name="maNV">Ma nhan vien</param>
        public static void Delete(string maNV)
        {
            var n = (from t in Database.NhanViens
                     where t.MaNV == maNV
                     select t).Single();
            
            //xoa cac bang co lien quan..........
            var tk = from t in Database.TaiKhoans
                      where t.MaNV == maNV
                      select t;
            foreach(var i in tk)
            {
                TaiKhoanBLL.Delete(i.TenTK);
            }
            //Xoa bang hoa don
            var hd = from t in Database.HoaDons
                     where t.MaNV == maNV
                     select t;
            foreach(var i in hd)
            {
                HoaDonBLL.Delete(i.MaHD);
            }
            //Xoa bang phieu nhap
            var pn = from t in Database.PhieuNhaps
                     where t.MaNV == maNV
                     select t;
            foreach(var i in pn)
            {
                PhieuNhapBLL.Delete(i.MaPN);
            }

            Database.NhanViens.DeleteOnSubmit(n);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Tu dong tao ID cho NhanVien
        /// </summary>
        /// <returns></returns>
        public static string autoGenerateId()
        {
            string result = "NV";
            var temp = from p in GlobalSettings.Database.NhanViens
                       where p.MaNV.StartsWith(result)
                       select p.MaNV;
            int max = -1;

            foreach (var i in temp)
            {
                int j = int.Parse(i.Substring(2, 2));
                if (j > max) max = j;
            }

            return string.Format("{0}{1:D2}", result, max + 1);
        }
    }
}
