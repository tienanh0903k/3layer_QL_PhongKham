using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BUS
{
    public interface ILichKhamBUS
    {
        IList<LichKham> getAll();
        int Insert(LichKham lk);
    }
}
