using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BUS
{
    public interface IBenhNhanBUS
    {
        IList<BenhNhan> getAll();
        int Insert(BenhNhan bn);
        int Delete(int maBN);
        int Update(BenhNhan bn);
        int checkBenhNhan_ID(int maBN);
        IList<BenhNhan> TimKiem(string tukhoa);
        void KetXuatWord(string templatePath, string exportPath);
        BenhNhan getBenhNhan_ID(int maBN);
        DataTable GetXetNghiemByMaBenhNhan(int maBN);
       

    }
}
