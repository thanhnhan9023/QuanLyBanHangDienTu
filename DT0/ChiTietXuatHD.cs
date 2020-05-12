using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT0
{
   public class ChiTietXuatHD
    {
        string ID_HDXuat;
        string ID_Kho;
        string mahdxuat;
        int soluongxuat;
        double dongiaxuat;
        double ThanhTien;

        public string ID_HDXuat1
        {
            get
            {
                return ID_HDXuat;
            }

            set
            {
                ID_HDXuat = value;
            }
        }

        public string ID_Kho1
        {
            get
            {
                return ID_Kho;
            }

            set
            {
                ID_Kho = value;
            }
        }

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

        public int Soluongxuat
        {
            get
            {
                return soluongxuat;
            }

            set
            {
                soluongxuat = value;
            }
        }

        public double Dongiaxuat
        {
            get
            {
                return dongiaxuat;
            }

            set
            {
                dongiaxuat = value;
            }
        }

        public double ThanhTien1
        {
            get
            {
                return ThanhTien;
            }

            set
            {
                ThanhTien = value;
            }
        }
    }
}
