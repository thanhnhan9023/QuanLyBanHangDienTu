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
   public class HangHoaBUS
    {
        private static HangHoaBUS instance;
        public static HangHoaBUS Instance
        {
            get
            {
                if (instance == null) instance = new HangHoaBUS();
                return instance;
            }
            private set { instance = value; }
        }
        public void laydulieuhanghoa(GridControl data)
        {
            data.DataSource = HangHoaDao.Instance.laydulieuhanghoa();

        }
    public bool them1hanghoa(HangHoa hh)
        {
            return HangHoaDao.Instance.them1hanghoa(hh);
        }
        public bool sua1hanghoa(HangHoa hh)
        {
            return HangHoaDao.Instance.sua1hanghoa(hh);
        }
        public bool xoa1hanghoa(HangHoa hh)
        {
            return HangHoaDao.Instance.xoa1hanghoa(hh);
        }
        public void loadmaloaicombox(ComboBox data)
        {
            data.DataSource = HangHoaDao.Instance.loadmaloaicombox();
            data.DisplayMember = "TenLoai";
            data.ValueMember = "MaLoai";
        }
        public bool kiemtrakhoangoaikho(HangHoa hanghoa)
        {
            return HangHoaDao.Instance.kiemtrakhoangoaikho(hanghoa);   
        }
        public bool kiemtrakhoangoaihoadonhap(HangHoa hanghoa)
        {
            return HangHoaDao.Instance.kiemtrakhoangoaihoadonhap(hanghoa);
        }
        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("HangHoa", "MaHH"), "HH");

        }
    }
}
