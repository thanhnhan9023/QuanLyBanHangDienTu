using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT0
{
  public  class HoaDonXuat
    {
        string mahdxuat;
        string makh;
        string manv;
        DateTime NgayLap_Xuat;
        bool Tinhtrangxuat;

        public string Mahdxuat
        {
            get
            {
                return mahdxuat;
            }

            set
            {
                mahdxuat = value;
            }
        }

        public string Makh
        {
            get
            {
                return makh;
            }

            set
            {
                makh = value;
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

        public DateTime NgayLap_Xuat1
        {
            get
            {
                return NgayLap_Xuat;
            }

            set
            {
                NgayLap_Xuat = value;
            }
        }

        public bool Tinhtrangxuat1
        {
            get
            {
                return Tinhtrangxuat;
            }

            set
            {
                Tinhtrangxuat = value;
            }
        }
    }
}
