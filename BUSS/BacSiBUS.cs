using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Utility;
using DAL;
using System.Data;

namespace BUS
{
    public class BacSiBUS : IBacSiBUS
    {
        private readonly IBacSiDAL dal = new BacSiDAL();
        public IList<BacSi> getAll()
        {
            DataTable table = dal.getAll();
            IList<BacSi> list = new List<BacSi>();
            foreach (DataRow row in table.Rows)
            {
                BacSi bs = new BacSi();
                bs.MaBS = row.Field<int>(0);
                bs.TenBS = row.Field<string>(1);
                bs.ChuyenMon = row.Field<string>(2);
                bs.DiaChi = row.Field<string>(3);
                bs.SoDT = row.Field<string>(4);
                bs.MaTK = row.Field<string>(5);
                bs.NamKN = row.Field<string>(6);
                list.Add(bs);
            }
            return list;
        }
    }

    
}
