using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ITaiKhoanDAL
    {
        DataTable GetAll();
        int Insert(string maTK, string tenTK, string matKhau, string quyen);
        int Update(string maTK, string tenTK, string matKhau, string quyen);
        int Delete(string maTK);
        bool CheckLogin(string username, string password);
        int CheckTaiKhoan_ID(string maTK);
        string GetQuyen(string dangnhap, string matkhau);

        IList<TaiKhoan> GetAllTaiKhoanID();

        string GetTenTK(string maTK);

    }
}
