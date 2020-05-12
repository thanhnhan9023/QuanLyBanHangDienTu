using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;

namespace DAO
{
   public class ChiTietHoaDonNhapDao
    {
        private static ChiTietHoaDonNhapDao instance;

        public static ChiTietHoaDonNhapDao  Instance
        {
            get
            {
                if (instance == null) instance = new ChiTietHoaDonNhapDao();
                return instance;
            }
            private set { instance = value; }
        }
        private ChiTietHoaDonNhapDao() { }
        public DataTable laydschitiethd(string mahdn)
        {
            string sql = "select ID_Nhap,TenHH,DonViTinh,SoLuong_Nhap,DonGia_Nhap,Thanhtien from HoaDon_Nhap,ChiTietHD_Nhap,HangHoa where HoaDon_Nhap.MAHD_Nhap=ChiTietHD_Nhap.MAHD_Nhap  and HangHoa.MaHH=ChiTietHD_Nhap.MAHH   and HoaDon_Nhap.MAHD_Nhap='"+mahdn+"'";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable loadducomboxhh()
        {
            string sql = "select * from HangHoa";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable loaddulieudonvi(string x)
        {
            string sql = "select DonViTinh from HangHoa where MaHH='"+x+"'";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public bool them1chiettiethoadonnhap(ChiTietHDNhap chietiethoadonhap)
        {
            string sql = "insert ChiTietHD_Nhap values('"+chietiethoadonhap.ID_Nhap1+"','"+chietiethoadonhap.Mahh+"','"+chietiethoadonhap.Mahd+"',"+chietiethoadonhap.Soluong+","+chietiethoadonhap.Dongianhap+","+chietiethoadonhap.Thanhtien+")";
            return Dataprovider.Instance.thucthicaulenhsql(sql);

        }
        public bool sua1chiettiethoadonnhap(ChiTietHDNhap chietiethoadonhap)
        {
            string sql = "update ChiTietHD_Nhap set MAHH='"+chietiethoadonhap.Mahh+"',MAHD_Nhap='"+chietiethoadonhap.Mahd+"',SoLuong_Nhap="+chietiethoadonhap.Soluong+",DonGia_Nhap="+chietiethoadonhap.Dongianhap+",Thanhtien="+chietiethoadonhap.Thanhtien+" where ID_Nhap='"+chietiethoadonhap.ID_Nhap1+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool xoa1chiettiethoadonnhap(ChiTietHDNhap chietiethoadonhap)
        {
            string sql = "delete  from ChiTietHD_Nhap where ID_Nhap='"+chietiethoadonhap.ID_Nhap1+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool kiemtradulieuchohdnhap()
        {
            string sql = "select * from ChiTietHD_Nhap";
            if(Dataprovider.Instance.laydulieutubang(sql).Rows.Count>0)
            {
                return true;
            }
            return false;
        }

        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("HoaDon_Nhap", "MAHD_Nhap"), "HD");

        }
    }
}
