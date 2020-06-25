using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class NhaCungCap
    {
        string mancc;
        string tenncc;
        string diachi;
        string sdt;

        public string Mancc
        {
            get
            {
                return mancc;
            }

            set
            {
                mancc = value;
            }
        }

        public string Tenncc
        {
            get
            {
                return tenncc;
            }

            set
            {
                tenncc = value;
            }
        }

        public string Diachi
        {
            get
            {
                return diachi;
            }

            set
            {
                diachi = value;
            }
        }

        public string Sdt
        {
            get
            {
                return sdt;
            }

            set
            {
                sdt = value;
            }
        }

        public NhaCungCap(string mancc,string tenncc,string diachi,string sdt)
        {
            this.mancc = mancc;
            this.tenncc = tenncc;
            this.diachi = diachi;
            this.sdt = sdt;

        }

    }
}
