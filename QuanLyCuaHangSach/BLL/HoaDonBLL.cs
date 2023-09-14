using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public struct BaoCaoDoanhThu
    {
        public string MaHD { get; set; }
        public DateTime? ThoiDiemLapHD { get; set; }
        public string HoTenKH { get; set; }
        public string HoTenNV { get; set; }
        public double TongTien { get; set; }
    }
    public class HoaDonBLL
    {
        /// <summary>
        /// Lay ra tat ca hoa don
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from t in Database.HoaDons
                    select t).ToList();
        }


        /// <summary>
        /// Tim kiem hoa don theo ma hoa don
        /// </summary>
        /// <param name="maHD">Ma phieu nhap can tim</param>
        /// <returns></returns>
        public static object SelectAll(string maHD)
        {
            return (from t in Database.HoaDons
                    where t.MaHD.Contains(maHD)
                    select new
                    {
                       MaHD = t.MaHD,
                       ThoiDiemLapHD = t.ThoiDiemLapHD,
                       HoTenNV = t.NhanVien.HoTen,
                       HoTenKH = t.KhachHang.HoTen,
                    });
        }

        /// <summary>
        /// Lay ra thong tin hoa don bao gom ten nv va ten kh
        /// </summary>
        /// <param name="maHD"></param>
        /// <returns></returns>
        public static object SelectNVKH(string maHD)
        {
            switch (maHD)
            {
                case null:
                    return (from t in Database.HoaDons
                            select new
                            {
                                MaHD = t.MaHD,
                                ThoiDiemLapHD = t.ThoiDiemLapHD,
                                HoTenKH = t.KhachHang.HoTen,
                                HoTenNV = t.NhanVien.HoTen,
                                TongTien = ChiTietHoaDonBLL.SelectTongTien(t.MaHD),
                            });
                default:
                    var a = (from t in Database.HoaDons
                             where t.MaHD == maHD
                             select new
                             {
                                 MaHD = t.MaHD,
                                 ThoiDiemLapHD = t.ThoiDiemLapHD,
                                 HoTenKH = t.KhachHang.HoTen,
                                 HoTenNV = t.NhanVien.HoTen,
                                 TongTien = ChiTietHoaDonBLL.SelectTongTien(t.MaHD),
                             }).Single();
                    return a;
            }
        }

        /// <summary>
        /// Lay ra hoa don theo ma hoa don
        /// </summary>
        /// <param name="maHD">Ma hoa don can lay</param>
        /// <returns></returns>
        public static HoaDon Select(string maHD)
        {
            return (from t in Database.HoaDons
                    where t.MaHD == maHD
                    select t).Single();
        }


        public static IQueryable<BaoCaoDoanhThu> BaoCaoDoanhThu (int month, int year)
        {
            return from t in Database.HoaDons
                   where (t.ThoiDiemLapHD.Month == month) &&
                         (t.ThoiDiemLapHD.Year == year)
                   select new BaoCaoDoanhThu
                   {
                       MaHD = t.MaHD,
                       ThoiDiemLapHD = t.ThoiDiemLapHD,
                       HoTenNV = t.NhanVien.HoTen,
                       HoTenKH = t.KhachHang.HoTen,
                       TongTien = ChiTietHoaDonBLL.SelectTongTien(t.MaHD),
                   };
        }

        /// <summary>
        /// Them 1 hoa don moi 
        /// </summary>
        /// <param name="hd">Thong tin hoa don moi</param>
        public static void Insert(HoaDon hd)
        {
            Database.HoaDons.InsertOnSubmit(hd);
            Database.SubmitChanges();
        }


        /// <summary>
        /// Sua thong tin hoa don 
        /// </summary>
        /// <param name="hd">Thong tin hoa don</param>
        public static void Update(HoaDon hd)
        {
            var pnCu = Select(hd.MaHD);

            pnCu.MaHD = hd.MaHD;
            pnCu.ThoiDiemLapHD = hd.ThoiDiemLapHD;
            pnCu.MaKH = hd.MaKH;
            pnCu.MaNV = hd.MaNV;

            Database.SubmitChanges();
        }

        public static void Delete(string maHD)
        {
            var h = (from t in Database.HoaDons
                     where t.MaHD == maHD
                     select t).Single();
            var ct = (from t in Database.ChiTietHoaDons
                      where t.MaHD == maHD
                      select t);
            foreach (var i in ct)
            {
                ChiTietHoaDonBLL.Delete(h.MaHD);
            }

            Database.HoaDons.DeleteOnSubmit(h);
            Database.SubmitChanges();
        }


        /// <summary>
        /// Tu dong tao ID cho phieu nhap moi 
        /// </summary>
        /// <returns></returns>
        public static string autoGenerateId()
        {
            string result = "HD";
            var temp = from p in GlobalSettings.Database.HoaDons
                       where p.MaHD.StartsWith(result)
                       select p.MaHD;
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
