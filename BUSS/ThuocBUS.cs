using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;


namespace BUS
{
    public class ThuocBUS : IThuocBUS
    {
        private readonly IThuocDAL dal = new ThuocDAL();
        public IList<Thuoc> GetAll()
        {
            DataTable table = dal.GetAll();
            IList<Thuoc> list = new List<Thuoc>();
            foreach (DataRow row in table.Rows)
            {
                Thuoc t = new Thuoc();
                t.MaThuoc = row.Field<int>(0);
                t.TenThuoc = row.Field<string>(1);
                t.SoLuong = row.Field<int>(2);
                t.DonGia = row.Field<int>(3);
                t.DonVi = row.Field<string>(4);
                t.CachDung = row.Field<string>(5);
                list.Add(t);
            }
            return list;
        }
    }
}
