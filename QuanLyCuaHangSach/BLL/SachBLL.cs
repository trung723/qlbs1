using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public static class SachBLL
    {

        /// <summary>
        /// lay ra tat ca sach
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from t in Database.Saches
                    select t).ToList();
        }

        /// <summary>
        /// Tim kiem thong tin sach
        /// </summary>
        /// <param name="search">Thong tin can tim</param>
        /// <returns></returns>
        public static object SelectALL(string search, int cachTim)
        {
            return (from t in GlobalSettings.Database.Saches
                    where (cachTim == 0 ? t.MaSach.Contains(search) : true &&
                           cachTim == 1 ? t.TenSach.Contains(search) : true &&
                           cachTim == 2 ? t.Tacgia.Contains(search) : true &&
                           cachTim == 3 ? t.LoaiSach.TenLoai.Contains(search) : true)
                    select new
                    {
                        t.MaSach,
                        t.LoaiSach.TenLoai,
                        t.TenSach,
                        t.Tacgia,
                        //t.DonGia,
                        t.SoLuong,
                    }).ToList();
        }

        /// <summary>
        /// lay ra sach va ten the loai
        /// </summary>
        /// <returns></returns>
        public static object selectAndLoaiSach()
        {
            return (from s in Database.Saches
                    from l in Database.LoaiSaches
                    where s.MaLoai == l.MaLoai
                    select new {
                        s.MaSach,
                        l.TenLoai,
                        s.TenSach,
                        s.Tacgia,
                        //s.DonGia,
                        s.SoLuong
                    });
        }

        //public static object selectFullSach(string maSach)
        //{
        //    return (from s in Database.Saches
        //            from l in Database.LoaiSaches
        //            where s.MaLoai == l.MaLoai && s.MaSach == maSach
        //            select new
        //            {
        //                s.MaSach,
        //                l.TenLoai,
        //                s.TenSach,
        //                s.Tacgia,
        //                s.DonGia,
        //                s.SoLuong
        //            });
        //}


        /// <summary>
        /// lay ra full thong tin sach theo ma sach ket hop loai sach
        /// </summary>
        /// <param name="maSach"></param>
        /// <returns></returns>
        public static object selectFullSach(string maSach)
        {
            return (from s in Database.Saches
                    from l in Database.LoaiSaches
                    where s.MaLoai == l.MaLoai
                    select new
                    {
                        s.MaSach,
                        l.TenLoai,
                        s.TenSach,
                        s.Tacgia,
                        //s.DonGia,
                        s.SoLuong
                    } into newSelect where newSelect.MaSach == maSach select newSelect);
        }

        /// <summary>
        /// lay ra sach theo ma sach
        /// </summary>
        /// <param name="sa"></param>
        /// <returns></returns>
        public static Sach Select(string maSach)
        {
            return (from t in Database.Saches
                    where t.MaSach == maSach
                    select t).Single();
        }

        /// <summary>
        /// them 1 sach moi 
        /// </summary>
        /// <param name="sa"></param>
        public static void Insert(Sach sa)
        {
            Database.Saches.InsertOnSubmit(sa);
            Database.SubmitChanges();
        }


        /// <summary>
        /// Sua thong tin sach
        /// </summary>
        /// <param name="sa"></param>
        public static void Update(Sach sa)
        {
            var sachCu = Select(sa.MaSach);

            sachCu.TenSach = sa.TenSach;
            sachCu.MaLoai = sa.MaLoai;
            sachCu.Tacgia = sa.Tacgia;
            //sachCu.DonGia = sa.DonGia;
            sachCu.SoLuong = sa.SoLuong;

            Database.SubmitChanges();
        }


        /// <summary>
        /// Update Soluong sach ton kho khi ban
        /// </summary>
        /// <param name="maSach"></param>
        /// <param name="soLuong"></param>
        public static void UpdateSoLuongNhap(string maSach, int soLuong)
        {
            var sachcu = Select(maSach);

            sachcu.SoLuong += soLuong;

            Database.SubmitChanges();
        }


        /// <summary>
        /// Update Soluong sach ton kho khi ban
        /// </summary>
        /// <param name="maSach"></param>
        /// <param name="soLuong"></param>
        public static void UpdateSoLuongBan(string maSach, int soLuong)
        {
            var sachcu = Select(maSach);

            sachcu.SoLuong -= soLuong;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Xoa 1 sach
        /// </summary>
        /// <param name="maSach"></param>
        public static void Delete(string maSach)
        {
            var s = (from t in Database.Saches
                     where t.MaSach == maSach
                     select t).Single();
            //Xoa sach trong CTPN
            var ns = (from t in Database.ChiTietPhieuNhaps
                      where t.MaSach == maSach
                      select t);
            foreach(var i in ns)
            {
                ChiTietPhieuNhapBLL.DeleteSach(i.MaSach);
            }

            //Xoa sach trong chi tiet hoa don
            var bs = (from t in Database.ChiTietHoaDons
                      where t.MaSach == maSach
                      select t);
            foreach (var i in bs)
            {
                ChiTietHoaDonBLL.DeleteSach(i.MaSach);
            }

            Database.Saches.DeleteOnSubmit(s);
            Database.SubmitChanges();
        }

        /// <summary>
        /// tu dong tao id
        /// </summary>
        /// <returns></returns>
        public static string autoGenerateId()
        {
            string result = "S";
            var temp = from p in GlobalSettings.Database.Saches
                       where p.MaSach.StartsWith(result)
                       select p.MaSach;
            int max = -1;

            foreach (var i in temp)
            {
                int j = int.Parse(i.Substring(1, 2));
                if (j > max) max = j;
            }

            return string.Format("{0}{1:D2}", result, max + 1);
        }
    }
}
