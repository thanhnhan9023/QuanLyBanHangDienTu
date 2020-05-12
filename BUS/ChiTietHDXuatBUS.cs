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
 public   class ChiTietHDXuatBUS
    {

        private static ChiTietHDXuatBUS instance;
        public static ChiTietHDXuatBUS Instance
        {
            get
            {
                if (instance == null) instance = new ChiTietHDXuatBUS();
                return instance;
            }
            private set { instance = value; }
        }
        public void laydulieuchitiethdxuat(GridControl data,string  mahdxuat)
        {

            data.DataSource = ChiTietHDXuatDao.Instance.laydulieuchietiethdxuat(mahdxuat);
        }
        public void laydulieuhanghoa(ComboBox data)
        {
            data.DataSource = ChiTietHDXuatDao.Instance.laydulieuhanghoa();
            data.DisplayMember = "TenHH";
            data.ValueMember = "MaHH";
        }
        public string laysoluongtonkho(string ma)
        {
            return ChiTietHDXuatDao.Instance.laysolieutonkho(ma);
        }
        public string laygianhap(string  ma)
        {
            return ChiTietHDXuatDao.Instance.laydulieugianhap(ma);
        } 
        public string laydulieuxuatxu(string ma)
        {
            return ChiTietHDXuatDao.Instance.laydulieuxuatxu(ma);
        }
        public string laydonvitinh(string ma)
        {
            return ChiTietHDXuatDao.Instance.laydulieudonvi(ma);

        }
        public string laydulieuidkho(string ma)
        {
            return ChiTietHDXuatDao.Instance.laydulieuidlkho(ma);
        }
        public bool them1chitiethoadonxuat(ChiTietXuatHD chitiet)
        {
            return ChiTietHDXuatDao.Instance.them1chietiethoadonxuat(chitiet);

        }
        public bool sua1chitiethoadonxuat(ChiTietXuatHD chitiet)
        {
            return ChiTietHDXuatDao.Instance.sua1chietiethoadonxuat(chitiet);

        }
        public bool xoa1chitiethoadonxuat(ChiTietXuatHD chitiet)
        {
            return ChiTietHDXuatDao.Instance.xoa1chietiethoadonxuat(chitiet);

        }
      public bool kiemtradulieuphieuxuat()
        {
            return ChiTietHDXuatDao.Instance.kiemtradulieuphieuxuat();
        }


        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("ChiTietHD_Xuat", "IDXuat"), "PX_");

        }
    }
}
