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
using DT0;
using BUS;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class TaoHoaDonXuat : DevExpress.XtraEditors.XtraUserControl
    {
        bool add = false, update = false;
        bool tinhtrang = false;
        HoaDonXuat hoadonxuat;
        string manv = "";
        string tennv = "";
        string loaitk = "";



        public void loaddulieuhoadonxuat()
        {
            BUS.HoaDonXuatBUS.Instance.loadulieuhoadonxuat(dsHoaDonXuat);
        }
        public TaoHoaDonXuat(string manv, string tennv, string loaitk)
        {
            InitializeComponent();
            this.tennv = tennv;
            this.manv = manv;
            this.loaitk = loaitk;


        }

        public void hienthi(bool t)
        {
            if (t)
            {
                txtSoHD.Enabled = false;
                btnLuu.Enabled = false;
                dateNgayXuat.Enabled = false;
                ckTrangThai.Enabled = false;

            }
            else
            {
                btnLuu.Enabled = true;
                dateNgayXuat.Enabled = true;
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public void resetvalues()
        {
            txtSoHD.Text = "";

            cboKhachHang.SelectedIndex = 0;
            if (loaitk == "2" || loaitk == "1")
            {
                cboNhanVien.SelectedIndex = 0;
            }


        }
        public void loaddulieukh()
        {
            BUS.HoaDonXuatBUS.Instance.loadulieukh(cboKhachHang);
        }
        public void loaddulieunv()
        {
            BUS.HoaDonXuatBUS.Instance.loaddulieunv(cboNhanVien);
        }
        public void khoitao()
        {
            hoadonxuat = new HoaDonXuat();
            hoadonxuat.Mahdxuat = txtSoHD.Text;
            hoadonxuat.Makh = cboKhachHang.SelectedValue.ToString();

            hoadonxuat.Manv = manv;

            hoadonxuat.NgayLap_Xuat1 = Convert.ToDateTime(dateNgayXuat.EditValue.ToString());
            hoadonxuat.Tinhtrangxuat1 = tinhtrang;
        }
        public void loaddulieuchonv()
        {
            HoaDonXuatBUS.Instance.xemhoadonxuatnv(dsHoaDonXuat, manv);
        }
        public void TaoHoaDonXuat_Load(object sender, EventArgs e)
        {

            if (loaitk == "0")
            {

                lblNhanVien.Visible = true;
                cboNhanVien.Visible = false;
                lblNhanVien.Text = tennv;
                lblTieude.Visible = true;
                loaddulieukh();
                loaddulieuchonv();
                binds();
                hienthi(true);


            }
           else if (loaitk == "2")
            {
                lblNhanVien.Visible = true;
                cboNhanVien.Visible = false;
                lblNhanVien.Text = tennv;
                lblTieude.Visible = true;
                loaddulieukh();
                loaddulieuchonv();
                binds();
                hienthi(true);
            }
            else

            {
                lblNhanVien.Visible = true;
                cboNhanVien.Visible = false;
                lblTieude.Visible = true;
                lblNhanVien.Text = tennv;
                lbl.Visible = false;
                loaddulieukh();
                loaddulieunv();
                loaddulieuhoadonxuat();
                binds();
                hienthi(true);

            }

        }
      public void binds()
        {
            txtSoHD.DataBindings.Clear();
            txtSoHD.DataBindings.Add("Text",dsHoaDonXuat.DataSource, "MAHD_Xuat");
            cboKhachHang.DataBindings.Clear();
            cboKhachHang.DataBindings.Add("Text",dsHoaDonXuat.DataSource, "TenKH");
            //if (loaitk=="1" || loaitk=="2")
            //    {
            //    cboNhanVien.DataBindings.Clear();
            //    cboNhanVien.DataBindings.Add("Text", dsHoaDonXuat.DataSource, "TenNV");
            //    }
            dateNgayXuat.DataBindings.Clear();
            dateNgayXuat.DataBindings.Add("Text",dsHoaDonXuat.DataSource, "NgayLap_Xuat");
                
            
         
        }
      
     

        private void lblTenNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            hienthi(false);
            resetvalues();
            dateNgayXuat.EditValue = DateTime.Now;
            if(!BUS.HoaDonXuatBUS.Instance.kiemtadulieuhoadonhap())
            {

                txtSoHD.Text = "HDX001";
             } 
            else
            txtSoHD.Text = BUS.HoaDonXuatBUS.Instance.NextID();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ckTrangThai_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTrangThai.Checked)
            {
                tinhtrang = true;
            }
            else
            {
                tinhtrang = false;
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            khoitao();
            if(add)
            {
              if(BUS.HoaDonXuatBUS.Instance.them1hoadonxuat(hoadonxuat))
                {
                    XtraMessageBox.Show("Thành công");
                    TaoHoaDonXuat_Load(sender, e);
                }
            }
            if(update)
            {
                if (BUS.HoaDonXuatBUS.Instance.sua1hoadonxuat(hoadonxuat))
                {
                    XtraMessageBox.Show("Thành công");
                    TaoHoaDonXuat_Load(sender, e);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
            add = false;
            hienthi(false);
            ckTrangThai.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            khoitao();
            if(BUS.HoaDonXuatBUS.Instance.xoa1hoadonxuat(hoadonxuat))
            {
                XtraMessageBox.Show("Thành công");
                TaoHoaDonXuat_Load(sender, e);
            }
          
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount <= 0)
            {
                XtraMessageBox.Show("Chưa Có Hóa Đơn Xuất Nào!");
            }
            else
            {
              ChiTietHoaDonXuat frm = new ChiTietHoaDonXuat(txtSoHD.Text, gridView1.GetFocusedRowCellValue("TenKH").ToString(), gridView1.GetFocusedRowCellValue("SDT").ToString(), dateNgayXuat.EditValue.ToString(), gridView1.GetFocusedRowCellValue("DiaChi").ToString(), gridView1.GetFocusedRowCellValue("TenNV").ToString(),gridView1.GetFocusedRowCellValue("TinhTrangXuat").ToString());
                frm.ShowDialog();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TaoHoaDonXuat_Load(sender, e);
        }

     
    }
}
