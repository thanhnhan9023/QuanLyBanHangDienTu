using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace DAO
{
   public class LoaiHangDao
    {

        private static LoaiHangDao instance;

        public static LoaiHangDao Instance
        {
            get
            {
                if (instance == null) instance = new LoaiHangDao();
                return instance;
            }
            private set { instance = value; }
        }
        private LoaiHangDao() { }
        
        public List<LoaiHang>  xemloaihang()
          {
            List<LoaiHang> loaihang = new List<LoaiHang>();

        string sql = "select MaLoai,TenLoai,DIENGIAI,(Case TinhTrangHang when 1 then N'Còn Kinh Doanh' else N'Ngừng Kinh Doanh' end) as TinhTrangHang from LoaiHang";

        DataTable data = Dataprovider.Instance.laydulieutubang(sql);
            foreach (DataRow item in data.Rows)
            {
             
                string maloai = item["MaLoai"].ToString();
                string tenloai = item["TenLoai"].ToString();
                string diengiai = item["DIENGIAI"].ToString();
                string tinhtrang =item["TinhTrangHang"].ToString();
           
               
          
                LoaiHang loai = new LoaiHang(maloai, tenloai, diengiai, tinhtrang);

                loaihang.Add(loai);
            }
            return loaihang;
           
        }
        public bool them1loaihang(LoaiHang loaih)
        {
            string sql = "insert into LoaiHang values('"+loaih.Maloai+"',N'"+loaih.Tenloai+"',N'"+loaih.Diengiai+"','"+loaih.Tinhtrang+"')";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }

        public bool sua1loaihang(LoaiHang loaih)
        {
            string sql = "update LoaiHang set TenLoai=N'"+loaih.Tenloai+"',DIENGIAI=N'"+loaih.Diengiai+ "',TinhTrangHang="+loaih.Tinhtrang+" where MaLoai='" + loaih.Maloai+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool xoa1loaihang(LoaiHang loaih)
        {
            string sql = "delete from LoaiHang where MaLoai='"+loaih.Maloai+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);

        }
        public bool kiemtrakhoangoai(LoaiHang loaih)
        {
            string sql = "select * from HangHoa where MaLoai='"+loaih.Maloai+"'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            return false;

        }
    }
    
            


    
}
