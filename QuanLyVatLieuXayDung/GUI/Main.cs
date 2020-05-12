using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using QuanLyVatLieuXayDung.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyVatLieuXayDung
{
    public partial class s : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string user="";
        string loaitk="";
        string tennv = "";
        string manv = "";
       
        public s(string user,string manv,string tennv,string loaitk)
        {
            InitializeComponent();
            skins();
            this.user = user;
            this.loaitk = loaitk;
            this.tennv=tennv;
            this.manv = manv;
           
           
          
        }
        public s()
        {

            InitializeComponent();
         

            skins();
        }
        public void skins()
        
    
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel thems = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            thems.LookAndFeel.SkinName = "Xmas 2008 Blue";
           
        }
       

        public Form kiemtratontai(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if(f.GetType()==ftype)
                {
                    return f;
                }
            }
            return null;
        }



        private void skinRibbonGalleryBarItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void s_Load(object sender, EventArgs e)
        {

            btntendangnhap.Caption = "Chào " + user;
          
            if (loaitk=="1")
            {
                btnNhanVien.Enabled = true;
                btnHangHoa.Enabled = true;
                btnKho.Enabled = true;
                btnNhaCungCap.Enabled = true;
                btnThongTinTaiKhoan.Enabled = true;
                btnNhapHang.Enabled = true;
                btnXuatHang.Enabled = true;
                BtnLoaiHang.Enabled = true;
                BtnDachSachKH.Enabled = true;
                btnGiaoDien.Enabled = true;
                btnKho2.Enabled = true;


            }
            if(loaitk=="0")
            {
                btnKho.Enabled = true;
                BtnDachSachKH.Enabled = true;
                btnXuatHang.Enabled = true;
                btnNhapHang.Enabled = true;
                btnThongTinTaiKhoan.Enabled = false;
                btnNhanVien.Enabled = false;
                BtnLoaiHang.Enabled = false;
                btnHangHoa.Enabled = false;
                btnNhaCungCap.Enabled = false;
                btnGiaoDien.Enabled = false;
                btnKho.Enabled = true;
                btnKho2.Enabled = false;
               
                
            }
            if (loaitk=="2")
            {

                btnNhanVien.Enabled =false;
                btnHangHoa.Enabled = true;
                btnKho.Enabled = false;
                btnNhaCungCap.Enabled = true;
                btnThongTinTaiKhoan.Enabled = false;
                btnNhapHang.Enabled = true;
                btnXuatHang.Enabled =false;
                BtnLoaiHang.Enabled = true;
                BtnDachSachKH.Enabled = false;
                btnGiaoDien.Enabled = false;
              btnKho2.Enabled = true;
               
              

            }
        }
       
     
       

        private void btnDangxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult rs;
            rs = XtraMessageBox.Show("ban có đăng xuất   không", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (rs == DialogResult.Yes)
            {
                this.Close();
                Login f = new Login();
                f.Show();
            }
        }

        
        private void btnKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

           
            panelControl1.Controls.Clear();
            TaoHoaDonXuat hoadonxuat = new TaoHoaDonXuat(manv, tennv, loaitk);
            hoadonxuat.Show();
            hoadonxuat.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(hoadonxuat);

        }

        private void btnThongTinTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            panelControl1.Controls.Clear();
            panelControl1.Dock = DockStyle.Fill;
            QuanTriNgD qtr = new QuanTriNgD();
            qtr.Show();
            qtr.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(qtr);
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            cnNhanVien frm = new cnNhanVien();
            frm.Show();
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
        }

        private void btnNhaCungCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Dock = DockStyle.Fill;
            NhaCungCap ncc = new NhaCungCap();
            ncc.Show();
            ncc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ncc);
        }

        private void BtnLoaiHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Dock = DockStyle.Fill;
            ThongTinLoaiHang loaihang = new ThongTinLoaiHang();
            loaihang.Show();
            loaihang.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(loaihang);
        }

        private void btnHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            panelControl1.Controls.Clear();
            panelControl1.Dock = DockStyle.Fill;
            ThongTinHangHoa hanghoa = new ThongTinHangHoa();
            hanghoa.Show();
            hanghoa.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(hanghoa);
        }

        private void btnNhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            panelControl1.Controls.Clear();
            panelControl1.Dock = DockStyle.Fill;
            TaoHoaDonNhap loaihang = new TaoHoaDonNhap(true, "", loaitk, manv, tennv);
            loaihang.Show();
            loaihang.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(loaihang);
        }

        private void btnXuatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult rs;

            rs = XtraMessageBox.Show("Bạn Muốn Thoát Không", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btntendangnhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDskhachang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            panelControl1.Controls.Clear();
            KhachHangc kh = new KhachHangc();
            kh.Show();
            kh.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(kh);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            panelControl1.Controls.Clear();
            Kho kho = new Kho();
            kho.Show();
            kho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(kho);

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
        }
    }
}