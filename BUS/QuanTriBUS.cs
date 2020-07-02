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
    public class QuanTriBUS
    {
        private static QuanTriBUS instance;
        public static QuanTriBUS Instance
        {
            get
            {
                if (instance == null) instance = new QuanTriBUS();
                return instance;
            }
            private set { instance = value; }
        }

        public QuanTriBUS() { }



        public void laydulieuquantri(GridControl data)
        {
            data.DataSource = QuanTriDao.Instance.laydulieuquantri();
        }
        public void laydulieuusername(ComboBox data)
        {
            data.DataSource = QuanTriDao.Instance.loadulieuusernam();
            data.DisplayMember = "UserName";
            data.ValueMember = "UserName";
        }
        public string laydulieuchucvu(string ma)
        {
            return QuanTriDao.Instance.laydulieuchucvu(ma);
        }
        
        public void laydulieutennv(ComboBox data)
        {
            data.DataSource = QuanTriDao.Instance.laydulieutennv();
            data.DisplayMember = "TenNV";
            data.ValueMember = "MANV";
        }
        public bool them1quantringuoidung(AccoutQuanTri accountqt)
        {
            return QuanTriDao.Instance.them1quantringuoidung(accountqt);
        }
        public bool kiemtrausernamektrung(string username)
        {
            return QuanTriDao.Instance.kiemtrausernamektrung(username);
        }
        public bool sua1quantringuoidung(AccoutQuanTri accountqt)
        {
            return QuanTriDao.Instance.sua1quantringuoidung(accountqt);
        }
        public bool xoa1quantringuoidung(AccoutQuanTri accountqt)
        {
            return QuanTriDao.Instance.xoa1quantringuoidung(accountqt);
        }
        public string  laydulieumachucvu(string ma)
        {
            return QuanTriDao.Instance.laymachucvu(ma);
        }
        //public bool updatetraithaitaikhoan(AccoutQuanTri accountqt, bool trangthai)
        //{
        //    return QuanTriDao.Instance.updatetraithaitaikhoan(accountqt, trangthai);
        //}

        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("QuanTriNguoiDung ", "ID_I"),"ID_ND");

        }

    }
}
