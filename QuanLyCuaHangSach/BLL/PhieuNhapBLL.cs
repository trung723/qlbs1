using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public struct BaoCaoNhapSach
    {
        public string MaPN { get; set; }
        public DateTime? ThoiDiemNhap { get; set; }
        public string GhiChu { get; set; }
        public string HoTen { get; set; }
        public double TongTien { get; set; }
    }
    public static class PhieuNhapBLL
    {
        /// <summary>
        /// Lay ra tat ca phieu nhap
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from t in Database.PhieuNhaps
                    select t).ToList();
        }

        /// <summary>
        /// Tim Kiem phieu nhap theo ma phieu nhap
        /// </summary>
        /// <param name="maPn">Ma phieu nhap can tim</param>
        /// <returns></returns>
        public static object SelectAll(string maPn)
        {
            return (from t in Database.PhieuNhaps
                    where t.MaPN.Contains(maPn)
                    select new { 
                        t.MaPN,
                        t.ThoiDiemNhap,
                        t.NhanVien.HoTen,
                        t.GhiChu,
                    });
        }

        /// <summary>
        /// lay ra phieu nhap theo ma phieu nhap
        /// </summary>
        /// <param name="maPN">Ma phieu nhap can lay</param>
        /// <returns></returns>
        public static PhieuNhap Select(string maPN)
        {
            return (from t in Database.PhieuNhaps
                    where t.MaPN == maPN
                    select t).Single();
        }

        /// <summary>
        /// Lay ra thong tin phieu nhap bao gom ho ten nhan vien
        /// </summary>
        /// <param name="maPN">ma phieu nhap can lay thong tin</param>
        /// <returns></returns>
        public static object SelectNV(string maPN)
        {
            switch(maPN)
            {
                case null:
                    return (from t in Database.PhieuNhaps
                            from n in Database.NhanViens
                            where t.MaNV == n.MaNV
                            select new
                            {
                                MaPN = t.MaPN,
                                ThoiDiemNhap = t.ThoiDiemNhap,
                                GhiChu = t.GhiChu,
                                HoTen = n.HoTen,
                                TongTien = ChiTietPhieuNhapBLL.SelectTongTien(t.MaPN),
                            });
                default:
                    return (from t in Database.PhieuNhaps
                            from n in Database.NhanViens
                            where t.MaPN == maPN && t.MaNV == n.MaNV 
                            select new
                            {
                                MaPN = t.MaPN,
                                ThoiDiemNhap = t.ThoiDiemNhap,
                                GhiChu = t.GhiChu,
                                HoTen = n.HoTen,
                                TongTien = ChiTietPhieuNhapBLL.SelectTongTien(t.MaPN),
                            });
            }    
        }

        public static IQueryable<BaoCaoNhapSach> BaoCaoNhapSach(int month, int year)
        {
            return from t in Database.PhieuNhaps
                   where (t.ThoiDiemNhap.Month == month) &&
                         (t.ThoiDiemNhap.Year == year)
                   select new BaoCaoNhapSach
                   {
                       MaPN = t.MaPN,
                       ThoiDiemNhap = t.ThoiDiemNhap,
                       HoTen = t.NhanVien.HoTen,
                       GhiChu = t.GhiChu,
                       TongTien = ChiTietPhieuNhapBLL.SelectTongTien(t.MaPN),
                   };
        }

        /// <summary>
        /// Them 1 phieu nhap moi 
        /// </summary>
        /// <param name="pn">Thong tin phieu nhap moi</param>
        public static void Insert(PhieuNhap pn)
        {
            Database.PhieuNhaps.InsertOnSubmit(pn);
            Database.SubmitChanges();
        }


        /// <summary>
        /// Sua thong tin phieu nhap 
        /// </summary>
        /// <param name="pn">Thong tin phieu nhap</param>
        public static void Update(PhieuNhap pn)
        {
            var pnCu = Select(pn.MaPN);

            pnCu.MaPN = pn.MaPN;
            pnCu.ThoiDiemNhap = pn.ThoiDiemNhap;
            pnCu.GhiChu = pn.GhiChu;
            pnCu.MaNV = pn.MaNV;

            Database.SubmitChanges();
        }


        /// <summary>
        /// Xoa phieu nhap theo ma phieu nhap 
        /// </summary>
        /// <param name="maPN">Ma phieu nhap can xoa</param>
        public static void Delete(string maPN)
        {
            var p = (from t in Database.PhieuNhaps
                     where t.MaPN == maPN
                     select t).Single();

            var ct = (from t in Database.ChiTietPhieuNhaps
                      where t.MaPN == maPN
                      select t);

            foreach(var i in ct)
            {
                ChiTietPhieuNhapBLL.Delete(p.MaPN);
            }

            Database.PhieuNhaps.DeleteOnSubmit(p);
            Database.SubmitChanges();
        }


        /// <summary>
        /// Tu dong tao ID cho phieu nhap moi 
        /// </summary>
        /// <returns></returns>
        public static string autoGenerateId()
        {
            string result = "PN";
            var temp = from p in GlobalSettings.Database.PhieuNhaps
                       where p.MaPN.StartsWith(result)
                       select p.MaPN;
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
