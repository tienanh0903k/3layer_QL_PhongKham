using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class XetNghiemDAL : IXetNghiemDAL
    {
        private const string PARM_MA_BN = "@maBN";
        private const string PARM_TEN_BN = "@tenBN";
        private const string PARM_NGAYSINH = "@ngaySinh";
        private const string PARM_GIOITINH = "@gioiTinh";
        private const string PARM_DIACHI = "@diaChi";

        public DataTable GetAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "proc_xet_nghiem_get_all", null);

            DataTable table = new DataTable();
            table.Columns.Add("maXN", typeof(int));
            table.Columns.Add("tenXN", typeof(string));
            table.Columns.Add("ketQua", typeof(string));
            table.Columns.Add("maBN", typeof(int));
            table.Columns.Add("giaXN", typeof(int));
 
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["ma_xet_nghiem"].ToString()), dra["ten_xet_nghiem"].ToString(), dra["ket_qua"].ToString(), int.Parse(dra["ma_benh_nhan"].ToString()), int.Parse(dra["gia_xn"].ToString()));
            }
            dra.Dispose();
            return table;
        }

    }
}
