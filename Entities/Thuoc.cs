using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Thuoc
    {
        protected int maThuoc;
        protected string tenThuoc;
        protected int soLuong;
        protected int donGia;
        protected string cachDung;
        protected string donVi;

        public Thuoc()
        {
        }

        public Thuoc(int maThuoc, string tenThuoc, int soLuong, int donGia ,string cachDung, string donVi)
        {
            this.maThuoc = maThuoc;
            this.tenThuoc = tenThuoc;
            this.soLuong = soLuong;
            this.cachDung = cachDung;
            this.donVi = donVi;
            this.donGia = donGia;
        }

        public int MaThuoc
        {
            get { return maThuoc; }
            set { maThuoc = value; }
        }


        public string TenThuoc
        {
            get { return tenThuoc; }
            set { tenThuoc = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public string CachDung
        {
            get { return cachDung; }
            set { cachDung = value; }
        }

        public string DonVi
        {
            get { return donVi; }
            set { donVi = value; }
        }

        public int DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
    }
}

