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
    public class TaiKhoanDAL : ITaiKhoanDAL
    {
        private const string PARM_MA_TK = "@maTK";
        private const string PARM_TEN_TK = "@tenTK";
        private const string PARM_MAT_KHAU = "@matKhau";
        private const string PARM_ROLE = "@quyen";




        public int CheckTaiKhoan_ID(string maTK)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(PARM_MA_TK, SqlDbType.VarChar, 10)
            };
            parameters[0].Value = maTK;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "TaiKhoan_Check", parameters);
        }

        public DataTable GetAll()
        {
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "proc_tai_khoan_get_all", null);

            DataTable table = new DataTable();
            table.Columns.Add("maTK", typeof(string));
            table.Columns.Add("tenTK", typeof(string));
            table.Columns.Add("matKhau", typeof(string));
            table.Columns.Add("quyen", typeof(string));

            while (dataReader.Read())
            {
                table.Rows.Add(dataReader["ma_tai_khoan"].ToString(), dataReader["ten_dang_nhap"].ToString(), dataReader["mat_khau"].ToString(), dataReader["quyen"].ToString());
            }

            dataReader.Dispose();
            return table;
        }
        public int Insert(string maTK, string tenTK, string matKhau, string quyen)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MA_TK, SqlDbType.VarChar, 10),
                new SqlParameter(PARM_TEN_TK, SqlDbType.NVarChar, 50),
                new SqlParameter(PARM_MAT_KHAU, SqlDbType.NVarChar, 50),
                new SqlParameter(PARM_ROLE, SqlDbType.NChar, 10),
            };
            parm[0].Value = maTK;
            parm[1].Value = tenTK;
            parm[2].Value = matKhau;
            parm[3].Value = quyen;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "them_tai_khoan", parm);
        }

        public int Delete(string maTK)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MA_TK, SqlDbType.VarChar, 10)
            };
            parm[0].Value = maTK;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "xoa_tai_khoan", parm);
        }



        public int Update(string maTK, string tenTK, string matKhau, string quyen)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MA_TK, SqlDbType.VarChar, 10),
                new SqlParameter(PARM_TEN_TK, SqlDbType.VarChar, 50),
                new SqlParameter(PARM_MAT_KHAU, SqlDbType.VarChar, 50),
                new SqlParameter(PARM_ROLE, SqlDbType.NChar, 10),
            };
            parm[0].Value = maTK;
            parm[1].Value = tenTK;
            parm[2].Value = matKhau;
            parm[3].Value = quyen;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sua_tai_khoan", parm);
        }


        public bool CheckLogin(string username, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = username },
                new SqlParameter("@Password", SqlDbType.NVarChar, 50) { Value = password }
            };

            int count = (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Check_Login", parameters);

            return count > 0;
        }

        public string GetQuyen(string dangnhap, string matkhau)
        {
            string quyen = "";      
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@dangnhap", dangnhap),
                    new SqlParameter("@matkhau", matkhau)
                };

                SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "GetQuyen", parameters);

                if (dataReader.Read())
                {
                    quyen = dataReader["quyen"].ToString();
                }

                dataReader.Close();
            
            return quyen;
        }


        public string GetAllTaiKhoan_ID()
        {
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "proc_tai_khoan_get_all_id", null); 
            string allTaiKhoan_ID = "";

            while (dataReader.Read())
            {
                allTaiKhoan_ID += dataReader["ma_tai_khoan"].ToString() + " ";
            }

            dataReader.Dispose();
            return allTaiKhoan_ID;
        }


        public IList<TaiKhoan> GetAllTaiKhoanID()
        {
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "proc_tai_khoan_get_all_id", null);

            IList<TaiKhoan> taiKhoans = new List<TaiKhoan>();

            while (dataReader.Read())
            {
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.MaTK = dataReader["ma_tai_khoan"].ToString();
                taiKhoans.Add(taiKhoan);
            }

            dataReader.Dispose();
            return taiKhoans;
        }



        public string GetTenTK(string maTaiKhoan)
        {
            string tenTaiKhoan = string.Empty;
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("@maTK", maTaiKhoan)
            };

            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "proc_tai_khoan_get_ten", parameters);

            if (dataReader.Read())
            {
                tenTaiKhoan = dataReader["ten_dang_nhap"].ToString();
            }

            dataReader.Dispose();
            return tenTaiKhoan;
        }


    }
}
    