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
using DevExpress.XtraReports.UI;
using QuanLyVatLieuXayDung.Report;
using BUS;
using DT0;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class ChiTietHoaDonNhap : DevExpress.XtraEditors.XtraForm
    {
        ChiTietHDNhap chitiethd;
        bool add = false, update=false;
            double thanhtien = 0;
        string tinhtrang = "";
     
        public ChiTietHoaDonNhap(string ngaylap,string tennc,string tennv,string mahd,string tinhtrang)
        {
            InitializeComponent();
            lblNgayLap.Text = ngaylap;
            lblNhaCungCap.Text = tennc;
            lblNhanVien.Text = tennv;
            lblMaHoaDon.Text = mahd;
            this.tinhtrang = tinhtrang;
          
        
          

        }
        public void hienthi(bool t)
        {
           if(t)
            {
                txtSoLuong.Enabled = false;
                btnLuu.Enabled = false;
                txtDonGia.Enabled = false;
                cboDonVi.Enabled = false;
                cktinhtrang.Enabled = false;

            }
           else
            {
                btnLuu.Enabled = true;
                txtSoLuong.Enabled = true;
                txtDonGia.Enabled = true;
                txtDonGia.Enabled = true;
               
            }
        }

        public void ChiTietHoaDonNhap_Load(object sender,EventArgs e)
        { 
          if(tinhtrang== "Hoàn Thành")
            {
                cktinhtrang.Checked = true;
            }
          else
            {
                cktinhtrang.Checked = false;
            }
               
            hienthi(true);
            laydulieuchitiethd();
            loaddulieucomboxhh();
            loadcomboxdonvitheohh();
            bind();
            
        }
        public void laydulieuchitiethd()
        {
            BUS.ChiTietHDBUScs.Instance.laydachsachchitiethd(dsChiTiethdnhap,lblMaHoaDon.Text);
        }
        public void loaddulieucomboxhh()
        {
            BUS.ChiTietHDBUScs.Instance.loadcomboxhh(cboHangHoa);
        }
        public void loadcomboxdonvitheohh()
        {
            BUS.ChiTietHDBUScs.Instance.loadcomboxdonvi(cboDonVi,cboHangHoa.SelectedValue.ToString());
        }

        public void bind()
        {
            lblchiTietPhieuNhap.DataBindings.Clear();
            lblchiTietPhieuNhap.DataBindings.Add("Text",dsChiTiethdnhap.DataSource,"ID_Nhap");
            cboHangHoa.DataBindings.Clear();
            cboHangHoa.DataBindings.Add("Text", dsChiTiethdnhap.DataSource, "TENHH");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text",dsChiTiethdnhap.DataSource,"SoLuong_Nhap");
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text",dsChiTiethdnhap.DataSource,"DonGia_Nhap");
            cboDonVi.DataBindings.Clear();
            cboDonVi.DataBindings.Add("Text",dsChiTiethdnhap.DataSource,"DonViTinh");
                
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
            txtSoLuong.Text = ""; 
            txtDonGia.Text = "";
            DataTable dt = new DataTable();
                       
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            resetavalues();
            hienthi(false);
            thanhtien = 0;
            if (BUS.ChiTietHDBUScs.Instance.kiemtradulieuhdnhap())
            {
                lblchiTietPhieuNhap.Text = BUS.ChiTietHDBUScs.Instance.NextID();
            }
            else
            {
                lblchiTietPhieuNhap.Text = "HDN001";
            }
                       
        }

        private void cboHangHoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadcomboxdonvitheohh();
        }

   

    
        public bool kiemtrasoint(string x)
        {
            int a=0;
            bool t = int.TryParse(x,out a);
            if (t)
                return true;
            else
                return false;
        }
        public bool kiemtrafloat(string x)
        {
            float a = 0;
            bool t = float.TryParse(x, out a);
            if (t)
                return true;
            else
                return false;

        }
        private void txtDonGia_EditValueChanged(object sender, EventArgs e)
        {
            if(txtSoLuong.Text.Length>0 && txtDonGia.Text.Length>0 && kiemtrasoint(txtSoLuong.Text) && kiemtrafloat(txtDonGia.Text))
            {
                thanhtien = int.Parse(txtSoLuong.Text) * double.Parse(txtDonGia.Text);

            }
            if(txtSoLuong.Text==""  || txtDonGia.Text=="")
            {
                thanhtien = 0;
            }
            lblThanhTien.Text = thanhtien.ToString();
        }
        public void khoitao()
        {
            chitiethd = new ChiTietHDNhap();
            chitiethd.ID_Nhap1=lblchiTietPhieuNhap.Text;
            chitiethd.Mahh = cboHangHoa.SelectedValue.ToString();
            chitiethd.Mahd = lblMaHoaDon.Text;
            chitiethd.Soluong = int.Parse(txtSoLuong.Text);
            chitiethd.Dongianhap = double.Parse(txtDonGia.Text);
            chitiethd.Thanhtien = thanhtien;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            khoitao();
            if(BUS.ChiTietHDBUScs.Instance.xoa1chitiethoadon(chitiethd))
            {
                XtraMessageBox.Show("Thành Công");
                ChiTietHoaDonNhap_Load(sender, e);
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
            ChiTietHoaDonNhap_Load(sender, e);
        }

        private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text.Length > 0 && txtDonGia.Text.Length > 0  && kiemtrasoint(txtSoLuong.Text) && kiemtrafloat(txtDonGia.Text) )
            {
                thanhtien = int.Parse(txtSoLuong.Text) * double.Parse(txtDonGia.Text);

            }
            if (txtSoLuong.Text == "" || txtDonGia.Text == "")
            {
                thanhtien = 0;
            }
            lblThanhTien.Text = thanhtien.ToString();
        }

        private void cboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            
            InChiTietHDNhap rpt = new InChiTietHDNhap(lblMaHoaDon.Text, lblNhaCungCap.Text,lblNgayLap.Text,"");
          
            rpt.ShowPreviewDialog();
        }

        public bool kiemtradulieuhople()
        {
            if (txtSoLuong.Text.Length<=0)
            {
                XtraMessageBox.Show("Không Được Để Trống Số Lượng");
                return false;
            }

            if (txtDonGia.Text.Length<=0)
            {
                XtraMessageBox.Show("Không Được Để Trống Đơn Giá");
                return false;
            }
            if(!kiemtrafloat(txtDonGia.Text))
            {
                XtraMessageBox.Show("Nhập Đơn Giá Là Số");
                return false;
            }
            if (!kiemtrasoint(txtSoLuong.Text))
            {
                XtraMessageBox.Show("Nhập Số Lượng Là Số");
                return false;
            }

            return true;
        }

        private void cktinhtrang_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if(add)
            {
                if (kiemtradulieuhople())
                {
                    khoitao();
                    int soluongnhap = int.Parse(txtSoLuong.Text);
                    double dongianhap = double.Parse(txtDonGia.Text);
                    if (soluongnhap < 0)
                    {
                        XtraMessageBox.Show("Số Lượng Nhập Phải Lớn Hơn 0");
                    }
                    else if (dongianhap < 0)
                    {
                        XtraMessageBox.Show("Đơn Giá Nhập Phải Lớn Hơn Không");
                    }
                    else
                    {
                        if (BUS.ChiTietHDBUScs.Instance.them1chitiethoadon(chitiethd))
                        {
                            XtraMessageBox.Show("Thành Công");


                            ChiTietHoaDonNhap_Load(sender, e);


                        }
                    }
                }
            }
            if(update)
            {
               
                if (kiemtradulieuhople())
                {
                    khoitao();
                    int soluongnhap = int.Parse(txtSoLuong.Text);
                    double dongianhap = double.Parse(txtDonGia.Text);
                    if (soluongnhap < 0)
                    {
                        XtraMessageBox.Show("Số Lượng Nhập Phải Lớn Hơn 0");
                    }
                    else if (dongianhap < 0)
                    {
                        XtraMessageBox.Show("Đơn Giá Nhập Phải Lớn Hơn Không");
                    }
                    else
                    {
                        
                            if (BUS.ChiTietHDBUScs.Instance.sua1chitiethoadon(chitiethd))
                            {
                                XtraMessageBox.Show("Thành Công");
                                ChiTietHoaDonNhap_Load(sender, e);
                            }
                     }
                }
            }
                    
        }
    }
}