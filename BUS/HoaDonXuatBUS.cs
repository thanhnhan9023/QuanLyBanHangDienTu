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
  public  class HoaDonXuatBUS
    {


        private static HoaDonXuatBUS instance;
        public static HoaDonXuatBUS Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonXuatBUS();
                return instance;
            }
            private set { instance = value; }
        }
        public HoaDonXuatBUS() { }

        public void loadulieuhoadonxuat(GridControl data )
        {
            data.DataSource = HoaDonXuatDao.Instance.xemhoadonxuat();

        } 
        public void loadulieukh(ComboBox data)
        {
            data.DataSource = HoaDonXuatDao.Instance.loadulieukh();
            data.DisplayMember="TenKH";
            data.ValueMember = "MaKH";
        }
        public void loaddulieunv(ComboBox data)
        {
            data.DataSource = HoaDonXuatDao.Instance.loaddulieunhanvien;
            data.DisplayMember = "TenNV";
            data.ValueMember = "MANV";
        }
        public bool them1hoadonxuat(HoaDonXuat hd)
        {
            return HoaDonXuatDao.Instance.them1hoadonxuat(hd);
        }
        public bool sua1hoadonxuat(HoaDonXuat hd)
        {
            return HoaDonXuatDao.Instance.sua1hoadonxuat(hd);
        }
        public bool xoa1hoadonxuat(HoaDonXuat hd)
        {
            return HoaDonXuatDao.Instance.xoa1hoadonxuat(hd);
        }
        public void xemhoadonxuatnv(GridControl data,string manv)
        {
            data.DataSource = HoaDonXuatDao.Instance.xemhoadonxuatnv(manv);
        }
        public bool kiemtadulieuhoadonhap()
        {
            return HoaDonXuatDao.Instance.kiemtadulieuhoadonxuat();
        }
        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("HoaDon_Xuat", "MAHD_Xuat"), "HDX");

        }
    }
}