using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BacSi
    {
        protected int maBS;
        protected string tenBS;
        protected string chuyenMon;
        protected string diaChi;
        protected string soDT;
        protected string maTK;
        protected string namKN;

        public BacSi()
        {
        }

        public BacSi(int maBS, string tenBS, string chuyenMon, string diaChi, string soDT, string maTK, string namKN)
        {
            this.maBS = maBS;
            this.tenBS = tenBS;
            this.chuyenMon = chuyenMon;
            this.diaChi = diaChi;
            this.soDT = soDT;
            this.maTK = maTK;
            this.namKN = namKN;
        }

        public int MaBS
        {
            get { return maBS; }
            set { maBS = value; }
        }

        public string TenBS
        {
            get { return tenBS; }
            set { tenBS = value; }
        }

        public string ChuyenMon
        {
            get { return chuyenMon; }
            set { chuyenMon = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string SoDT
        {
            get { return soDT; }
            set { soDT = value; }
        }

        public string MaTK
        {
            get { return maTK; }
            set { maTK = value; }
        }

        public string NamKN
        {
            get { return namKN; }
            set { namKN = value; }
        }
    }
}
