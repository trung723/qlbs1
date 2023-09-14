using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public struct ReportPhieuNhap
    {
        public string MaPN { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public double GiaNhap { get; set; }
        public int SoLuongNhap { get; set; }
        public double TongTien { get; set; }
    }

    public class ChiTietPhieuNhapBLL
    {
        public static IQueryable<ReportPhieuNhap> SelectReport(string maPN)
        {
            return (from t in Database.ChiTietPhieuNhaps
                    where t.MaPN == maPN
                    select new ReportPhieuNhap
                    {
                        MaPN = t.MaPN,
                        MaSach = t.MaSach,
                        TenSach = t.Sach.TenSach,
                        GiaNhap = t.GiaNhap,
                        SoLuongNhap = t.SoLuongNhap,
                        TongTien = t.TongTien,
                    });
        }

        /// <summary>
        /// Lay ra tat ca chi tiet phieu nhap theo maPN
        /// </summary>
        /// <param name="maPN">Ma phieu nhap can lay</param>
        /// <returns></returns>
        public static object SelectAll(string maPN)
        {
            return (from t in Database.ChiTietPhieuNhaps
                    where t.MaPN == maPN
                    select new
                    {
                        t.MaPN,
                        t.MaSach,
                        t.Sach.TenSach,
                        t.GiaNhap,
                        t.SoLuongNhap,
                        t.TongTien,
                    }).ToList();
        }

        /// <summary>
        /// Lay ra chi tiet phieu nhap theo ma phieu nhap va ma sach
        /// </summary>
        /// <param name="maPN">Ma phieu</param>
        /// <param name="maSach">Ma sach</param>
        /// <returns></returns>
        public static ChiTietPhieuNhap SelectSub(string maPN, string maSach)
        {
            return (from t in Database.ChiTietPhieuNhaps
                    where t.MaPN == maPN && t.MaSach == maSach
                    select t).SingleOrDefault();
        }

        /// <summary>
        /// Lay ra chi tiet phieu nhap theo ma phieu nhap load giao dien
        /// </summary>
        /// <returns></returns>
        public static ChiTietPhieuNhap Select(string maPN)
        {
            return (from t in Database.ChiTietPhieuNhaps
                    where t.MaPN == maPN
                    select t).Single();
        }


        /// <summary>
        /// Lay ra tong tien cua phieu nhap theo ma phieu nhap
        /// </summary>
        /// <param name="maPN">Ma phieu nhap can tinh tong tien</param>
        /// <returns></returns>
        public static double SelectTongTien(string maPN)
        {
            try
            {
                var a = (from t in Database.ChiTietPhieuNhaps
                         where t.MaPN == maPN
                         group t by t.MaPN into g
                         select g.Sum(c => c.TongTien)).Single();
                return a;
            }
            catch
            {
                //phieu nhap moi tao chua co chi tiet tra ve tong tien bang 0
                return 0;
            }
        }


        ///// <summary>
        ///// Tinh tong tien ban cua 1 sach voi gia nhap va so luong
        ///// </summary>
        ///// <param name="maPN"></param>
        ///// <param name="maSach"></param>
        ///// <returns></returns>
        //public static double SelectTongTienSub(string maPN, string maSach)
        //{
        //    return 0;
        //}

        /// <summary>
        /// Them mot chi tiet phieu nhap moi
        /// </summary>
        /// <param name="ctPN">Chi tiet phieu nhap moi</param>
        public static void Insert(ChiTietPhieuNhap ctPN)
        {
            SachBLL.UpdateSoLuongNhap(ctPN.MaSach, ctPN.SoLuongNhap);

            Database.ChiTietPhieuNhaps.InsertOnSubmit(ctPN);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Sua thong tin chi tiet phieu nhap 
        /// </summary>
        /// <param name="ctPN">Thong tin cua chi tiet phieu nhap sua</param>
        public static void Update(ChiTietPhieuNhap ctPN)
        {
            var ctPNCu = SelectSub(ctPN.MaPN, ctPN.MaSach);

            if(ctPNCu.SoLuongNhap == ctPN.SoLuongNhap)
            {
                ctPNCu.MaPN = ctPN.MaPN;
                ctPNCu.MaSach = ctPN.MaSach;
                ctPNCu.GiaNhap = ctPN.GiaNhap;
                ctPNCu.SoLuongNhap = ctPN.SoLuongNhap;
                ctPNCu.TongTien = ctPN.TongTien;
            }
            else
            {
                if (ctPN.SoLuongNhap > ctPNCu.SoLuongNhap)
                {
                    int sl = ctPN.SoLuongNhap - ctPNCu.SoLuongNhap;
                    SachBLL.UpdateSoLuongNhap(ctPNCu.MaSach, sl);
                }
                if (ctPN.SoLuongNhap < ctPNCu.SoLuongNhap)
                {
                    int sl = ctPNCu.SoLuongNhap - ctPN.SoLuongNhap;
                    SachBLL.UpdateSoLuongBan(ctPNCu.MaSach, sl);
                }
                ctPNCu.MaPN = ctPN.MaPN;
                ctPNCu.MaSach = ctPN.MaSach;
                ctPNCu.GiaNhap = ctPN.GiaNhap;
                ctPNCu.SoLuongNhap = ctPN.SoLuongNhap;
                ctPNCu.TongTien = ctPN.TongTien;
            }

            Database.SubmitChanges();
        }


        /// <summary>
        /// Xoa chi tiet phieu nhap theo ma phieu nhap va ma sach
        /// </summary>
        /// <param name="maPN">Ma phieu nhap</param>
        /// <param name="maSach">Ma sach</param>
        public static void Delete(string maPN, string maSach)
        {
            var ct = (from t in Database.ChiTietPhieuNhaps
                      where t.MaPN == maPN && t.MaSach == maSach
                      select t).Single();

            SachBLL.UpdateSoLuongBan(maSach, (SelectSub(maPN, maSach)).SoLuongNhap);
            Database.ChiTietPhieuNhaps.DeleteOnSubmit(ct);
            Database.SubmitChanges();
        }


        /// <summary>
        /// Xoa tat ca chi tiet phieu nhap theo ma PN
        /// </summary>
        /// <param name="maPN"></param>
        public static void Delete(string maPN)
        {
            var ct = (from t in Database.ChiTietPhieuNhaps
                      where t.MaPN == maPN 
                      select t);

            Database.ChiTietPhieuNhaps.DeleteAllOnSubmit(ct);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Xoa tat ca chi tiet phieu nhap theo maSach
        /// </summary>
        /// <param name="maSach">Ma sach can xoa</param>
        public static void DeleteSach(string maSach)
        {
            var ct = (from t in Database.ChiTietPhieuNhaps
                      where t.MaSach == maSach
                      select t);
            Database.ChiTietPhieuNhaps.DeleteAllOnSubmit(ct);
            Database.SubmitChanges();
        }
    }
}
