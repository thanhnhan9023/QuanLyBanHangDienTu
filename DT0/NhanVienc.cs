using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT0
{
  public  class NhanVienc
    {

        string manv;
        string tennv;
        string gioitinh;
        DateTime ngaysinh;
        string diachi;
        string sdt;
        DateTime ngayvaolam;
        string macv;
        double luong;
        bool tinhtrang;

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

        public string Tennv
        {
            get
            {
                return tennv;
            }

            set
            {
                tennv = value;
            }
        }

        public string Gioitinh
        {
            get
            {
                return gioitinh;
            }

            set
            {
                gioitinh = value;
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

        public DateTime Ngaysinh
        {
            get
            {
                return ngaysinh;
            }

            set
            {
                ngaysinh = value;
            }
        }

        public DateTime Ngayvaolam
        {
            get
            {
                return ngayvaolam;
            }

            set
            {
                ngayvaolam = value;
            }
        }

        public string Macv
        {
            get
            {
                return macv;
            }

            set
            {
                macv = value;
            }
        }

        public double Luong
        {
            get
            {
                return luong;
            }

            set
            {
                luong = value;
            }
        }

        public NhanVienc(string manv,string tennv,string gioitinh,DateTime Ngaysinh,string diachi,string sdt,bool tinhtrang)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.gioitinh = gioitinh;
            this.Ngaysinh = Ngaysinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.tinhtrang = tinhtrang;

        }
        public NhanVienc() { }
            
    }
}
