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
    public class BenhNhanBUS : IBenhNhanBUS
    {
        private readonly IBenhNhanDAL dal = new BenhNhanDAL();

        public int Insert(BenhNhan bn)
        {
            if (checkBenhNhan_ID(bn.MaBN) == 0)
                return dal.Insert(bn.MaBN, bn.TenBN, bn.Ngaysinh, bn.Gioitinh, bn.Diachi, bn.SoDT);
            else return -1;
        }

        public int Update(BenhNhan bn)
        {
            if (checkBenhNhan_ID(bn.MaBN) != 0)
                return dal.Update(bn.MaBN, bn.TenBN, bn.Ngaysinh, bn.Gioitinh, bn.Diachi, bn.SoDT);
            else return -1;
        }

        public IList<BenhNhan> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<BenhNhan> list = new List<BenhNhan>();
            foreach (DataRow row in table.Rows)
            {
                BenhNhan bn = new BenhNhan();
                bn.MaBN = row.Field<int>(0);
                bn.TenBN = row.Field<string>(1);
                bn.Ngaysinh = row.Field<DateTime>(2);
                bn.Gioitinh = row.Field<string>(3);
                bn.Diachi = row.Field<string>(4);
                bn.SoDT = row.Field<string>(5);
                list.Add(bn);
            }
            return list;
        }




        public int Delete(int maBN)
        {
            if (checkBenhNhan_ID(maBN) != 0)
                return dal.Delete(maBN);
            else return -1;
        }


        public int checkBenhNhan_ID(int maBN)
        {
            return dal.checkBenhNhan_ID(maBN);
        }

        public IList<BenhNhan> TimKiem(string tukhoa)
        {
            return dal.TimKiem(tukhoa);
            
        }

        public BenhNhan getBenhNhan_ID(int maBN)
        {
            System.Data.DataTable table = dal.getBenhNhan_ID(maBN);
            if (checkBenhNhan_ID(maBN) != 0)
            {
                BenhNhan bn = new BenhNhan();
                bn.MaBN = table.Rows[0].Field<int>(0);
                bn.TenBN = table.Rows[0].Field<string>(1);
                bn.Ngaysinh = table.Rows[0].Field<DateTime>(2);
                bn.Diachi = table.Rows[0].Field<string>(3);
                bn.SoDT = table.Rows[0].Field<string>(4);
                bn.Gioitinh = table.Rows[0].Field<string>(5);
                return bn;
            }
            else return null;
        }

        public void KetXuatWord(string templatePath, string exportPath)
        {   

            IBenhNhanBUS bn = new BenhNhanBUS();
            IList<BenhNhan> listData = bn.getAll();
            IBacSiBUS bs = new BacSiBUS();
            Dictionary<string, string> dictionaryData = new Dictionary<string, string>();
            System.IO.File.Copy(templatePath, exportPath, true);
            ExportDocx.CreateClassTemplate(exportPath, dictionaryData, listData);
        }

        public DataTable GetXetNghiemByMaBenhNhan(int maBN)
        {
            return dal.GetXetNghiemByMaBenhNhan(maBN);
        }



    }

    
}
