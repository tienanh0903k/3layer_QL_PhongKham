using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Data;

namespace BUS
{
    public class PhieuKhamBUS : IPhieuKhamBUS
    {
        private readonly IPhieuKhamDAL dal = new PhieuKhamDAL();
        public IList<PhieuKham> GetAllPhieuKhamID()
        {
            return dal.GetAllPhieuKhamID();
        }

        public DataTable GetPhieuKhamInfo(int maPK)
        {
            return dal.GetPhieuKhamInfo(maPK);
        }
    }
}
