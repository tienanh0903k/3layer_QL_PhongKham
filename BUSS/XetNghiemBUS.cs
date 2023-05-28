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
    public class XetNghiemBUS : IXetNghiemBUS
    {
        private readonly IXetNghiemDAL dal = new XetNghiemDAL();

        public IList<XetNghiem> GetAll()
        {
            DataTable table = dal.GetAll();
            IList<XetNghiem> list = new List<XetNghiem>();
            foreach (DataRow row in table.Rows)
            {
                XetNghiem xn = new XetNghiem();
                xn.MaXN = row.Field<int>("maXN");
                xn.TenXN = row.Field<string>("tenXN");
                xn.KetQua = row.Field<string>("ketQua");
                xn.MaBN = row.Field<int>("maBN");
                xn.GiaXN = row.Field<int>("giaXN");
                list.Add(xn);
            }
            return list;
        }
    }
}
    