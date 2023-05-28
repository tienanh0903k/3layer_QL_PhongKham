using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BUS
{
    public interface IPhieuKhamBUS
    {
        IList<PhieuKham> GetAllPhieuKhamID();
        DataTable GetPhieuKhamInfo(int maPK);
    }
}
