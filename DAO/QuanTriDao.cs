using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;

namespace DAO
{
   public class QuanTriDao
    {


        private static QuanTriDao instance;

        public static QuanTriDao Instance
        {
            get
            {
                if (instance == null) instance = new QuanTriDao();
                return instance;
            }
            private set { instance = value; }
        }
        private QuanTriDao() { }
        public DataTable laydulieuquantri()
        {
            string sql = "select ID_I,UserName,TenNV,TenCv from QuanTriNguoiDung,NhanVien,ChucVu  where QuanTriNguoiDung.MANV=NhanVien.MANV and ChucVu.MaCv=QuanTriNguoiDung.MaCV";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable loadulieuusernam()
        {
            string sql = "select * from NguoiDung";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable laydulieutennv()
        {
            string sql = "select * from NhanVien";
            return Dataprovider.Instance.laydulieutubang(sql);
        }

        public  string laydulieuchucvu(string ma)
        {
            string sql = "select TenCv from ChucVu,NhanVien where NhanVien.MaCV=ChucVu.MaCv and MANV='"+ma+"'";
            return Dataprovider.Instance.laydulieusql(sql);
        }
        public bool kiemtrausernamektrung(string username)
        {
            string sql = "select * from QuanTriNguoiDung where UserName='"+username+"'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool them1quantringuoidung(AccoutQuanTri accountqt)
        {
            string sql = "insert into QuanTriNguoiDung values('"+accountqt.ID_quantri1+"','"+accountqt.Username+"','"+accountqt.Manv+"','"+accountqt.Macv+"')";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool xoa1quantringuoidung(AccoutQuanTri accountqt)
        {
            string sql = "delete from QuanTriNguoiDung where ID_I='" + accountqt.ID_quantri1 + "'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool sua1quantringuoidung(AccoutQuanTri accountqt)
        {
            string sql = "update QuanTriNguoiDung  set UserName='"+accountqt.Username+"' ,MANV='"+accountqt.Manv+"',MaCV='"+accountqt.Macv+"'   where ID_I='"+accountqt.ID_quantri1+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public string laymachucvu(string ma)
        {
            string sql = "select MaCv from ChucVu where TenCv=N'"+ma+"'";
            return Dataprovider.Instance.laydulieusql(sql);
        }
      
    }
}
