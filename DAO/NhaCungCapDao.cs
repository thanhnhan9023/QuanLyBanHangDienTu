using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;

namespace DAO
{
 public class NhaCungCapDao
    {


        private static NhaCungCapDao instance;

        public static NhaCungCapDao Instance
        {
            get
            {
                if (instance == null) instance = new NhaCungCapDao();
                return instance;
            }
            private set { instance = value; }
        }
        private NhaCungCapDao() { }

        public DataTable laydulieunhacc()
        {
            string sql = "select * from NhaCungCap";
            return Dataprovider.Instance.laydulieutubang(sql);
            
        }
        public bool them1nhacc(NhaCungCap ncc)
        {
            string sql = "insert into NhaCungCap values('" + ncc.Mancc + "',N'" + ncc.Tenncc + "',N'" + ncc.Diachi + "','" + ncc.Sdt + "')";
          return  Dataprovider.Instance.thucthicaulenhsql(sql);
           
        }
        public bool suanhacuncap(NhaCungCap ncc)
        {
            string sql = "update NhaCungCap set TenNCC=N'"+ncc.Tenncc+"',DIACHI=N'"+ncc.Diachi+"',SDT='"+ncc.Sdt+"' where MaNC='"+ncc.Mancc+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);

        }
        public bool xoancc(NhaCungCap ncc)
        {
            string sql = "delete  from NhaCungCap where MaNC='"+ncc.Mancc+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);

        }
        public bool kiemtrangoangoaincc(NhaCungCap ncc)
        {
            string sql = "select * from HoaDon_Nhap where MANC='" + ncc.Mancc + "'";
           if(Dataprovider.Instance.laydulieutubang(sql).Rows.Count>0)
            {
                return true;
                    
            }
            return false;     
        }
        public DataTable timkiemnhacungcap(string tim)
        {
            string sql = "Select * from NhaCungCap where TenNCC like N'%"+tim+"%'  or MaNC like N'%"+tim+"%'";
            return Dataprovider.Instance.laydulieutubang(sql);
        }

    }
}
