using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ILichKhamDAL
    {
        DataTable getAll();
        int Insert(int maLK, int maBN, int maBS, DateTime ngayKham, string gioKham);

    }
}
