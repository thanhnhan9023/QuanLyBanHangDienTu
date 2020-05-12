using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using DAO;
using System.Windows.Forms;

namespace BUS
{
    public class KhoBUS
    {

        private static KhoBUS instance;
        public static KhoBUS Instance
        {
            get
            {
                if (instance == null) instance = new KhoBUS();
                return instance;
            }
            private set { instance = value; }
        }
        public KhoBUS() { }

        public void laydulieukho(GridControl data)
        {
            data.DataSource = KhoDao.Instance.laydulieukho();
        }
        public void laydulieuhh(ComboBox data)
        {
            data.DataSource = KhoDao.Instance.laydulieuhanghoa();
            data.DisplayMember = "TenHH";
            data.ValueMember = "MaHH";
        }
        public void loadulieutheocombox(GridControl data, string ma)
        {
            data.DataSource = KhoDao.Instance.loadulieutheocombox(ma);
        }
        public bool xoa1kho(string makho)
        {
            return KhoDao.Instance.xoa1kho(makho);
        }
    }
}
