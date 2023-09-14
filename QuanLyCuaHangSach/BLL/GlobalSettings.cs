using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
using BLL.Properties;

namespace BLL
{
    public static class GlobalSettings
    {
        public static QuanLyCuaHangSachDataContext Database { get; set; }

        public static string connectionString { get; set; }

        public static string userID { get; set; }

        public static string userName { get; set; }

        public static string userType { get; set; }

        public static string severName { get; set; }

        public static string severCatalog { get; set; }



        public static void ConnectToDB()
        {
            //lay thong tin de ket noi
            connectionString = Settings.Default.ConnectionString;
            severName = Settings.Default.DB_ServerName;
            severCatalog = Settings.Default.DB_ServerCatalog;

            Database = new QuanLyCuaHangSachDataContext(connectionString);

            //kiem tra ket noi 
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT 1", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Lay ra danh sach database co tren sever sql
        /// </summary>
        /// <param name="strcnn">Chuoi ket noi den sever</param>
        /// <returns></returns>
        public static List<string> GetDatabaseList(string strcnn)
        {
            List<string> listDatabase = new List<string>();

            using (SqlConnection cnn = new SqlConnection(strcnn))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_databases", cnn))
                using (IDataReader dr = cmd.ExecuteReader())
                    while (dr.Read())
                        listDatabase.Add(dr[0].ToString());
            }

            return listDatabase;
        }

        /// <summary>
        /// Luu lai ket noi den csdl
        /// </summary>
        public static void SaveDatabaseConnection()
        {
            Settings.Default.ConnectionString = connectionString;
            Settings.Default.DB_ServerName = severName;
            Settings.Default.DB_ServerCatalog = severCatalog;

            Settings.Default.Save();
        }

    }
}
