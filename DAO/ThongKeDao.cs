using DevExpress.Xpo.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAO
{
  public  class ThongKeDao
    {
        DataTable dt;
        private static ThongKeDao instance;

        public static ThongKeDao Instance
        {
            get
            {
                if (instance == null) instance = new ThongKeDao();
                return instance;
            }
            private set { instance = value; }
        }
        private ThongKeDao() { }

        public DataTable laydulieuthongkengay(DateTime date)
        {
            string sql= "select sum(Thanhtien) as'Thongke' from HoaDon_Nhap,ChiTietHD_Nhap where  NgayLapHD='"+date.ToShortDateString()+"'";
            dt=Dataprovider.Instance.laydulieutubang(sql);

            return dt;        

        }
        
    }
}
