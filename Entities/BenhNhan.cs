using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BenhNhan
    {
        protected int maBN;
        protected string tenBN;
        protected DateTime ngaysinh;
        protected string gioitinh;
        protected string diachi;
        protected string soDT;

        public BenhNhan()
        {
        }

        public BenhNhan(string tenBN, DateTime ngaysinh, string gioitinh, string diachi, string soDT, int maBN)
        {
            this.ngaysinh = ngaysinh;
            this.diachi = diachi;
            this.soDT = soDT;
            this.maBN = maBN;
            this.gioitinh = gioitinh;
            this.tenBN = tenBN; 
        }


        public BenhNhan(string tenBN, DateTime ngaysinh, string gioitinh, string diachi, string soDT)
        {
            this.ngaysinh = ngaysinh;
            this.diachi = diachi;
            this.soDT = soDT;
            this.gioitinh = gioitinh;
            this.tenBN = tenBN;
        }


        public int MaBN
        {
            get { return maBN; }
            set { maBN = value; }
        }

        public string TenBN
        {
            get { return tenBN; }
            set { tenBN = value; }
        }

        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        public string Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public string SoDT
        {
            get { return soDT; }
            set { soDT = value; }
        }
    }


}
