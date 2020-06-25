using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;

namespace DAO
{
    public class HoaDonNhapDao
    {

        private static HoaDonNhapDao instance;

        public static HoaDonNhapDao Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonNhapDao();
                return instance;
            }
            private set { instance = value; }
        }
        private HoaDonNhapDao() { }
        public DataTable laydulieuhoadonnhap()
        {
            string sql = "select MAHD_Nhap,NgayLapHD,TenNCC,TenNV,(Case TinhTrangNhap when 1 then N'Hoàn Thành' else N'Chưa Hoàn Thành' end ) as TinhTrangNhap from HoaDon_Nhap,NhanVien,NhaCungCap where HoaDon_Nhap.MANV=.NhanVien.MANV and NhaCungCap.MaNC=HoaDon_Nhap.MaNC";
            return Dataprovider.Instance.laydulieutubang(sql);

        }
        public DataTable laydulieuhoadonhapchonv(string manv)
        {
            string sql = "select MAHD_Nhap,NgayLapHD,TenNCC,TenNV,(Case TinhTrangNhap when 1 then N'Hoàn Thành' else N'Chưa Hoàn Thành' end ) as TinhTrangNhap from HoaDon_Nhap,NhanVien,NhaCungCap where HoaDon_Nhap.MANV=.NhanVien.MANV and NhaCungCap.MaNC=HoaDon_Nhap.MaNC and  NhanVien.MANV='" + manv + "'";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable loadcomboxncc()
        {
            string sql = "select * from NhaCungCap";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable loadcomboxNhanVien()
        {
            string sql = "select * from NhanVien";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public bool them1hoadon(HoaDonNhap hoadon)
        {
            string sql = "insert into HoaDon_Nhap values('" + hoadon.Mahd + "','" + hoadon.Mancc + "','" + hoadon.Manv + "','" + hoadon.Ngaylap + "','" + hoadon.Tinhtrang + "')";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool sua1hoadon(HoaDonNhap hoadon)
        {
            string sql = "set dateformat dmy update HoaDon_Nhap set MaNC='" + hoadon.Mancc + "',MANV='" + hoadon.Manv + "',NgayLapHD='" + hoadon.Ngaylap + "',TinhTrangNhap='" + hoadon.Tinhtrang + "' where MAHD_Nhap='" + hoadon.Mahd + "'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool xoa1hondon(HoaDonNhap hoadon)
        {
            string sql = "delete from HoaDon_Nhap where MAHD_Nhap='" + hoadon.Mahd + "'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }

        public bool updatetinhtranghoadon(string hoadon)
        {
            string sql = "update HoaDon_Nhap set TinhTrangNhap='1' where MAHD_Nhap='" + hoadon + "'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool updatetinhtranghoadondelete(string hoadon)
        {
            string sql = "update HoaDon_Nhap set TinhTrangNhap='0' where MAHD_Nhap='" + hoadon + "'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool kiemtrakhoangoaihoadonhap(HoaDonNhap hd)
        {
            string sql = "select * from ChiTietHD_Nhap where MAHD_Nhap='" + hd.Mahd + "'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool kiemtadulieuhoadonhap()
        {
            string sql = "select * from HoaDon_Nhap";
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
