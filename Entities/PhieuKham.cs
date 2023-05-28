using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PhieuKham
    {
        protected int maPK;
        protected int maBN;
        protected int maXN;
        protected int maThuoc;
        protected int maBS;
        protected DateTime ngayLap;


        public PhieuKham()
        {

        }

        public PhieuKham(int maPK, int maBN, int maXN, int maThuoc, int maBS, DateTime ngayLap)
        {
            this.maPK = maPK;
            this.maBN = maBN;
            this.maXN = maXN;
            this.maThuoc = maThuoc;
            this.maBS = maBS;
            this.ngayLap = ngayLap;
        }


        public int MaPK
        {
            get { return maPK; }
            set { maPK = value; }
        }

        public int MaBN
        {
            get { return maBN; }
            set { maBN = value; }
        }

        public int MaXN
        {
            get { return maXN; }
            set { maXN = value; }
        }
        public int MaThuoc
        {
            get { return maThuoc; }
            set { maThuoc = value; }
        }

        public int MaBS
        {
            get { return maBS; }
            set { maBS = value; }
        }

        public DateTime NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
    }
}

