using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class LichKhamDAL : ILichKhamDAL
    {
        private const string PARM_MA_LK = "@maLK";
        private const string PARM_MA_BN = "@maBN";
        private const string PARM_MA_BACSI = "@maBS";
        private const string PARM_NGAYKHAM = "@ngayKham";
        private const string PARM_GIOKHAM = "@gioKham";

        public DataTable getAll()
        { 
            
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_GetLichKham", null);
            DataTable table = new DataTable();
            table.Columns.Add("maLK", typeof(int));
            table.Columns.Add("maBN", typeof(int));
            table.Columns.Add("tenBN", typeof(string));
            table.Columns.Add("maBS", typeof(int));
            table.Columns.Add("tenBS", typeof(string));
            table.Columns.Add("ngayKham", typeof(DateTime));
            table.Columns.Add("gioKham", typeof(string));

            while (reader.Read())
            {
                table.Rows.Add(
                    int.Parse(reader["ma_lich_kham"].ToString()),
                    int.Parse(reader["ma_benh_nhan"].ToString()),
                    reader["ten_benh_nhan"].ToString(),
                    int.Parse(reader["ma_bac_si"].ToString()),
                    reader["ten_bac_si"].ToString(),
                    DateTime.Parse(reader["ngay_kham"].ToString()),
                    reader["gio_kham"].ToString()
                );
            }
            reader.Dispose();
           return table;
        }



        public int Insert(int maLK, int maBN, int maBS, DateTime ngayKham, string gioKham)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MA_LK, SqlDbType.Int),
                new SqlParameter(PARM_MA_BN, SqlDbType.Int),
                new SqlParameter(PARM_MA_BACSI, SqlDbType.Int),
                new SqlParameter(PARM_NGAYKHAM, SqlDbType.DateTime, 10),
                new SqlParameter(PARM_GIOKHAM, SqlDbType.NVarChar, 100),
            };
            parm[0].Value = maLK;
            parm[1].Value = maBN;
            parm[2].Value = maBS;
            parm[3].Value = ngayKham;
            parm[4].Value = gioKham;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "them_lich_kham", parm);
        }

    }
}
