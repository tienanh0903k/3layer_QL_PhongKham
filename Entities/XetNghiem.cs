using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class XetNghiem
    {
        protected int maXN;
        protected string tenXN;
        protected string ketQua;
        protected int maBN;
        protected int giaXN;


        public XetNghiem()
        {

        }

        public XetNghiem(int maXN, string tenXN, string ketQua, int maBN, int giaXN)
        {
            this.maXN = maXN;
            this.tenXN = tenXN;
            this.ketQua = ketQua;
            this.maBN = maBN;
            this.giaXN = giaXN;
        }


        public int MaXN
        {
            get { return maXN; }
            set { maXN = value; }
        }

        public string TenXN
        {
            get { return tenXN; }
            set { tenXN = value; }
        }

        public string KetQua
        {
            get { return ketQua; }
            set { ketQua = value; }
        }
        public int MaBN
        {
            get { return maBN; }
            set { maBN = value; }
        }

        public int GiaXN
        {
            get { return giaXN; }
            set { giaXN = value; }
        }    
    }


}


   



