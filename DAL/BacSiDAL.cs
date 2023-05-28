using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class BacSiDAL : IBacSiDAL 
    {
        private const string PARM_MA_BS = "@maBS";
        private const string PARM_TEN_BS = "@tenBS";
        private const string PARM_CHUYEN_MON = "@chuyenMon";
        private const string PARM_DIACHI = "@diaChi";
        private const string PARM_SDT = "@soDT";
        private const string PARM_MATK = "@maTK";
        private const string PARM_NAMKN = "@namKN";

        public DataTable getAll()
        {
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "proc_bacsi_get_all", null);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("maBS", typeof(int));
            dataTable.Columns.Add("tenBS", typeof(string));
            dataTable.Columns.Add("chuyenMon", typeof(string));
            dataTable.Columns.Add("diaChi", typeof(string));
            dataTable.Columns.Add("soDT", typeof(string));
            dataTable.Columns.Add("maTK", typeof(string));
            dataTable.Columns.Add("namKN", typeof(string));

            while (dataReader.Read())
            {
                dataTable.Rows.Add(
                    int.Parse(dataReader["ma_bac_si"].ToString()),
                    dataReader["ten_bac_si"].ToString(),
                    dataReader["chuyen_mon"].ToString(),
                    dataReader["dia_chi"].ToString(),
                    dataReader["so_dien_thoai"].ToString(),
                    dataReader["ma_tai_khoan"].ToString(),
                    dataReader["nam_kn"].ToString()
                );
            }

            dataReader.Dispose();
            return dataTable;
        }

        

    }
}
