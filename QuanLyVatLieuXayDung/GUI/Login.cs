using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyVatLieuXayDung.GUI;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        string username = "";
        string password = "";
        string loaitk="";
        public Login()
        {
            InitializeComponent();
            skins();
            
        }

      
      
        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel thems = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            thems.LookAndFeel.SkinName = "Xmas 2008 Blue";

        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {


            if (txtMatKhau.Text.Length <= 0)
            {
                XtraMessageBox.Show("Bạn chưa nhập mật khẩu");
            }
            else if (txtDangNhap.Text.Length <= 0)
            {
                XtraMessageBox.Show("Bạn chưa nhập tên đăng nhập");
            }
            else if( BUS.AcountcsBUS.Instance.kiemtrataikhoanguoidung(txtDangNhap.Text) &&  !BUS.AcountcsBUS.Instance.kiemtramatkhau(BUS.AcountcsBUS.Instance.mahoamatkhau(txtMatKhau.Text)) )
            {
                XtraMessageBox.Show("mật khẩu sai");
            }
            else
            {


                if (BUS.AcountcsBUS.Instance.kiemtrataikhoanactive(txtDangNhap.Text))
                {


                    if (login())
                    {


                        if (BUS.AcountcsBUS.Instance.kiemtrataikhoanadmin(txtDangNhap.Text))
                        {
                            loaitk = "1";
                        }


                        else if (BUS.AcountcsBUS.Instance.kiemtraquyenquanly(txtDangNhap.Text))
                        {
                            loaitk = "2";
                        }

                        else
                        {
                            loaitk = "0";
                        }
                        string manv = BUS.AcountcsBUS.Instance.laymanv(txtDangNhap.Text, txtMatKhau.Text);
                        string tenv = BUS.AcountcsBUS.Instance.laytennv(txtDangNhap.Text, txtMatKhau.Text);

                        s f = new s(username, manv, tenv, loaitk);


                        f.Show();
                        this.Hide();
                    }

                    else
                    {
                        XtraMessageBox.Show("Sai thong tin tai khoan hoac mat khau");

                    }
                }
                else
                {
                    XtraMessageBox.Show("Tài Khoản Bạn Đã Bị Khóa !");
                }
            }
        }
              
            
        
       
         public bool login()
        {
            username = txtDangNhap.Text;
            password = txtMatKhau.Text;
            if (BUS.AcountcsBUS.Instance.login(username, password))
                return true;
            else
                return false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtMatKhau.Properties.UseSystemPasswordChar = true;
        }

        private void checkhienthi_CheckedChanged(object sender, EventArgs e)
        {
            if(!checkhienthi.Checked)
            {

                txtMatKhau.Properties.UseSystemPasswordChar = true;

            }
            else
            {
                txtMatKhau.Properties.UseSystemPasswordChar = false;
            }
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtDangNhap.Text = "";
            txtMatKhau.Text = "";
        }
    }
}