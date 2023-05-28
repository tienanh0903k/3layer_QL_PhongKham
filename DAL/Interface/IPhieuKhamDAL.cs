using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public interface IPhieuKhamDAL
    {
        IList<PhieuKham> GetAllPhieuKhamID();
        DataTable GetPhieuKhamInfo(int maPK);
    }
}
