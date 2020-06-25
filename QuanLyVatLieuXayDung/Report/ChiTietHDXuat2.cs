using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyVatLieuXayDung.Report
{
    public partial class ChiTietHDXuat2 : DevExpress.XtraReports.UI.XtraReport
    {
        public ChiTietHDXuat2(string mahdxuat,string diachikhachhang,string tenkh,string sodtkh,string tennv,string ngayxuat)
        {
            InitializeComponent();
            this.chiTietHD_XuatTableAdapter.Fill(dataSet21.ChiTietHD_Xuat, mahdxuat);
            lblHoaDon.Text = mahdxuat;
            lblDiaChiKH.Text = diachikhachhang;
            lblTenKH.Text = tenkh;
            lblSoDienThoaiKH.Text = sodtkh;
            lblKhachHang2.Text = tenkh;
            lblTenNhanVien.Text = tennv;
            lblNgayXuat.Text = ngayxuat;
        }

    }
}
