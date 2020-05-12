using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;

namespace DAO
{
  public  class NhanVienDao
    {
        
        private static NhanVienDao instance;

        public static NhanVienDao Instance
        {
            get
            {
                if (instance == null) instance = new NhanVienDao();
                return instance;
            }
            private set { instance = value; }
        }
        private NhanVienDao() { }

        public DataTable xemdachsachNhanvien()
        {
            string sql = "Select MANV,TenNV,GioiTinh,NgaySinh,DiaChi,SDT,NgayVaoLam,TenCv,(Case TinhTrang when 1 then N'Hoạt Động' else N'Ngưng Hoạt Động' end) as TinhTrang from NhanVien,ChucVu where ChucVu.MaCv=NhanVien.MaCV";
         return   Dataprovider.Instance.laydulieutubang(sql);
        }


        public bool them1nhanvien(NhanVienc nv)
        {
            string sql = " SET DATEFORMAT dmy  insert into NhanVien values('" + nv.Manv+"',N'"+nv.Tennv+"',N'"+nv.Gioitinh+"','"+nv.Ngaysinh+"',N'"+nv.Diachi+"','"+nv.Sdt+"','"+nv.Ngayvaolam+"',null,'"+nv.Macv+"',null,N'"+nv.Tinhtrang+"')";

            return Dataprovider.Instance.thucthicaulenhsql(sql);
                
        }

        public bool sua1nhanvien(NhanVienc nv)
        {
            string sql = "SET DATEFORMAT dmy  update NhanVien set TenNV=N'" + nv.Tennv+"',GioiTinh=N'"+nv.Gioitinh+"',NgaySinh='"+nv.Ngaysinh+"',DiaChi=N'"+nv.Diachi+"',SDT='"+nv.Sdt+ "',NgayVaoLam='"+nv.Ngayvaolam+"',MaCV ='"+nv.Macv+"',TinhTrang='" + nv.Tinhtrang+"' where MANV='"+nv.Manv+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool xoa1nhanvien(NhanVienc nv)
        {
            string sql = "delete from NhanVien where MANV='"+nv.Manv+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        
        public DataTable loaddulieucv()
        {
            string sql = "select * from ChucVu";
            return Dataprovider.Instance.laydulieutubang(sql);
        }

        public string loadlcbt(string ten)
        {
            string sql = "select LCB from ChucVu where TenCv=N'"+ten+"'";
            return Dataprovider.Instance.laydulieusql(sql);
        }
            
        public DataTable loaddulieuluong(string manv)
        {
            string sql = "select MANV,TenNV,DiaChi,GioiTinh,DiaChi,NgayVaoLam,NgayKetThuc,Luong from NhanVien,ChucVu where NhanVien.MaCV=ChucVu.MaCV and MANV='"+manv+"' ";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public bool updateluong(string manv,double luong,DateTime ngaykethuc)
        {
            string sql = " SET DATEFORMAT dmy update NhanVien set Luong=" + luong+ " ,NgayKetThuc='"+ngaykethuc+"' where NhanVien.MANV='" + manv+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool suathongtinluong(string manv,DateTime ngaykethtuc,double luong)
        {

            string sql = "SET DATEFORMAT dmy update NhanVien  set NgayKetThuc='" + ngaykethtuc+"',Luong="+luong+" where NhanVien.MANV='" + manv + "'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool capnhasaukhitinhluong(string manv)
        {
            string sql = "update NhanVien set TinhTrang=0 where NhanVien.MANV='"+manv+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool kiemtracapnhatluong(string manv)
        {
            string sql = "select Luong from NhanVien where MANV='"+manv+"'";
            if (Dataprovider.Instance.laydulieusql(sql)!=string.Empty)
            {
                return true;
            }
            else
                return false;
                   
                    
        }
        public bool kiemtrakhoangoaihoadonxuaatnhanvien(NhanVienc nv)
        {
            string sql = "select * from NhanVien,HoaDon_Xuat where NhanVien.MANV =HoaDon_Xuat.MANV and HoaDon_Xuat.MANV='"+nv.Manv+"'";
            
                if(Dataprovider.Instance.laydulieutubang(sql).Rows.Count>0)
                {
                    return true;
                }
           else  return false;
            
        }
        public bool kiemtrakhoangoaihoadonnhhapnhanvien(NhanVienc nv)
        {
            string sql = "select * from NhanVien,HoaDon_NHap where HoaDon_Nhap.MANV=NhanVien.MANV and HoaDon_Nhap.MANV='"+nv.Manv+"'";

            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            else return false;

        }
        public bool kiemtrakhoangoaiquantringuoidung(NhanVienc nv)
        {

            string sql = "select * from NhanVien,QuanTriNguoiDung where QuanTriNguoiDung.MANV=NhanVien.MANV and QuanTriNguoiDung.MANV='"+nv.Manv+"'";

            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
