using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaiKhoan
    {
        protected string maTK;
        protected string tenTK;
        protected string matKhau;
        protected string quyen;

        public TaiKhoan()
        {
        }

        public TaiKhoan(string maTK, string tenTK, string matKhau, string quyen)
        {
            this.maTK = maTK;
            this.tenTK = tenTK;
            this.matKhau = matKhau;
            this.quyen = quyen;
        }

        public string MaTK
        {
            get { return maTK; }
            set { maTK = value; }
        }

        public string TenTK
        {
            get { return tenTK; }
            set { tenTK = value; }
        }

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        public string Quyen
        {
            get { return quyen; }
            set { quyen = value; }
        }

    }
}

