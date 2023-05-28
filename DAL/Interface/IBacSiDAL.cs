using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public interface IBacSiDAL
    {  
        DataTable getAll();
        int CheckBacSi_ID(int maBS, string tenBS, string chuyenMon, string diaChi, string soDT, string maTK, string namKN);
        //int Insert(BacSi bs);
    }
}
