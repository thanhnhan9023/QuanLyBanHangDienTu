using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT0
{
   public class HoaDonNhap
    {

        string mahd;
        DateTime ngaylap;
        string mancc;
        string manv;
        bool tinhtrang;

      

        public DateTime Ngaylap
        {
            get
            {
                return ngaylap;
            }

            set
            {
                ngaylap = value;
            }
        }

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


      

        public string Manv
        {
            get
            {
                return manv;
            }

            set
            {
                manv = value;
            }
        }

        public bool Tinhtrang
        {
            get
            {
                return tinhtrang;
            }

            set
            {
                tinhtrang = value;
            }
        }

        public string Mahd
        {
            get
            {
                return mahd;
            }

            set
            {
                mahd = value;
            }
        }
    }
}
