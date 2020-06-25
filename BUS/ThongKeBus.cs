using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class ThongKeBus
    {
        private static ThongKeBus instance;
        public static ThongKeBus Instance
        {
            get
            {
                if (instance == null) instance = new ThongKeBus();
                return instance;
            }
            private set { instance = value; }
        }
        public ThongKeBus() { }


        public void laydulieuthongkengay(GridControl data,DateTime date)
        {

            data.DataSource = ThongKeDao.Instance.laydulieuthongkengay(date);

        }
    }
}

