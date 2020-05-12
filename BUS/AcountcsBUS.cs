using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using DAO;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;

namespace BUS
{
    public class AcountcsBUS
    {
        Account acount;
        private static AcountcsBUS instance;
        public static AcountcsBUS Instance
        {
            get
            {
                if (instance == null) instance = new AcountcsBUS();
                return instance;
            }
            private set { instance = value; }
        }

        public bool login(string username, string password)
        {
            acount = new Account(username, TaiKhoanDao.Instance.SHA256(password),"",true);

            return TaiKhoanDao.Instance.Login(acount);

        }
      

      public void xemtaikhoangnguoidung(GridControl data)
        {
            data.DataSource = TaiKhoanDao.Instance.laydachsachtaikhoan();
        }
        public void loadcombox(System.Windows.Forms.ComboBox data)
        {
            data.DataSource = TaiKhoanDao.Instance.loadcombox();
           
            data.DisplayMember = "Loai";
            data.ValueMember = "Loai";
        }
      public void loadtheocombox(string loai,GridControl data)
        {
            data.DataSource=TaiKhoanDao.Instance.loadtheoloadcombox(loai);
        }


        public bool kiemtrataikhoanactive(string username)
        {
            return TaiKhoanDao.Instance.kiemtrataikhoan(username);
        }
        public bool resetPassWord(Account account)
        {
            return TaiKhoanDao.Instance.resetpassword(account);
        }

        public bool them1taikhoan(Account account)
        {
            return TaiKhoanDao.Instance.them1taikhoan(account);
        }
        public  bool sua1taikhoan(Account account)
        {
            return TaiKhoanDao.Instance.sua1taikhoan(account);
        }
        public bool xoa1taikhoan(Account account)
        {
            return TaiKhoanDao.Instance.xoa1taikhoan(account);    

        }
        public string laymanv(string username,string password)
        {
           string manv="";
            manv= TaiKhoanDao.Instance.laymanv(username,password);
            return manv;
        }
        public string laytennv(string username, string password)
        {
            string tennv = "";
            tennv= TaiKhoanDao.Instance.laytennv(username, password);
            return tennv;
        }
        public bool kiemtrataikhoanadmin(string usernmae)
        {

            return TaiKhoanDao.Instance.kiemtraquyenadmin(usernmae);
            

        }
        public bool kiemtraquyenquanly(string username)
        {
            return TaiKhoanDao.Instance.kiemtraquyenquanly(username);
        }
        public bool kiemtratrungusername(string username)
        {
            return TaiKhoanDao.Instance.kiemtratrungusername(username);
        }
        public bool kiemtratrungtennhanvien( string manv)
        {
            return TaiKhoanDao.Instance.kiemtratrungtennhanvien( manv);
        }

    }
}
