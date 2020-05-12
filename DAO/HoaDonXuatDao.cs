using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;

namespace DAO
{
  public  class HoaDonXuatDao
    {

        private static HoaDonXuatDao instance;

        public static HoaDonXuatDao Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonXuatDao();
                return instance;
            }
            private set { instance = value; }
        }
        private HoaDonXuatDao() { }


        public DataTable xemhoadonxuat()
        {
            string sql = "select MAHD_Xuat,TenKH,NgayLap_Xuat,NhanVien.TenNV,KhachHang.SDT,KhachHang.DiaChi,(Case TinhTrangXuat when   1 then N'Hoàn Thành' else N'Chưa Hoàn thành' end) as TinhTrangXuat from HoaDon_Xuat, KhachHang, NhanVien where KhachHang.MaKH = HoaDon_Xuat.MAKH and HoaDon_Xuat.MANV = NhanVien.MANV ";

            return Dataprovider.Instance.laydulieutubang(sql);

        }
        public DataTable xemhoadonxuatnv(string manv)
        {
            string sql = "select MAHD_Xuat,TenKH,NgayLap_Xuat,NhanVien.TenNV,KhachHang.SDT,KhachHang.DiaChi,(Case TinhTrangXuat when   1 then N'Hoàn Thành' else N'Chưa Hoàn thành' end) as TinhTrangXuat from HoaDon_Xuat, KhachHang, NhanVien where KhachHang.MaKH = HoaDon_Xuat.MAKH and HoaDon_Xuat.MANV = NhanVien.MANV and NhanVien.MANV='"+manv+"'";

            return Dataprovider.Instance.laydulieutubang(sql);

        }
        public DataTable loadulieukh()
        {
            string sql = "select * from KhachHang";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable loaddulieunhanvien
        {
            get
            {
                string sql = "select * from NhanVien";
                return Dataprovider.Instance.laydulieutubang(sql);
            }
        }

        public bool them1hoadonxuat(HoaDonXuat hoadonxuat)
        {
            string sql = "SET DATEFORMAT dmy insert into HoaDon_Xuat values('" + hoadonxuat.Mahdxuat + "','"+hoadonxuat.Makh+"','"+hoadonxuat.Manv+"','"+hoadonxuat.NgayLap_Xuat1+"','"+hoadonxuat.Tinhtrangxuat1+"')";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool sua1hoadonxuat(HoaDonXuat hoadonxuat)
        {
            string sql = " SET DATEFORMAT dmy  update HoaDon_Xuat set MAKH='" + hoadonxuat.Makh+"',MANV='"+hoadonxuat.Manv+"',NgayLap_Xuat='"+hoadonxuat.NgayLap_Xuat1+"',TinhTrangXuat='"+hoadonxuat.Tinhtrangxuat1+"' where MAHD_Xuat='"+hoadonxuat.Mahdxuat+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool xoa1hoadonxuat(HoaDonXuat hoadonxuat)
        {
            string sql = "delete from HoaDon_Xuat where MAHD_Xuat='"+hoadonxuat.Mahdxuat+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool kiemtrakhoangoai(HoaDonXuat hoadonxuat)
        {
            return true;
        }

        public bool kiemtadulieuhoadonxuat()
        {
            string sql = "select * from HoaDon_Xuat";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;

            }
            else
                return
                    false;

        }
    }
}
