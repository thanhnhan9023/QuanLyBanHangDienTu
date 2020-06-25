using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DT0
{
    
  public  class KhachHang
    {
        private string makh;
      
        private string tenkh;
      
        private string diachi;
      
        private string sdt;

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

        public string Tenkh
        {
            get
            {
                return tenkh;
            }

            set
            {
                tenkh = value;
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

        public KhachHang(string makh, string tenkh, string diachi, string sdt)
        {
            this.makh = makh;
            this.tenkh = tenkh;
            this.sdt = sdt;
            this.diachi = diachi;
        }
    public KhachHang() { }
      
    //    public DataTable laydulieuKH()
    //    {
    //        string sql = "select * from KhachHang";
    //        return data.laydulieutubang(sql);
    //    }
    //public bool themmotkhachhang()
    //    {
    //        string sql = "insert into KhachHang values('"+MaKH+"','"+TenKH+"','"+DiaChi+"','"+SDT+"')";
    //        return data.thucthicausql(sql);
    //    }
    //    public bool suammotkhachhang()
    //    {
    //        string sql = "update KhachHang set TenKH='"+TenKH+"',DiaChi='"+DiaChi+"',SDT='"+SDT+"' where MaKH='"+MaKH+"'";
    //        return data.thucthicausql(sql);
    //    }
    //    public bool xoammotkhachhang()
    //    {
    //        string sql = "delete from KhachHang where MaKH='"+MaKH+"'";
    //        return data.thucthicausql(sql);
    //    }
        public bool hamkiemtrahopledulieu(string makh,string tenkh,string diachi,string sdt)
        {
            if(makh==string.Empty || tenkh==string.Empty || diachi==string.Empty || sdt==string.Empty)
            {
                return false;
            }
            return true;
        }
        
           
         
        
    }
}
