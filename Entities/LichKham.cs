using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class LichKham
    {
        protected int maLK;
        protected int maBN;
        protected string tenBN;
        protected int maBS;
        protected string tenBS;
        protected DateTime ngayKham;
        protected string gioKham;

        public LichKham()
        {
        }

        public LichKham(int maLK, int maBN, string tenBN, int maBS, string tenBS, DateTime ngayKham, string gioKham)
        {
            this.maLK = maLK;
            this.maBN = maBN;
            this.tenBN = tenBN;
            this.maBS = maBS;
            this.tenBS = tenBS;
            this.ngayKham = ngayKham;
            this.gioKham = gioKham;
        }


        public LichKham(int maLK, int maBN,  int maBS,  DateTime ngayKham, string gioKham)
        {
            this.maLK = maLK;
            this.maBN = maBN; 
            this.maBS = maBS;            
            this.ngayKham = ngayKham;
            this.gioKham = gioKham;
        }



        public int MaLK
        {
            get { return maLK; }
            set { maLK = value; }
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

        public DateTime NgayKham
        {
            get { return ngayKham; }
            set { ngayKham = value; }
        }

        public string GioKham
        {
            get { return gioKham; }
            set { gioKham = value; }
        }
    }
}

