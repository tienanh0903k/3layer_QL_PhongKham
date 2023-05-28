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
    public  class ThuocDAL : IThuocDAL
    {
        private const string PARM_MATHUOC = "@maThuoc";
        private const string PARM_TEN_HUOC = "@tenThuoc";
        private const string PARM_SOLUONG = "@soLuong";
        private const string PARM_DONGIA = "@donGia";
        private const string PARM_DONVI = "@donVi";


        public DataTable GetAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "proc_thuoc_get_all", null);

            DataTable table = new DataTable();
            table.Columns.Add("maThuoc", typeof(int));
            table.Columns.Add("tenThuoc", typeof(string));
            table.Columns.Add("soLuong", typeof(int));
            table.Columns.Add("donGia", typeof(int));
            table.Columns.Add("cach_dung", typeof(string));
            table.Columns.Add("donVi", typeof(string));

            while (dra.Read())
            {
                table.Rows.Add(dra["ma_thuoc"].ToString(), dra["ten_thuoc"].ToString(), int.Parse(dra["so_luong"].ToString()), int.Parse(dra["don_gia"].ToString()), dra["cach_dung"].ToString(), dra["don_vi"].ToString());
            }
            dra.Dispose();
            return table;
        }

    }
}
