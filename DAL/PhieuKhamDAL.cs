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
    public class PhieuKhamDAL : IPhieuKhamDAL
    {
        private const string PARM_MA_BS = "@maPK";
        public DataTable GetPhieuKhamInfo(int maPK)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maPK", SqlDbType.Int) { Value = maPK }
            };

            return SqlHelper.ExecuteDataTable(SqlHelper.ConnectionString, CommandType.StoredProcedure, "GetPhieuKhamInfo", parameters);
        }

        public IList<PhieuKham> GetAllPhieuKhamID()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "proc_phieu_kham_get_all_id", null);

            IList<PhieuKham> phieuKhams = new List<PhieuKham>();

            while (dra.Read())
            {
                PhieuKham phieuKham = new PhieuKham();
                phieuKham.MaPK = Convert.ToInt32(dra["ma_phieu_kham"]);
                phieuKhams.Add(phieuKham);
            }

            dra.Dispose();
            return phieuKhams;
        }
    }
}
