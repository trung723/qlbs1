using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public static class TheLoaiBLL
    {
        /// <summary>
        /// Lay ra tat ca the loai
        /// </summary>
        /// <returns></returns>
        public static object SelectALL()
        {
            return (from t in Database.LoaiSaches
                    select t).ToList();
        }
        
        /// <summary>
        /// Lay ra the loai theo ten hoac ma loai
        /// </summary>
        /// <param name="search">Ten loai hoac ma loai</param>
        /// <returns></returns>
        public static object SelectALL(string search, int cachTim)
        {
            //return (from t in GlobalSettings.Database.LoaiSaches
            //        where t.MaLoai.Contains(search) || t.TenLoai.Contains(search)
            //        select new
            //        {
            //           t.MaLoai,
            //           t.TenLoai,
            //        }).ToList();
            return (from t in GlobalSettings.Database.LoaiSaches
                    where (cachTim == 0 ? t.MaLoai.Contains(search) : true) &&
                          (cachTim == 1 ? t.TenLoai.Contains(search) : true)
                    select new
                    {
                        t.MaLoai,
                        t.TenLoai,
                    }).ToList();
        }
        /// <summary>
        /// Lay ra loai sach theo ma loai
        /// </summary>
        /// <param name="maLoai">Ma cua loai sach can lay ra</param>
        /// <returns></returns>
        public static LoaiSach Select(string maLoai)
        {
            return (from t in Database.LoaiSaches
                    where t.MaLoai == maLoai
                    select t).Single();
        }

        /// <summary>
        /// Lay ra ten loai sach theo ma loai
        /// </summary>
        /// <param name="maLoai">ma loai sach</param>
        /// <returns></returns>
        public static string SelectTenLoai(string maLoai)
        {
            return (from t in Database.LoaiSaches
                    where t.MaLoai == maLoai
                    select t.TenLoai).Single();
        }

        /// <summary>
        /// Them 1 loai sach moi
        /// </summary>
        /// <param name="ls">Loai sach can them</param>
        public static void Insert(LoaiSach ls)
        {
            Database.LoaiSaches.InsertOnSubmit(ls);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Thay doi thong tin cua 1 loai sach 
        /// </summary>
        /// <param name="ls">Loai sach can thay doi</param>
        public static void Update(LoaiSach ls)
        {
            var loaiSachCu = Select(ls.MaLoai);

            loaiSachCu.TenLoai = ls.TenLoai;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Xoa 1 the loai sach
        /// </summary>
        /// <param name="maLoai">Ma cua loai sach can xoa</param>
        public static void Delete(string maLoai)
        {
            var l = (from t in Database.LoaiSaches
                     where t.MaLoai == maLoai
                     select t).Single();
            //Xoa bang sach
            var s = (from t in Database.Saches
                     where t.MaLoai == maLoai
                     select t);
            foreach(var i in s)
            {
                SachBLL.Delete(i.MaSach);
            }

            //Database.Saches.DeleteAllOnSubmit(s);
            //xoa cac bang co lien quan............


            Database.LoaiSaches.DeleteOnSubmit(l);
            Database.SubmitChanges();
        }

        public static string autoGenerateId()
        {
            string result = "LS";
            var temp = from p in GlobalSettings.Database.LoaiSaches
                       where p.MaLoai.StartsWith(result)
                       select p.MaLoai;
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
