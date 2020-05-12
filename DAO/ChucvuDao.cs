using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;

namespace DAO
{
  public  class ChucvuDao
    {
        private static ChucvuDao instance;

        public static ChucvuDao Instance
        {
            get
            {
                if (instance == null) instance = new ChucvuDao();
                return instance;
            }
            private set { instance = value; }
        }
        private ChucvuDao() { }
        public bool them1machucvu(ChucVucc cv)
        {
            string sql = "insert into  ChucVu values ('" + cv.Machucvu+"',N'"+cv.Tenchucvu+"',"+cv.Lcb+")";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool sua1chucvu(ChucVucc cv)
        {

            string sql = "update ChucVu set TenCv=N'"+cv.Tenchucvu+"',LCB="+cv.Lcb+" where MaCv='"+cv.Machucvu+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool xoa1chucvu(ChucVucc cv)
        {

            string sql = "delete from ChucVu where MaCv = '" + cv.Machucvu + "'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public DataTable laydulieuchucvu()
        {
            string sql = "select *  from ChucVu";

            return Dataprovider.Instance.laydulieutubang(sql);

        }
        public bool kiemtradulieucnhanvien(ChucVucc cv)
        {
            string sql = "select * from NhanVien,ChucVu where ChucVu.MaCv=NhanVien.MaCV and NhanVien.MaCV='"+cv.Machucvu+"'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool kiemtradulieuquantringuoidug(ChucVucc cv)
        {
            string sql = "select  *  from QuanTriNguoiDung,NhanVien where QuanTriNguoiDung.MANV=NhanVien.MANV and QuanTriNguoiDung.MANV='"+cv.Machucvu+"'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
