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
   public class NhanVienBUS
    {



        private static NhanVienBUS instance;
        public static NhanVienBUS Instance
        {
            get
            {
                if (instance == null) instance = new NhanVienBUS();
                return instance;
            }
            private set { instance = value; }
        }
        public void xem(GridControl data)
        {
            data.DataSource = NhanVienDao.Instance.xemdachsachNhanvien();
        }
        public bool them1nhanvien(NhanVienc nv)
        {

            return NhanVienDao.Instance.them1nhanvien(nv);
        }
        public bool sua1nhanvien(NhanVienc nv)
        {
            return NhanVienDao.Instance.sua1nhanvien(nv);
        }
        public bool xoa1nhanvien(NhanVienc nv)
        {
            return NhanVienDao.Instance.xoa1nhanvien(nv);
        }
        //public void xemnv(GridControl data)
        //{
        //    data.DataSource=NhanVienDao.Instance.xemnhanvien();
        //}


        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("NhanVien", "MANV"), "NV");

        }
        public  void loadcomboxgioitinh(ComboBox data)
        {
            data.DataSource = NhanVienDao.Instance.xemdachsachNhanvien();
            data.DisplayMember = "GioiTinh";
            data.ValueMember = "GioiTinh";
        }
        public void loadcomboxchucvu(ComboBox data)
        {

            data.DataSource = NhanVienDao.Instance.loaddulieucv();
            data.DisplayMember = "TenCv";
            data.ValueMember = "MaCv";
        }
        public string loadlcbt(string ten)
        {
           return NhanVienDao.Instance.loadlcbt(ten);
        }
        public void loaddulieuluong(GridControl data,string manv)
        {
            data.DataSource = NhanVienDao.Instance.loaddulieuluong(manv);
        }
        public bool updateluong(string manv,double luong,DateTime ngayketthuc)
        {

            return NhanVienDao.Instance.updateluong(manv,luong,ngayketthuc);
        }
        public bool suathongtinluong(string manv, DateTime ngaykethtuc,double luong)
        {

            return NhanVienDao.Instance.suathongtinluong(manv, ngaykethtuc,luong);
        }
        public bool capnhasaukhitinhluong(string manv)
        {

            return NhanVienDao.Instance.capnhasaukhitinhluong(manv);
        }
        public bool kiemtracapnhatluong(string manv)
        {
            return NhanVienDao.Instance.kiemtracapnhatluong(manv);
        }

        public bool kiemtrakhoangoaihoadonxuaatnhanvien(NhanVienc nv)
        {
            return NhanVienDao.Instance.kiemtrakhoangoaihoadonxuaatnhanvien(nv);
        }
        public bool kiemtrakhoangoaihoadonnhapnhanvien(NhanVienc nv)
        {
            return NhanVienDao.Instance.kiemtrakhoangoaihoadonnhhapnhanvien(nv);
        }
        public bool kiemtrakhoangoainguoidung(NhanVienc nv)
        {
            return NhanVienDao.Instance.kiemtrakhoangoaiquantringuoidung(nv);
        }
    }
}
