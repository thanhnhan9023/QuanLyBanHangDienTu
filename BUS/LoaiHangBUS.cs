using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DT0;

namespace BUS
{
    public class LoaiHangBUS
    {

        private static LoaiHangBUS instance;
        public static LoaiHangBUS Instance
        {
            get
            {
                if (instance == null) instance = new LoaiHangBUS();
                return instance;
            }
            private set { instance = value; }
        }
        public LoaiHangBUS() { }

        public void xemloaihang(GridControl data)
        {
            data.DataSource = LoaiHangDao.Instance.xemloaihang();
        }
        public bool them1loaihang(LoaiHang lh)
        {
            return LoaiHangDao.Instance.them1loaihang(lh);
        }
        public bool sua1loaihang(LoaiHang lh)
        {
            return LoaiHangDao.Instance.sua1loaihang(lh);
        }
        public bool xoa1loaihang(LoaiHang lh)
        {
            return LoaiHangDao.Instance.xoa1loaihang(lh);
        }
        public bool kiemtrakhoangoai(LoaiHang lh)
        {
            return LoaiHangDao.Instance.kiemtrakhoangoai(lh);
        }
        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("LoaiHang", "MaLoai"), "LH");

        }

    }
}
