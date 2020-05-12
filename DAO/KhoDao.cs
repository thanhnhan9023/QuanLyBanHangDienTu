using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;

namespace DAO
{
   public class KhoDao
    {
        private static KhoDao    instance;

        public static KhoDao Instance
        {
            get
            {
                if (instance == null) instance = new KhoDao();
                return instance;
            }
            private set { instance = value; }
        }
        private KhoDao() { }



        public DataTable laydulieukho()
        {
            string sql = "select  IDKho,TenHH,DonViTinh,SoLuong,XuatXu from Kho,HangHoa where  Kho.MAHH=HangHoa.MaHH";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable laydulieuhanghoa()
        {
            string sql = "select * from HangHoa";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable loadulieutheocombox(string ma)
        {
            string sql = "select  IDKho,DonViTinh,SoLuong,XuatXu from Kho,HangHoa where  Kho.MAHH=HangHoa.MaHH and Kho.MAHH='"+ma+"'";
            return Dataprovider.Instance.laydulieutubang(sql);

        }

        public bool xoa1kho(string makho)
        {
            string sql = "delete from Kho where IDKho='"+makho+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);

        }
            
    }
}
