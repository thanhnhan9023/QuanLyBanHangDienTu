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
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class ThongTinLoaiHang : DevExpress.XtraEditors.XtraUserControl

    {
        bool add = false, update = false;
        LoaiHang lh;
        string loai="0";
        public ThongTinLoaiHang()
        {
            InitializeComponent();
        }
        public void khoitao()
        {
           

             lh = new LoaiHang(txtMaLH.Text, txtTenLoaiHang.Text, txtDienGiai.Text,loai);
        }
        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }
        public void ThongTinLoaiHang_Load(object sender, EventArgs e)
        {
            hienthi(true);
            xemloaihang();
            bind();
            txtTenLoaiHang.Enabled = false;
        }
        public void bind()
        {
            txtMaLH.DataBindings.Clear();
            txtMaLH.DataBindings.Add("Text", dsLoaihang.DataSource, "MaLoai");
            txtTenLoaiHang.DataBindings.Clear();
            txtTenLoaiHang.DataBindings.Add("Text", dsLoaihang.DataSource, "TenLoai");
            txtDienGiai.DataBindings.Clear();
            txtDienGiai.DataBindings.Add("Text", dsLoaihang.DataSource, "DIENGIAI");


        }
        public void hienthi(bool t)
        {
           if(t)
            {
                txtMaLH.Enabled = false;
                txtDienGiai.Enabled = false;
                txtTenLoaiHang.Enabled = false;
                btnLuu.Enabled = false;
            }
            else
            {
                txtDienGiai.Enabled = true;
                txtTenLoaiHang.Enabled = true;
                btnLuu.Enabled = true;

            }

        } 
        public void xemloaihang()
        {
            LoaiHangBUS.Instance.xemloaihang(dsLoaihang);
            gridView1.Columns[0].Caption = "Mã Loại Hàng";
            gridView1.Columns[1].Caption = "Tên Loại Hàng";
            gridView1.Columns[2].Caption = "Diễn Giải";
            gridView1.Columns[3].Caption = "Tình Trạng";
        }

    public bool kiemtradulieu()
        {
            if(txtTenLoaiHang.Text.Length<=0)
            {
                XtraMessageBox.Show("Không Được Bỏ Trống Tên Loại Hàng");
                return false;
            }
            if (txtDienGiai.Text.Length <= 0)
            {
                XtraMessageBox.Show("Không Được Bỏ Trống Diễn Giải");
                return false;
            }
            else
                return true;
           
        }

        private void Lưu_Click(object sender, EventArgs e)
        {
            khoitao();
            if (add)
            {
                
                DialogResult rs;
                rs = XtraMessageBox.Show("Bạn có muốn Thêm  không", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (kiemtradulieu())
                {
                    if (rs == DialogResult.Yes)
                    {
                        if (BUS.LoaiHangBUS.Instance.them1loaihang(lh))
                        {
                            XtraMessageBox.Show("Thanh cong");
                            ThongTinLoaiHang_Load(sender, e);
                        }
                    }
                }
            }
            if(update)
            {

                DialogResult rs;
                rs = XtraMessageBox.Show("Bạn có muốn sửa  không", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (kiemtradulieu())
                {
                    if (rs == DialogResult.Yes)
                    {
                        if (BUS.LoaiHangBUS.Instance.sua1loaihang(lh))
                        {
                            XtraMessageBox.Show("Thanh Cong");
                            ThongTinLoaiHang_Load(sender, e);
                        }
                    }
                }
            }
        }
        public void resetvalues()
        {
            txtMaLH.Text = "";
            txtDienGiai.Text = "";
            txtTenLoaiHang.Text = "";
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            add = true;
            loai = "1";
            update = false;
            hienthi(false);
            resetvalues();
            if (gridView1.RowCount <= 0)
            {
                txtMaLH.Text = "LH001";
            }
            else
            {
                txtMaLH.Text = BUS.LoaiHangBUS.Instance.NextID();
            }
            ckTranThai.Checked = false;
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            update = true;
            add = false;
            hienthi(false);
            ckTranThai.Checked = false;
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ThongTinLoaiHang_Load(sender, e);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            khoitao();
            DialogResult rs;
            rs = XtraMessageBox.Show("Bạn Có Muốn Xóa  không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (rs == DialogResult.Yes)
            {
                if (!BUS.LoaiHangBUS.Instance.kiemtrakhoangoai(lh))
                {
                    if (BUS.LoaiHangBUS.Instance.xoa1loaihang(lh))
                    {
                        XtraMessageBox.Show("Xoa Thành Công");
                        ThongTinLoaiHang_Load(sender, e);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Không Được Phép Xóa Loại Hàng "+txtTenLoaiHang.Text);
                }
            }
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
        
        }

        private void ckTranThai_CheckedChanged(object sender, EventArgs e)
        {
            if(ckTranThai.Checked)
            {
                loai ="1";
            }
            else
            {
                loai ="0";
            }
        }
    }
}
