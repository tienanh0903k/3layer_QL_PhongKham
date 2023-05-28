using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BenhNhanDAL : IBenhNhanDAL
    {
        private const string PARM_MA_BN = "@maBN";
        private const string PARM_TEN_BN = "@tenBN";
        private const string PARM_NGAYSINH = "@ngaySinh";
        private const string PARM_GIOITINH = "@gioiTinh";
        private const string PARM_DIACHI = "@diaChi";
        private const string PARM_SODT = "@soDT";
        private const string PARM_TUKHOA = "@tukhoa";

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "proc_benh_nhan_get_all", null);
            DataTable table = new DataTable();
            table.Columns.Add("maBN", typeof(int));
            table.Columns.Add("tenBN", typeof(string));
            table.Columns.Add("ngaySinh", typeof(DateTime));
            table.Columns.Add("gioiTinh", typeof(string));
            table.Columns.Add("diaChi", typeof(string));
            table.Columns.Add("soDT", typeof(string));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["ma_benh_nhan"].ToString()), dra["ten_benh_nhan"].ToString(), DateTime.Parse(dra["ngay_sinh"].ToString()), dra["gioi_tinh"].ToString(), dra["dia_chi"].ToString(), dra["so_dien_thoai"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public int Insert(int maBN, string tenBN, DateTime ngaySinh, string gioiTinh, string diaChi, string soDT)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MA_BN, SqlDbType.Int),
                new SqlParameter(PARM_TEN_BN, SqlDbType.NVarChar, 50),
                new SqlParameter(PARM_NGAYSINH, SqlDbType.DateTime),
                new SqlParameter(PARM_GIOITINH, SqlDbType.NVarChar, 10),
                new SqlParameter(PARM_DIACHI, SqlDbType.NVarChar, 100),
                new SqlParameter(PARM_SODT, SqlDbType.NVarChar, 20)
            };
            parm[0].Value = maBN;
            parm[1].Value = tenBN;
            parm[2].Value = ngaySinh;
            parm[3].Value = gioiTinh;
            parm[4].Value = diaChi;
            parm[5].Value = soDT;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "them_benh_nhan", parm);
        }


        public int Update(int maBN, string tenBN, DateTime ngaySinh, string gioiTinh, string diaChi, string soDT)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MA_BN, SqlDbType.Int),
                new SqlParameter(PARM_TEN_BN, SqlDbType.NVarChar, 50),
                new SqlParameter(PARM_NGAYSINH, SqlDbType.DateTime),
                new SqlParameter(PARM_GIOITINH, SqlDbType.NVarChar, 10),
                new SqlParameter(PARM_DIACHI, SqlDbType.NVarChar, 100),
                new SqlParameter(PARM_SODT, SqlDbType.NVarChar, 20)
            };
            parm[0].Value = maBN;
            parm[1].Value = tenBN;
            parm[2].Value = ngaySinh;
            parm[3].Value = gioiTinh;
            parm[4].Value = diaChi;
            parm[5].Value = soDT;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sua_benh_nhan", parm);
        }


        public int Delete(int maBN)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MA_BN,SqlDbType.Int)
            };
            parm[0].Value = maBN;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "xoa_benh_nhan", parm);
        }   

        public int checkBenhNhan_ID(int maBN)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MA_BN,SqlDbType.Int)
            };
            parm[0].Value = maBN;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Patient_Check", parm);
        }


        public IList<BenhNhan> TimKiem(string tukhoa)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@keyword", SqlDbType.VarChar, 100) { Value = tukhoa }
            };

            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TimBenhNhan", parameters);

            IList<BenhNhan> danhSachBenhNhan = new List<BenhNhan>();

            while (dataReader.Read())
            {
                BenhNhan benhNhan = new BenhNhan();
                benhNhan.MaBN = int.Parse(dataReader["ma_benh_nhan"].ToString());
                benhNhan.TenBN = dataReader["ten_benh_nhan"].ToString();
                benhNhan.Ngaysinh = Convert.ToDateTime(dataReader["ngay_sinh"].ToString());
                benhNhan.Gioitinh = dataReader["gioi_tinh"].ToString();
                benhNhan.Diachi = dataReader["dia_chi"].ToString();
                benhNhan.SoDT = dataReader["so_dien_thoai"].ToString();

                danhSachBenhNhan.Add(benhNhan);
            }

            dataReader.Dispose();
            return danhSachBenhNhan;
        }

        public DataTable getBenhNhan_ID(int maBN)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MA_BN,SqlDbType.Int)
            };
            parm[0].Value = maBN;
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "tbl_Classes_Sel_ID", parm);
            DataTable table = new DataTable();
            table.Columns.Add("maBN", typeof(int));
            table.Columns.Add("tenBN", typeof(string));
            table.Columns.Add("ngaySinh", typeof(DateTime));
            table.Columns.Add("gioiTinh", typeof(string));
            table.Columns.Add("diaChi", typeof(string));
            table.Columns.Add("soDT", typeof(string));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["ma_benh_nhan"].ToString()), dra["ten_benh_nhan"].ToString(), DateTime.Parse(dra["ngay_sinh"].ToString()), dra["gioi_tinh"].ToString(), dra["dia_chi"].ToString(), dra["so_dien_thoai"].ToString());
            }
            dra.Dispose();
            return table;
        }


        public DataTable GetXetNghiemByMaBenhNhan(int maBN)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maBN", maBN)
            };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "getXNmaBN", parameters))
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }



    }
}

