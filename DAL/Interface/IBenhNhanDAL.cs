using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public interface IBenhNhanDAL
    {
        DataTable getAll();
        int Insert(int maBN, string tenBN, DateTime ngaySinh, string gioiTinh, string diaChi, string soDT);
        int Delete(int maBN);
        int Update(int maBN, string tenBN, DateTime ngaySinh, string gioiTinh, string diaChi, string soDT);
        int checkBenhNhan_ID(int maBN);
        IList<BenhNhan> TimKiem(string tukhoa);
        DataTable getBenhNhan_ID(int maBN);
        DataTable GetXetNghiemByMaBenhNhan(int maBN);
    }
}
