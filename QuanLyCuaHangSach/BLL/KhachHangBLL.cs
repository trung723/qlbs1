using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public class KhachHangBLL
    {
        /// <summary>
        /// Lay ra tat ca khach hang
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from t in Database.KhachHangs
                    select t).ToList();
        }


        /// <summary>
        /// Tim kiem khach hang theo thong tin khach hang
        /// </summary>
        /// <param name="search">Thong tin can tim</param>
        /// <returns></returns>
        public static object SelectALL(string search, int cachTim)
        {
            return (from t in GlobalSettings.Database.KhachHangs
                    where (cachTim == 0 ? t.MaKH.Contains(search): true &&
                           cachTim == 1 ? t.HoTen.Contains(search): true &&
                           cachTim == 2 ? t.GioiTinh.Contains(search) : true)
                    select t).ToList();
        }
        /// <summary>
        /// Lay ra khach hang theo maKh
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public static KhachHang Select(string maKH)
        {
            return (from t in Database.KhachHangs
                    where t.MaKH == maKH
                    select t).Single();
        }

        public static void Insert(KhachHang kh)
        {
            Database.KhachHangs.InsertOnSubmit(kh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Sua thong tin khach hang
        /// </summary>
        /// <param name="kh"></param>
        public static void Update(KhachHang kh)
        {
            var khCu = Select(kh.MaKH);

            khCu.MaKH = kh.MaKH;
            khCu.HoTen = kh.HoTen;
            khCu.NgaySinh = kh.NgaySinh;
            khCu.GioiTinh = kh.GioiTinh;
            khCu.DiaChi = kh.DiaChi;
            khCu.SoDT = kh.SoDT;
        }

        /// <summary>
        /// Xoa 1 khach hang
        /// </summary>
        /// <param name="maKH"></param>
        public static void Delete(string maKH)
        {
            var k = (from t in Database.KhachHangs
                     where t.MaKH == maKH
                     select t).Single();
            //Xoa bang hoa don
            var hd = (from t in Database.HoaDons
                      where t.MaKH == maKH
                      select t);
            foreach(var i in hd)
            {
                HoaDonBLL.Delete(i.MaHD);
            }

            Database.KhachHangs.DeleteOnSubmit(k);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Ham tao ID tu dong
        /// </summary>
        /// <returns></returns>
        public static string autoGenerateId()
        {
            string result = "KH";
            var temp = from p in GlobalSettings.Database.KhachHangs
                       where p.MaKH.StartsWith(result)
                       select p.MaKH;
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
