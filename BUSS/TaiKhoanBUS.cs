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
    public class TaiKhoanBUS : ITaiKhoanBUS
    {
        private readonly ITaiKhoanDAL dal = new TaiKhoanDAL();

        public int CheckTaiKhoan_ID(string maTK)
        {
            return dal.CheckTaiKhoan_ID(maTK);
        }

        public IList<TaiKhoan> getAll()
        {
            DataTable table = dal.GetAll();
            IList<TaiKhoan> list = new List<TaiKhoan>();
            foreach (DataRow row in table.Rows)
            {
                TaiKhoan tk = new TaiKhoan();
                tk.MaTK = row.Field<string>("maTK");
                tk.TenTK = row.Field<string>("tenTK");
                tk.MatKhau = row.Field<string>("matKhau");
                tk.Quyen = row.Field<string>("quyen");
                list.Add(tk);
            }
            return list;
        }
        


        public int Insert(TaiKhoan tk)
        {
            if (CheckTaiKhoan_ID(tk.MaTK) == 0)
                return dal.Insert(tk.MaTK, tk.TenTK, tk.MatKhau, tk.Quyen);
            else
                return -1;
        }


        public int Delete(string maTK)
        {
            if (CheckTaiKhoan_ID(maTK) != 0)
                return dal.Delete(maTK);
            else return -1;
        }


        public int Update(TaiKhoan tk)
        {
            if (CheckTaiKhoan_ID(tk.MaTK) != 0)
                return dal.Update(tk.MaTK, tk.TenTK, tk.MatKhau, tk.Quyen);
            else return -1;
        }


        public bool CheckLogin(string username, string password)
        {
            bool result = dal.CheckLogin(username, password);
            return result;
        }


        public string GetQuyen(string dangnhap, string matkhau)
        {
            return dal.GetQuyen(dangnhap, matkhau);
        }


        public IList<TaiKhoan> GetAllTaiKhoanID()
        {
            return dal.GetAllTaiKhoanID();
        }

        public string GetTenTK(string maTK)
        {
            return dal.GetTenTK(maTK);
        }


    }
}
