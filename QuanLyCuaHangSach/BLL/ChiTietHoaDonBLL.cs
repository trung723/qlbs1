using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public static class ChiTietHoaDonBLL
    {

        public struct ReportHoaDon
        {
            public string MaHD { get; set; }
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public double GiaBan { get; set; }
            public int SoLuong { get; set; }
            public double TongTien { get; set; }
        }

        public static IQueryable<ReportHoaDon> SelectReport(string maHD)
        {
            return (from t in Database.ChiTietHoaDons
                    where t.MaHD == maHD
                    select new ReportHoaDon
                    {
                        MaHD = t.MaHD,
                        MaSach = t.MaSach,
                        TenSach = t.Sach.TenSach,
                        GiaBan = t.GiaBan,
                        SoLuong = t.SoLuongBan,
                        TongTien = t.TongTien,
                    });
        }
        public static object SelectAll(string maHD)
        {
            return (from t in Database.ChiTietHoaDons
                    where t.MaHD == maHD
                    select new
                    {
                        t.MaHD,
                        t.MaSach,
                        t.Sach.TenSach,
                        t.GiaBan,
                        t.SoLuongBan,
                        t.TongTien,
                    }).ToList();
        }

        public static ChiTietHoaDon SelectSub(string maHD, string maSach)
        {
            return (from t in Database.ChiTietHoaDons
                    where t.MaHD == maHD && t.MaSach == maSach
                    select t).SingleOrDefault();
        }

        public static ChiTietHoaDon Select(string maHD)
        {
            return (from t in Database.ChiTietHoaDons
                    where t.MaHD == maHD
                    select t).Single();
        }

        /// <summary>
        /// Lay ra tong tien cua hoa don theo ma hoa don
        /// </summary>
        /// <param name="maHD">Ma hoa don can tinh tong tien</param>
        /// <returns></returns>
        public static double SelectTongTien(string maHD)
        {
            try
            {
                var a = (from t in Database.ChiTietHoaDons
                         where t.MaHD == maHD
                         group t by t.MaHD into g
                         select g.Sum(c => c.TongTien)).Single();
                return a;
            }
            catch
            {
                return 0;
            }
        }

        public static void Insert(ChiTietHoaDon ctHD)
        {
            SachBLL.UpdateSoLuongBan(ctHD.MaSach, ctHD.SoLuongBan);

            Database.ChiTietHoaDons.InsertOnSubmit(ctHD);
            Database.SubmitChanges();
        }

        public static void Update(ChiTietHoaDon ctHD)
        {
            var ctHDCu = SelectSub(ctHD.MaHD, ctHD.MaSach);

            if(ctHDCu.SoLuongBan == ctHD.SoLuongBan)
            {
                ctHDCu.MaHD = ctHD.MaHD;
                ctHDCu.MaSach = ctHD.MaSach;
                ctHDCu.GiaBan = ctHD.GiaBan;
                ctHDCu.SoLuongBan = ctHD.SoLuongBan;
                ctHDCu.TongTien = ctHD.TongTien;
            }
            else
            {
                //Neu update lai ma so luong ban tang thi lay ra so luong tang do va tru di trong kho
                if (ctHD.SoLuongBan > ctHDCu.SoLuongBan)
                {
                    int sl = ctHD.SoLuongBan - ctHDCu.SoLuongBan;
                    SachBLL.UpdateSoLuongBan(ctHDCu.MaSach, sl);
                }
                //Neu update lai ma so luong ban giam thi lay ra so luong giam do va cong lai vao kho
                if (ctHD.SoLuongBan < ctHDCu.SoLuongBan)
                {
                    int sl = ctHDCu.SoLuongBan - ctHD.SoLuongBan;
                    SachBLL.UpdateSoLuongNhap(ctHDCu.MaSach, sl);
                }
                ctHDCu.MaHD = ctHD.MaHD;
                ctHDCu.MaSach = ctHD.MaSach;
                ctHDCu.GiaBan = ctHD.GiaBan;
                ctHDCu.SoLuongBan = ctHD.SoLuongBan;
                ctHDCu.TongTien = ctHD.TongTien;
                
            }

            Database.SubmitChanges();
        }



        public static void Delete(string maHD, string maSach)
        {
            var ct = (from t in Database.ChiTietHoaDons
                      where t.MaHD == maHD && t.MaSach == maSach
                      select t).Single();

            SachBLL.UpdateSoLuongNhap(maSach, (SelectSub(maHD, maSach)).SoLuongBan);

            Database.ChiTietHoaDons.DeleteOnSubmit(ct);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Xoa tat ca ctHD dua theo ma hoa don
        /// </summary>
        /// <param name="maHD"></param>
        public static void Delete(string maHD)
        {
            var ct = (from t in Database.ChiTietHoaDons
                      where t.MaHD == maHD
                      select t);

            Database.ChiTietHoaDons.DeleteAllOnSubmit(ct);
            Database.SubmitChanges();
        }

        
        /// <summary>
        /// Xoa chi tiet hoa don theo ma sach
        /// </summary>
        /// <param name="maSach">ma sach can xoa</param>
        public static void DeleteSach(string maSach)
        {
            var ct = (from t in Database.ChiTietHoaDons
                      where t.MaSach == maSach
                      select t);
            Database.ChiTietHoaDons.DeleteAllOnSubmit(ct);
            Database.SubmitChanges();
        }
    }
}
