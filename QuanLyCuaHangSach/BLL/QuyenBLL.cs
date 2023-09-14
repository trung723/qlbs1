using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public static class QuyenBLL
    {

        /// <summary>
        /// Lay ra danh sach quyen
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from t in Database.Quyens
                    select t).ToList();
        }

        /// <summary>
        /// lay ra 1 quyen theo ma quyen
        /// </summary>
        /// <param name="maQuyen"></param>
        /// <returns></returns>
        public static Quyen Select(string maQuyen)
        {
            return (from t in Database.Quyens
                    where t.MaQuyen == maQuyen
                    select t).Single();
        }
    }
}
