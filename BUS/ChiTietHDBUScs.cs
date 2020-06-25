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
  public  class ChiTietHDBUScs
    {

        private static ChiTietHDBUScs instance;
        public static ChiTietHDBUScs Instance
        {
            get
            {
                if (instance == null) instance = new ChiTietHDBUScs();
                return instance;
            }
            private set { instance = value; }
        }
        public ChiTietHDBUScs() { }
        public void laydachsachchitiethd(GridControl data,string mahdn)
        {
            data.DataSource = ChiTietHoaDonNhapDao.Instance.laydschitiethd(mahdn);
        }
        public void  loadcomboxhh(ComboBox data)
        {
            data.DataSource = ChiTietHoaDonNhapDao.Instance.loadducomboxhh();
            data.DisplayMember = "TenHH";
            data.ValueMember = "MaHH";
        }
        public void loadcomboxdonvi(ComboBox data,string x)
        {
            data.DataSource = ChiTietHoaDonNhapDao.Instance.loaddulieudonvi(x);
            data.DisplayMember = "DonViTinh";
            data.ValueMember = "DonViTinh";
        }
        public bool them1chitiethoadon(ChiTietHDNhap chitiethoadon)
        {
            return ChiTietHoaDonNhapDao.Instance.them1chiettiethoadonnhap(chitiethoadon);
        }
        public bool sua1chitiethoadon(ChiTietHDNhap chitiethoadon)
        {
            return ChiTietHoaDonNhapDao.Instance.sua1chiettiethoadonnhap(chitiethoadon);
        }
        public bool xoa1chitiethoadon(ChiTietHDNhap chitiethoadon)
        {
            return ChiTietHoaDonNhapDao.Instance.xoa1chiettiethoadonnhap(chitiethoadon);
        }
        public bool kiemtradulieuhdnhap()
        {
            return ChiTietHoaDonNhapDao.Instance.kiemtradulieuchohdnhap();
        }
        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("ChiTietHD_Nhap", "ID_Nhap"), "HDN");

        }
    }
}
