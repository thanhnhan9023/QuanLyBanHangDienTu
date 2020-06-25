using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;

namespace DAO
{
  public  class ChiTietHDXuatDao
    {
        private static ChiTietHDXuatDao instance;

        public static ChiTietHDXuatDao Instance
        {
            get
            {
                if (instance == null) instance = new ChiTietHDXuatDao();
                return instance;
            }
            private set { instance = value; }
        }
        private ChiTietHDXuatDao() { }
        public DataTable laydulieuchietiethdxuat(string mahdxuat)
        {
            string sql = "select  IDXuat,TenHH,DonViTinh,SoLuong_Xuat,DonGia_Xuat,ThanhTienXuat   from Kho,ChiTietHD_Xuat,HangHoa,HoaDon_Xuat   where HoaDon_Xuat.MAHD_Xuat=ChiTietHD_Xuat.MAHD_Xuat and HangHoa.MaHH=Kho.MAHH and Kho.MAHH=ChiTietHD_Xuat.MAHH and ChiTietHD_Xuat.MAHD_Xuat='"+mahdxuat+"'";
            return Dataprovider.Instance.laydulieutubang(sql);
        }

        public DataTable laydulieuhanghoa()
        {
            string sql = "select * from HangHoa";
            return Dataprovider.Instance.laydulieutubang(sql);

        }
        public string laysolieutonkho(string ma)
        {
            string sql = "select  SoLuong from Kho where MAHH='"+ma+"'";
            return Dataprovider.Instance.laydulieusql(sql);
        }
         public string laydulieugianhap(string ma)
        {
            
            string sql = "select DonGia_Nhap from ChiTietHD_Nhap where MAHH ='"+ma+"'";

            return Dataprovider.Instance.laydulieusql(sql);
        }
        public string laydulieuxuatxu(string ma)
        {
            string sql = "select XuatXu from HangHoa where MaHH='"+ma+"'";
            return Dataprovider.Instance.laydulieusql(sql);
  

        }
        public string laydulieudonvi(string ma)
        {
            string sql = "select DonViTinh from HangHoa where MaHH='" + ma + "'";
            return Dataprovider.Instance.laydulieusql(sql);
        }

        public  int laydusoluongkho(string mahh)
        {
            string sql = "select SoLuong from Kho where MAHH='" + mahh + "'";
            return Dataprovider.Instance.laydulieuint(sql);
        }

        public int laydusoluongdangxuat(string maHH)
        {
            string sql ="select SoLuong_Xuat from ChiTietHD_Xuat where  MAHH = '"+maHH+"'";
            return Dataprovider.Instance.laydulieuint(sql);
        }

        public string laydulieuidlkho(string  ma)
        {
            string sql = "select MAHH from Kho,HangHoa where HangHoa.MaHH=Kho.MAHH and Kho.MaHH='"+ma+"'";
            return Dataprovider.Instance.laydulieusql(sql);
        }

        public bool them1chietiethoadonxuat(ChiTietXuatHD chitethd)
        {
            string sql = "insert into ChiTietHD_Xuat values('"+chitethd.ID_HDXuat1+"','"+chitethd.MAHH1+"','"+chitethd.Mahdxuat+"',"+chitethd.Soluongxuat+","+chitethd.Dongiaxuat+","+chitethd.ThanhTien1+")";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool sua1chietiethoadonxuat(ChiTietXuatHD chitethd)
        {
            string sql = "update ChiTietHD_Xuat set MAHH='"+chitethd.MAHH1+"',MAHD_Xuat='"+chitethd.Mahdxuat+"',SoLuong_Xuat='"+chitethd.Soluongxuat+"',DonGia_Xuat='"+chitethd.Dongiaxuat+"' where IDXuat='"+chitethd.ID_HDXuat1+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool xoa1chietiethoadonxuat(ChiTietXuatHD chitethd)
        {
            string sql = "delete  from ChiTietHD_Xuat where IDXuat='" + chitethd.ID_HDXuat1 + "'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
       

         public bool kiemtradulieuphieuxuat()
        {
            string sql = "select * from ChiTietHD_Xuat";
            if(Dataprovider.Instance.laydulieutubang(sql).Rows.Count>0)
            {
                return true;
            }
            return false;
        }
            
    }
}
