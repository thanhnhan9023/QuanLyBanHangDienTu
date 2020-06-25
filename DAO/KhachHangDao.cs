using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Windows.Forms;

namespace DAO
{
    public class KhachHangDao
    {

        private static KhachHangDao instance;

        public static KhachHangDao Instance
        {
            get
            {
                if (instance == null) instance = new KhachHangDao();
                return instance;
            }
            private set { instance = value; }
        }
        private KhachHangDao() { }
        public IList<KhachHang>  xem()
        {
            List<KhachHang> khachang = new List<KhachHang>();

            string sql = "select * from KhachHang";

         DataTable data  = Dataprovider.Instance.laydulieutubang(sql);
            foreach (DataRow item in data.Rows)
            {
                string makh1 = item["MaKH"].ToString();
                string tenkh1 = item["TenKH"].ToString();
                string diachi1 = item["DiaChi"].ToString();
                string sdt1 = item["SDT"].ToString();
                KhachHang kh = new KhachHang(makh1, tenkh1, diachi1, sdt1);
                khachang.Add(kh);
            }

            return khachang;
        }
       
        public bool themmotkhachhangmoi(KhachHang kh)
        {
            
            string sql = "insert into KhachHang values('"+kh.Makh+"',N'"+kh.Tenkh+"',N'"+kh.Diachi+"','"+kh.Sdt+"')";
           
            if(Dataprovider.Instance.thucthicaulenhsql(sql))
            {
                return true;
            }
            return false;
        }
        public bool suakhachkhang(KhachHang kh)
        {
            string sql = "update KhachHang set TenKH=N'"+kh.Tenkh+"',DiaChi=N'"+kh.Diachi+"',SDT='"+kh.Sdt+"' where MaKH='"+kh.Makh+"'";
            if (Dataprovider.Instance.thucthicaulenhsql(sql)) 
            {
                return true;
            }
            return false;
        }
        public bool xoakhachhang(KhachHang kh)
        {
           
            string sql = "delete from  KhachHang where MaKH='"+kh.Makh+"'";
            if(Dataprovider.Instance.thucthicaulenhsql(sql))
            {
                return true;
            }
            return false;
        }
            

    }
  
}
