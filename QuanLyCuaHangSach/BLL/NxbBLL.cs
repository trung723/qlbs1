using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using static BLL.GlobalSettings;

namespace BLL
{
    public static class NxbBLL
    {
        /// <summary>
        /// Lay ra tat ca NXB
        /// </summary>
        /// <returns></returns>
        public static object SelectALL()
        {
            return (from t in Database.LoaiSaches
                    select t).ToList();
        }
    }
}
