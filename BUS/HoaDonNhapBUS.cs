using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using DAO;
using DevExpress.XtraGrid;
using System.Windows.Forms;

namespace BUS
{
   public class HoaDonNhapBUS
    {

        private static HoaDonNhapBUS instance;
        public static HoaDonNhapBUS Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonNhapBUS();
                return instance;
            }
            private set { instance = value; }
        }
        public HoaDonNhapBUS() { }
        public void laydulieuhoadonnhap(GridControl data)
        {
            data.DataSource= HoaDonNhapDao.Instance.laydulieuhoadonnhap();
        }
        public void loadcomboxncc(ComboBox data)
            {
            data.DataSource = HoaDonNhapDao.Instance.loadcomboxncc();
            data.DisplayMember = "TenNCC";
            data.ValueMember = "MaNC";
            }
        public void loadcomboxnhanvien(ComboBox data)
        {
            data.DataSource = HoaDonNhapDao.Instance.loadcomboxNhanVien();
            data.DisplayMember= "TenNV";
            data.ValueMember = "MANV";
        }
        public bool them1hoadon(HoaDonNhap  hoadon)
        {
            return HoaDonNhapDao.Instance.them1hoadon(hoadon);
        }
        public bool sua1hoadon(HoaDonNhap hoadon)
        {
            return HoaDonNhapDao.Instance.sua1hoadon(hoadon);
        }
        public bool xoa1hoandon(HoaDonNhap hoadon)
        {
            return HoaDonNhapDao.Instance.xoa1hondon(hoadon);
        }

        public bool updatetinhtranghoadon(string mahd)
        {
            return HoaDonNhapDao.Instance.updatetinhtranghoadon(mahd);
        }
        public bool updatetinhtranghoadondelete(string mahd)
        {
            return HoaDonNhapDao.Instance.updatetinhtranghoadondelete(mahd);
        }
        public void laydulieuhoadonnhapchonv(GridControl data,string nv)
        {
         data.DataSource= HoaDonNhapDao.Instance.laydulieuhoadonhapchonv(nv);
        }
        public bool kiemtrakhoangoaihoadonhap(HoaDonNhap hd)
        {
            return HoaDonNhapDao.Instance.kiemtrakhoangoaihoadonhap(hd);
        }
        public bool kiemtadulieuhoadonhap()
        {
            return HoaDonNhapDao.Instance.kiemtadulieuhoadonhap();
        }
        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("HoaDon_Nhap", "MAHD_Nhap"), "HD");

        }
    }
}
