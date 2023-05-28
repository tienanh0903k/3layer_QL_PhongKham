using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using Utility;


namespace BUS
{
    public class LichKhamBUS : ILichKhamBUS
    {
        private readonly ILichKhamDAL dal = new LichKhamDAL();

        public IList<LichKham> getAll()
        {
            DataTable table = dal.getAll();
            IList<LichKham> list = new List<LichKham>();
            foreach (DataRow row in table.Rows)
            {
                LichKham cls = new LichKham();
                cls.MaLK = row.Field<int>("maLK");
                cls.MaBN = row.Field<int>("maBN");
                cls.TenBN = row.Field<string>("tenBN");
                cls.MaBS = row.Field<int>("maBS");
                cls.TenBS = row.Field<string>("tenBS");
                cls.NgayKham = row.Field<DateTime>("ngayKham");
                cls.GioKham = row.Field<string>("gioKham");
                list.Add(cls);
            }
            return list;
        }


        public int Insert(LichKham lk)
        {
            return dal.Insert(lk.MaLK, lk.MaBN, lk.MaBS, lk.NgayKham, lk.GioKham);
            
        }





    }
}
