using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT0
{
   public class LoaiHang
    {
        string maloai;
        string tenloai;
        string diengiai;
   string tinhtrang;

        public string Maloai
        {
            get
            {
                return maloai;
            }

            set
            {
                maloai = value;
            }
        }

        public string Tenloai
        {
            get
            {
                return tenloai;
            }

            set
            {
                tenloai = value;
            }
        }

        public string Diengiai
        {
            get
            {
                return diengiai;
            }

            set
            {
                diengiai = value;
            }
        }

        public string Tinhtrang
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
        public LoaiHang(string maloai,string tenloai,string diengiai,string tinhtrang)
        {
            this.maloai = maloai;
            this.tenloai = tenloai;
            this.diengiai = diengiai;
            this.tinhtrang = tinhtrang;
        }
    }
}
