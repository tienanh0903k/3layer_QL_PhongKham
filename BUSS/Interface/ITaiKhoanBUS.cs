using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BUS
{
    public interface ITaiKhoanBUS
    {
        IList<TaiKhoan> getAll();
        int Insert(TaiKhoan tk);

        int Delete(string maTK);

        int Update(TaiKhoan tk);
        int CheckTaiKhoan_ID(string maTK);
        bool CheckLogin(string username, string password);
        string GetQuyen(string dangnhap, string matkhau);
        IList<TaiKhoan> GetAllTaiKhoanID();

        string GetTenTK(string maTK);

    }
}
