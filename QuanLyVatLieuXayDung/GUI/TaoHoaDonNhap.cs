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
    public partial class TaoHoaDonNhap : DevExpress.XtraEditors.XtraUserControl
    {
        bool add = false, update = false;
        bool loai;
        HoaDonNhap hoadon;
        bool tinhtrang;
        string mahd;
       string loaitk="";
        string tennv;
        string manv;


        public TaoHoaDonNhap(bool t,string mahoadon,string loaitk,string manv,string tennv)
        {
            InitializeComponent();
            this.loaitk = loaitk;
            tinhtrang = t;
            mahd = mahoadon;
            this.tennv = tennv;
            this.manv = manv;
            lblNhanVien.Text = tennv;
        }

        public TaoHoaDonNhap()
        {
            InitializeComponent();
            
          
        }
            public void hienthi(bool t)
        {
            if(t)
            {
                txtSoHD.Enabled = false;
                btnLuu.Enabled = false;
                dateNgayLap.Enabled = false;
                ckTrangThai.Enabled = false;
            }
            else
            {
                btnLuu.Enabled = true;
                dateNgayLap.Enabled = true;
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public void resetvalues()
        {
            txtSoHD.Text = "";
            
          
        }
        public void khoitao()
        {
            hoadon = new HoaDonNhap();
            hoadon.Mahd = txtSoHD.Text;
            hoadon.Mancc = cboNhacc.SelectedValue.ToString();

            hoadon.Ngaylap = Convert.ToDateTime(dateNgayLap.EditValue.ToString());
           
                hoadon.Manv = manv;
            
            hoadon.Tinhtrang = loai;
        }
        public void loaddulieuchonv()
        {
            BUS.HoaDonNhapBUS.Instance.laydulieuhoadonnhapchonv(dsHoaDon, manv);
        }
        public void TaoHoaDonNhap_Load(object sender, EventArgs e)
        {
            if (loaitk=="0")
            {
                loaddulieuchonv();
                loadcomboxncc();
                //loadcomboxNhanVien();
                binds();
                hienthi(true);
                lbl.Visible = false;
                lblNhanVien.Text = tennv;
                cboNhanVien.Visible = false;

            }
            else if (loaitk == "2")
            {
                loaddulieuchonv();
                loadcomboxncc();
                //loadcomboxNhanVien();
                binds();
                hienthi(true);
                lbl.Visible = false;
                lblNhanVien.Text = tennv;
                cboNhanVien.Visible = false;
            }
            else
            {
                loaddulieu();
                loadcomboxncc();
                //loadcomboxNhanVien();
                binds();
                hienthi(true);
                lbl.Visible = false;
                lblNhanVien.Text = tennv;
                //cboNhanVien.Visible = true;
                cboNhanVien.Visible = false;


            }
           
            
        }
      public void binds()
        {
            txtSoHD.DataBindings.Clear();
            txtSoHD.DataBindings.Add("Text", dsHoaDon.DataSource, "MAHD_Nhap");
            cboNhacc.DataBindings.Clear();
            cboNhacc.DataBindings.Add("Text", dsHoaDon.DataSource, "TenNCC");
            dateNgayLap.DataBindings.Clear();
            dateNgayLap.DataBindings.Add("Text",dsHoaDon.DataSource, "NgayLapHD");
            cboNhanVien.DataBindings.Clear();
            cboNhanVien.DataBindings.Add("Text",dsHoaDon.DataSource, "TenNV");
         
        }
      public void loaddulieu()
        {
            BUS.HoaDonNhapBUS.Instance.laydulieuhoadonnhap(dsHoaDon);
        }
        public void loadcomboxncc()
        {
            BUS.HoaDonNhapBUS.Instance.loadcomboxncc(cboNhacc);
        }
        public  void   loadcomboxNhanVien()
        {
            BUS.HoaDonNhapBUS.Instance.loadcomboxnhanvien(cboNhanVien);
        }
        public void laygiatri()
        {
          
           
        }
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
          
            if (gridView1.RowCount <= 0)
            {
                XtraMessageBox.Show("Chưa có hóa đơn nhập  nào");
            }
            else
            {
                string tenncc = gridView1.GetFocusedRowCellValue("TenNCC").ToString();
                string tennv = gridView1.GetFocusedRowCellValue("TenNV").ToString();
                string mahd = gridView1.GetFocusedRowCellValue("MAHD_Nhap").ToString();
                string tinhtrang = gridView1.GetFocusedRowCellValue("TinhTrangNhap").ToString();

                ChiTietHoaDonNhap from = new ChiTietHoaDonNhap(dateNgayLap.DateTime.ToString(), tenncc, tennv, mahd, tinhtrang);
                from.ShowDialog();
            }
        }

        private void lblTenNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            resetvalues();
            hienthi(false);
          
            dateNgayLap.EditValue = DateTime.Now;
           
            if (!BUS.HoaDonNhapBUS.Instance.kiemtadulieuhoadonhap())
            {
                txtSoHD.Text = "HD001";
            }
            else
            {
               txtSoHD.Text= BUS.HoaDonNhapBUS.Instance.NextID();
            }
           
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
                loai = true;
            }
            else
                loai = false;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            khoitao();
            if(add)
            {
                if(BUS.HoaDonNhapBUS.Instance.them1hoadon(hoadon))
                {
                    XtraMessageBox.Show("Thành Công");
                    TaoHoaDonNhap_Load(sender, e);
                }
            }
            if(update)
            {
                if(BUS.HoaDonNhapBUS.Instance.sua1hoadon(hoadon))
                {
                    XtraMessageBox.Show("Thành Công");
                    TaoHoaDonNhap_Load(sender, e);
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
            if (BUS.HoaDonNhapBUS.Instance.kiemtrakhoangoaihoadonhap(hoadon))
            {
                XtraMessageBox.Show("Không Được Phép Xóa");
            }
            else
            {
                if (BUS.HoaDonNhapBUS.Instance.xoa1hoandon(hoadon))
                {
                    XtraMessageBox.Show("Thành Công");
                    TaoHoaDonNhap_Load(sender, e);
                }
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TaoHoaDonNhap_Load(sender, e);
        }

        private void lblNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TaoHoaDonNhap_Load(sender, e);
        }

     
    }
}
