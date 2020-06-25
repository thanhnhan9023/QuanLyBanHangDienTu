using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DAO;
using DT0;

namespace BUS
{
   public class KhachHangBUS
    {
        KhachHang kh;

        private static KhachHangBUS instance;
        public static KhachHangBUS Instance
        {
            get
            {
                if (instance == null) instance = new KhachHangBUS();
                return instance;
            }
            private set { instance = value; }
        }

        public KhachHang Kh
        {
            get
            {
                return kh;
            }

            set
            {
                kh = value;
            }
        }

        private KhachHangBUS() { }
        public void laydulieukh(GridControl data)
        {
            data.DataSource = KhachHangDao.Instance.xem();
        }
        public bool themmotkhachhang(string makh,string tenkh,string diachi,string sdt)
        {
             kh = new KhachHang(makh, tenkh, diachi, sdt);
            return KhachHangDao.Instance.themmotkhachhangmoi(kh);
        }
        public bool suamotkhachang(string makh,string tenkh,string diachi,string sdt)
        {
            kh = new KhachHang(makh, tenkh, diachi, sdt);
            return KhachHangDao.Instance.suakhachkhang(kh);
        }
        public bool xoamotkhachang(string makh)
        {
            kh = new KhachHang(makh, null, null, null);
            return KhachHangDao.Instance.xoakhachhang(kh);
        }
        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("KhachHang", "MaKH"),"KH");
               
        }
     
        
    }
}
