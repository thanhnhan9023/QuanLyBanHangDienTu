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
using BUS;
using DT0;
using QuanLyVatLieuXayDung.Report;
using DevExpress.XtraReports.UI;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class ChiTietHoaDonXuat : DevExpress.XtraEditors.XtraForm
    {
        ChiTietXuatHD chitiethd;
        bool add = false, update=false;
        double thanhtien = 0;
        string tinhtrang = "";
      
        public ChiTietHoaDonXuat(string mahdxuat,string tenkhachang,string sodienthoaikh,string ngaylaphoadon,string diachi,string tennv,string tinhtrang)
        {
            InitializeComponent();
            lblMaHoaDon.Text = mahdxuat;
            lblTenKhachHang.Text = tenkhachang;
            lblDiaChi.Text = diachi;
            lblSoDienThoai.Text = sodienthoaikh;
            lblNgayLap.Text = ngaylaphoadon;
            lblNhanVien.Text = tennv;
            this.tinhtrang = tinhtrang;
           

     

        }
        public void hienthi(bool t)
        {
           if(t)
            {
                txtSoLuongKho.Enabled = false;
                btnLuu.Enabled = false;
                txtDonGiaNhap.Enabled = false;
                txtDonGiaXuat.Enabled = false;
                txtSoLuongXuat.Enabled = false;
                ckTinhTrang.Enabled = false;

            }
           else
            {
                btnLuu.Enabled = true;
                txtDonGiaXuat.Enabled = true;
                txtSoLuongXuat.Enabled = true;
           
               
            }
        }

        public void laydulieuchitiethoadonxuat()
        {
            BUS.ChiTietHDXuatBUS.Instance.laydulieuchitiethdxuat(dsChiTiethdXuat,lblMaHoaDon.Text);
        }
        public void laydulieuhannghoa()
        {
            BUS.ChiTietHDXuatBUS.Instance.laydulieuhanghoa(cboHangHoa);
        }
        public void ChiTietHoaDonXuat_Load(object sender,EventArgs e)
        {
           
            laydulieuhannghoa();
            laydulieuchitiethoadonxuat();
            txtSoLuongKho.Text = BUS.ChiTietHDXuatBUS.Instance.laysoluongtonkho(cboHangHoa.SelectedValue.ToString());
            txtDonGiaNhap.Text = BUS.ChiTietHDXuatBUS.Instance.laygianhap(cboHangHoa.SelectedValue.ToString());
            lblXuatXu.Text = BUS.ChiTietHDXuatBUS.Instance.laydulieuxuatxu(cboHangHoa.SelectedValue.ToString());
            lblDonVi.Text = BUS.ChiTietHDXuatBUS.Instance.laydonvitinh(cboHangHoa.SelectedValue.ToString());
         
           
           
          if(tinhtrang=="Hoàn Thành")
            {
                ckTinhTrang.Checked = true;
            }
          else
            {
                ckTinhTrang.Checked = false;
            }
               
            hienthi(true);
          
            bind();
            
        }
      

        public void bind()
        {

            lblchiTietPhieuNhap.DataBindings.Clear();
            lblchiTietPhieuNhap.DataBindings.Add("Text", dsChiTiethdXuat.DataSource, "IDXuat");
            txtDonGiaXuat.DataBindings.Clear();
            txtDonGiaXuat.DataBindings.Add("Text",dsChiTiethdXuat.DataSource,"DonGia_Xuat");
            lblThanhTien.DataBindings.Clear();
            lblThanhTien.DataBindings.Add("Text",dsChiTiethdXuat.DataSource,"ThanhTienXuat");
            cboHangHoa.DataBindings.Clear();
            cboHangHoa.DataBindings.Add("Text",dsChiTiethdXuat.DataSource,"TenHH");
            txtSoLuongXuat.DataBindings.Clear();
            txtSoLuongXuat.DataBindings.Add("Text", dsChiTiethdXuat.DataSource, "SoLuong_Xuat");
          
                
        }
        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
          
        }
        public void resetavalues()
        {
            txtSoLuongXuat.Text = "";
            txtDonGiaXuat.Text = "";
                       
        }

       

        private void cboHangHoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSoLuongKho.Text = BUS.ChiTietHDXuatBUS.Instance.laysoluongtonkho(cboHangHoa.SelectedValue.ToString());
            txtDonGiaNhap.Text = BUS.ChiTietHDXuatBUS.Instance.laygianhap(cboHangHoa.SelectedValue.ToString());
            lblXuatXu.Text = BUS.ChiTietHDXuatBUS.Instance.laydulieuxuatxu(cboHangHoa.SelectedValue.ToString());
            lblDonVi.Text = BUS.ChiTietHDXuatBUS.Instance.laydonvitinh(cboHangHoa.SelectedValue.ToString());
        }

   

    

      
        public void khoitao()
        {
            chitiethd = new ChiTietXuatHD();
            chitiethd.ID_HDXuat1 = lblchiTietPhieuNhap.Text;
            chitiethd.Mahdxuat = lblMaHoaDon.Text;
            chitiethd.Dongiaxuat =double.Parse( txtDonGiaXuat.Text);
            chitiethd.Soluongxuat = int.Parse(txtSoLuongXuat.Text);
            chitiethd.ThanhTien1 = double.Parse(lblThanhTien.Text);
            chitiethd.ID_Kho1 = BUS.ChiTietHDXuatBUS.Instance.laydulieuidkho(cboHangHoa.SelectedValue.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            khoitao();
            if(BUS.ChiTietHDXuatBUS.Instance.xoa1chitiethoadonxuat(chitiethd))
            {
                XtraMessageBox.Show("Thành Công");
                ChiTietHoaDonXuat_Load(sender, e);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
            add = false;
            hienthi(false);
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonXuat_Load(sender, e);
        }


        private void lblNhaCungCap_Click(object sender, EventArgs e)
        {

        }

        private void lblNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void labelControl18_Click(object sender, EventArgs e)
        {

        }

        private void txtSoLuongKho_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            resetavalues();
            hienthi(false);
            if(BUS.ChiTietHDXuatBUS.Instance.kiemtradulieuphieuxuat())
            {
                lblchiTietPhieuNhap.Text = BUS.ChiTietHDXuatBUS.Instance.NextID();
               
            }
            else {
                lblchiTietPhieuNhap.Text = "PX_001";

                } 
            
        }
        public bool kiemtradulieunhapvaolaso(string x)
        {
            int a = 0;
            bool t = int.TryParse(x, out a);
            if (t)
            {
                return true;
            }
            else
                return false;

        }

        public bool kiemtradulieunhapvaolasofloat(string x)
        {
            float a = 0;
            bool t = float.TryParse(x, out a);
            if (t)
            {
                return true;
            }
            else
                return false;

        }
        private void txtSoLuongXuat_EditValueChanged(object sender, EventArgs e)
        {
              if (txtSoLuongXuat.Text.Length > 0 && txtDonGiaXuat.Text.Length > 0  && kiemtradulieunhapvaolaso(txtSoLuongXuat.Text) && kiemtradulieunhapvaolasofloat(txtDonGiaXuat.Text))
            {
                thanhtien = int.Parse(txtSoLuongXuat.Text) * double.Parse(txtDonGiaXuat.Text);

            }
            if (txtSoLuongXuat.Text == "" || txtDonGiaXuat.Text == "")
            {
                thanhtien = 0;
            }
            lblThanhTien.Text = thanhtien.ToString();
        }

        private void txtDonGiaXuat_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSoLuongXuat.Text.Length > 0 && txtDonGiaXuat.Text.Length > 0 && kiemtradulieunhapvaolaso(txtSoLuongXuat.Text) && kiemtradulieunhapvaolasofloat(txtDonGiaXuat.Text))
            {
                thanhtien = int.Parse(txtSoLuongXuat.Text) * double.Parse(txtDonGiaXuat.Text);

            }
            if (txtSoLuongXuat.Text == "" || txtDonGiaXuat.Text == "")
            {
                thanhtien = 0;
            }
            lblThanhTien.Text = thanhtien.ToString();
        }

        private void txtDonGiaNhap_EditValueChanged(object sender, EventArgs e)
        {

        }

      
       

        private void cktinhtrang_CheckedChanged(object sender, EventArgs e)
        {

        }
        public bool kiemtradulieu()
        {
            if (txtSoLuongXuat.Text.Length <= 0)
            {
                XtraMessageBox.Show("Không Được Để Trống Số Lượng");
                return false;
            }

            if (txtDonGiaXuat.Text.Length <= 0)
            {
                XtraMessageBox.Show("Không Được Để Trống Đơn Giá");
                return false;
            }
            
            if (!kiemtradulieunhapvaolasofloat(txtDonGiaXuat.Text))
            {
                XtraMessageBox.Show("Nhập Đơn Giá Là Số");
                return false;
            }
            if (!kiemtradulieunhapvaolaso(txtSoLuongXuat.Text))
            {
                XtraMessageBox.Show("Nhập Số Lượng Là Số");
                return false;
            }

            return true;

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            ChiTietHDXuat2 rpt = new ChiTietHDXuat2(lblMaHoaDon.Text,lblDiaChi.Text,lblTenKhachHang.Text,lblSoDienThoai.Text,lblNhanVien.Text,lblNgayLap.Text);
            rpt.ShowPreviewDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
           
         
            if (add)
            {

                if (kiemtradulieu())
                {
                    khoitao();
                    int soluongkho = int.Parse(txtSoLuongKho.Text);
                    int soluongxuat = int.Parse(txtSoLuongXuat.Text);
                    double gianhapvao = double.Parse(txtDonGiaNhap.Text);
                    double giabanra = double.Parse(txtDonGiaXuat.Text);
                    
                    if(giabanra<gianhapvao)
                    {
                        XtraMessageBox.Show("Giá Bán Phải lớn hơn giá nhập");
                    }
                    else if (soluongxuat > soluongkho)
                    {
                        XtraMessageBox.Show("Số Lượng Xuất Không Lớn Hơn Số Lượng Kho");
                    }
                    else if(soluongxuat<0)
                    {
                        XtraMessageBox.Show("Số Lượng Xuất Phải Lớn Hơn 0");
                    }
                   
                    else if (soluongkho >= soluongxuat)
                    {
                        if (BUS.ChiTietHDXuatBUS.Instance.them1chitiethoadonxuat(chitiethd))
                        {
                            XtraMessageBox.Show("Thanh Cong");
                            ChiTietHoaDonXuat_Load(sender, e);
                        }
                    }

                    else
                    {
                        XtraMessageBox.Show("Hết Hàng");
                    }
                }
              }
                   
                
                
            
            if(update)
            {

                if (kiemtradulieu())
                {
                    khoitao();
                    int soluongkho = int.Parse(txtSoLuongKho.Text);
                    int soluongxuat = int.Parse(txtSoLuongXuat.Text);
                    double gianhapvao = double.Parse(txtDonGiaNhap.Text);
                    double giabanra = double.Parse(txtDonGiaXuat.Text);
                    if (giabanra < gianhapvao)
                    {
                        XtraMessageBox.Show("Giá Bán Phải lớn hơn giá nhập");
                    }
                    else if (soluongxuat > soluongkho)
                    {
                        XtraMessageBox.Show("Số Lượng Xuất Không Lớn Hơn Số Lượng Kho");
                    }

                    else if (soluongkho >= soluongxuat)
                    {
                        if (BUS.ChiTietHDXuatBUS.Instance.sua1chitiethoadonxuat(chitiethd))
                        {
                            XtraMessageBox.Show("Thanh Cong");
                            ChiTietHoaDonXuat_Load(sender, e);
                        }
                    }
                        
                    else
                    {
                    XtraMessageBox.Show("Hết Hàng");
                    }

                }
                    
        }
    }
        }
}