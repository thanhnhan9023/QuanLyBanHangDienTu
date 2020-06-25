using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Collections;

namespace DAO
{
    public class TaiKhoanDao
    {

        private static TaiKhoanDao instance;

        public static TaiKhoanDao Instance
        {
            get
            {
                if (instance == null) instance = new TaiKhoanDao();
                return instance;
            }
            private set { instance = value; }
        }
        private TaiKhoanDao() { }
        public bool kiemtrataikhoan(string username)
        {
            string sql = "select * from NguoiDung where UserName='" + username + "' and Active=1";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            return false;


        }

        public  string laymanv(string username,string password)
        {
            string mnanv = "";
                      string sql = "select MANV,QuanTriNguoiDung.UserName,PassWord from NguoiDung,QuanTriNguoiDung where    NguoiDung.UserName = QuanTriNguoiDung.UserName and QuanTriNguoiDung.UserName = '" + username+"' and PassWord = '"+  SHA256(password)+"' and Active = 1  ";
          
            DataTable data = Dataprovider.Instance.laydulieutubang(sql);
            foreach (DataRow item in data.Rows)
            {
               mnanv= item["MANV"].ToString();
            }
            return mnanv;
        }

        public string laytennv(string username, string password)
        {
            string mnanv = "";
            string sql = "select TenNV,QuanTriNguoiDung.UserName,PassWord from NguoiDung,QuanTriNguoiDung,NhanVien where    NguoiDung.UserName = QuanTriNguoiDung.UserName and NhanVien.MANV=QuanTriNguoiDung.MANV and QuanTriNguoiDung.UserName = '" + username + "' and PassWord = '" + SHA256(password) + "' and Active = 1  ";

            DataTable data = Dataprovider.Instance.laydulieutubang(sql);
            foreach (DataRow item in data.Rows)
            {
                mnanv = item["TenNV"].ToString();
            }
            return mnanv;
        }
        public bool Login(Account account)
        {



            string sql = "select QuanTriNguoiDung.UserName,PassWord,MANV from NguoiDung,QuanTriNguoiDung  where NguoiDung.UserName=QuanTriNguoiDung.UserName and QuanTriNguoiDung.UserName='"+account.Username+"' and PassWord='"+account.Password+"' and Active=1  ";


            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
        public bool kiemtraquyenquanly(string username)
        {
            string sql = "select * from NguoiDung where Loai =2 and UserName='"+username+"'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;

            }
            else
                return false;

        }

        public bool kiemtraquyenadmin(string username)
        {
            string sql = "select * from NguoiDung where Loai =1 and UserName='"+username+"'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;

            }
            else
                return false;
            }

        public string SHA256(string password)
        {
            try
            {
                SHA256Managed crypt = new SHA256Managed();
                string hash = string.Empty;
                byte[] crypyo = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
                foreach (byte item in crypyo)
                {
                    hash += item.ToString("x2");
                }
                return hash;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        

        public DataTable laydachsachtaikhoan()
        {
            string sql = "select UserName,(Case Loai when 1 then N'Quản Trị Người Dùng' when 2 then N'Quản Lý'   else N'Người Dùng' end ) as Loai,(Case Active when 1 then N'Hoạt Động ' else  N'Ngưng Hoạt Động 'end) as Active from NguoiDung ";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable loadcombox()
        {
            string sql = "select DISTINCT (Case Loai when 1 then N'Quản Trị Người Dùng' else N'Người Dùng' end) as Loai from NguoiDung ";
            return Dataprovider.Instance.laydulieutubang(sql);
        }

        public DataTable loadtheoloadcombox(string loai)
        {
            string sql = "select UserName,(Case Loai when 1 then N'Quản Trị Người Dùng' when 2 then N'Quản Lý' else N'Người Dùng' end ) as Loai,(Case Active when 1 then N'Hoạt Động ' else  N'Ngưng Hoạt Động 'end) as Active from NguoiDung where Loai=" + loai + "";
            return Dataprovider.Instance.laydulieutubang(sql);
        }




       
        public bool resetpassword(Account account)
        {
            string sql = "update NguoiDung set PassWord = '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92' where UserName = '" + account.Username + "'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool them1taikhoan(Account account)
        {
            string sql = "insert into NguoiDung values('"+account.Username+"','"+SHA256(account.Password)+"','"+account.Loai+"','"+account.Active.ToString()+"')";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
                
        } 
        public bool sua1taikhoan(Account account)
        {
           string sql = "update NguoiDung set PassWord='"+SHA256(account.Password)+"',Loai='"+account.Loai+"' where UserName='"+account.Username+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool xoa1taikhoan(Account account)
        {

            string sql = "delete from NguoiDung where UserName='"+account.Username+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);   

         } 
        public bool kiemtratrungusername(string username)
        {

            string sql = "select * from NguoiDung where UserName='"+username+"'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }
        public bool kiemtramatkhau(string password)
        {

            string sql = "select * from NguoiDung where PassWord='"+password+"'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            else
                return false;


        }
        public bool kiemtratrungtennhanvien(string manv)
        {

            string sql = "select  *  from QuanTriNguoiDung,NhanVien where  QuanTriNguoiDung.MANV=NhanVien.MANV and NhanVien.MANV='" + manv+"'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            else
                return false;

        }

    }
}
