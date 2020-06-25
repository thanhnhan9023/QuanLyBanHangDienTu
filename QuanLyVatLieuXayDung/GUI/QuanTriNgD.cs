using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DT0;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class QuanTriNgD : DevExpress.XtraEditors.XtraUserControl
    {
        Account accoun;
        bool cohieu = false;
        bool add = false, update = false, trangthai = false;
        string loai = "0";
       
        public QuanTriNgD()
        {
            InitializeComponent();
        }

        public void QuanTriNgD_Load(object sender, EventArgs e)
        {
            hienthi(true);
            xemtaikhoan();
            loadcomboxtk();
            bind();
           
            txtPassWord.Properties.UseSystemPasswordChar = true;
            txtPasswordX2.Properties.UseSystemPasswordChar = true;


        }
        public void khoitao()
        {

            if (cboNguoiDung.SelectedItem.ToString() == "Quản Trị Người Dùng")
            {
                loai = "1";
            }
            else if (cboNguoiDung.SelectedItem.ToString() == "Quản Lý")
            {
                loai = "2";
            }
            else
                loai = "0";
            
            accoun = new Account(txtTaiKhoan.Text, txtPasswordX2.Text,loai, trangthai);
        }
        public void xemtaikhoan()
        {

            BUS.AcountcsBUS.Instance.xemtaikhoangnguoidung(dstaikhoan);

        }
        public void loadcomboxtk()
        {

        }
        public void bind()
        {
            txtTaiKhoan.DataBindings.Clear();
            txtTaiKhoan.DataBindings.Add("Text", dstaikhoan.DataSource, "UserName");
            cboNguoiDung.DataBindings.Clear();
            cboNguoiDung.DataBindings.Add("Text", dstaikhoan.DataSource, "Loai");
          
        }
        public void hienthi(bool t)
        {
            if (t)
            {
                txtPassWord.Enabled = false;
                txtTaiKhoan.Enabled = false;
                btnLuu.Enabled = false;
                
              
                txtPasswordX2.Enabled = false;
             
            }
            else
            {
                if(gridView1.RowCount>=0)
                {
                    cboNguoiDung.Enabled = true;
                   
                }
                txtPasswordX2.Enabled = true;
                txtPassWord.Enabled = true;
                txtTaiKhoan.Enabled = true;
                btnLuu.Enabled = true;
              
            }
        }
        public void hienthi2(bool t)
        {

            if (t)
            {
            
                txtPassWord.Enabled = false;
                
                
                txtPasswordX2.Enabled = false;

                btnLuu.Enabled = true;

            }
            else
            {
                txtTaiKhoan.Enabled = false;
                txtPasswordX2.Enabled = true;
                txtPassWord.Enabled = true;
                txtTaiKhoan.Enabled = true;
                btnLuu.Enabled = true;
             
            }


        }
        public void loadtheocombox()
        {
            BUS.AcountcsBUS.Instance.loadtheocombox(loai, dstaikhoan); 
       }
        public bool hamkiemtrahople(string x)
        {
            x = txtPassWord.Text;
            if(txtPasswordX2.Text==x)
            {
                return true;
            }
            return false;
        }



        private void cboNguoiDung_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboNguoiDung.SelectedItem.ToString() == "Quản Trị Người Dùng")
            {
                loai = "1";
            }
            else if(cboNguoiDung.SelectedItem.ToString()=="Quản Lý")
            {
                loai = "2";
            }
            else
            {
                loai = "0";
            }
            if (!cohieu)
            loadtheocombox();
            
         
       
        }
    

          

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            khoitao();
            DialogResult rs;
            rs = XtraMessageBox.Show("Bạn Có Muốn ResetPassWord","Có",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if(rs==DialogResult.Yes)
            {
                if (BUS.AcountcsBUS.Instance.resetPassWord(accoun))
                {
                    XtraMessageBox.Show("Thành Công");
                }
            }
        }

        public void resetvalues()
        {
            txtTaiKhoan.Text = "";
            txtPasswordX2.Text = "";
            txtPassWord.Text = "";
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            khoitao();
            if(add)
            {

                if (hamkiemtrahople(txtPassWord.Text))
                {
                    if (AcountcsBUS.Instance.kiemtratrungusername(txtTaiKhoan.Text))
                    {
                        XtraMessageBox.Show("Đã Tồn Tại Tên Đăng Nhập Này ");

                    }
                    else
                    {

                        if (BUS.AcountcsBUS.Instance.them1taikhoan(accoun))
                        {
                            XtraMessageBox.Show("Thanh Cong");
                            cohieu = false;
                            QuanTriNgD_Load(sender, e);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Mật Khẩu không Trùng Nhau");
                }
             }
            if(update)
            {
                if (hamkiemtrahople(txtPassWord.Text))
                {
                    if (BUS.AcountcsBUS.Instance.sua1taikhoan(accoun))
                    {
                        XtraMessageBox.Show("Thanh Cong");
                        cohieu = false;
                        QuanTriNgD_Load(sender, e);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Mật Khẩu không Trùng Nhau");
                }

            }
               
        }

        private void cboNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
            cohieu = true;
            add = false;
            txtTaiKhoan.Enabled = false;
            txtPasswordX2.Enabled = true;
            txtPassWord.Enabled = true;
            txtPassWord.Text = "";
            txtPasswordX2.Text = "";
            btnLuu.Enabled = true;
          
            
            
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            QuanTriNgD_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            khoitao();
            DialogResult rs;
            rs = XtraMessageBox.Show("Bạn Có Muốn Xóa Không", "Có", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Yes)
            {
                if(BUS.AcountcsBUS.Instance.xoa1taikhoan(accoun))
                {
                    XtraMessageBox.Show("Thành Công");
                    QuanTriNgD_Load(sender, e);
                }

            }
        }

        private void btnKichHoat_Click(object sender, EventArgs e)
        {
            string username = gridView1.GetFocusedRowCellValue("UserName").ToString();
            NhanVienND frm = new NhanVienND(username);
            frm.ShowDialog();
        }

        private void ckTrangThai_TextChanged(object sender, EventArgs e)
        {

         
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void ckTrangThai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            cohieu = true;
            resetvalues();
            hienthi(false);
        }
    }
}
