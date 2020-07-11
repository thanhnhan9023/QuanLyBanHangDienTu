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

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class KhachHangc : DevExpress.XtraEditors.XtraUserControl
    {
        bool add = false, update = false;
        public KhachHangc()
        {
            InitializeComponent();
        }

        public void hienthi(bool t)
        {
            if (t)
            {
               // txtMaKhachHang.Enabled = t;
                txtTenKhachHang.Enabled = t;
                txtDiaChi.Enabled = t;
                txtSoDienThoai.Enabled = t;
                Btnluu.Enabled = t;
            }
            else
            {


                txtTenKhachHang.Enabled = t;
                txtDiaChi.Enabled = t;
                txtSoDienThoai.Enabled = t;
                Btnluu.Enabled = t;
            }
        }
        public void loadview()
        {
            KhachHangBUS.Instance.laydulieukh(dskhachang);
            gridView1.Columns[0].Caption = "Mã Khách Hàng";
            gridView1.Columns[1].Caption = "Tên Khách Hàng";
            gridView1.Columns[2].Caption = "Địa Chỉ";
            gridView1.Columns[3].Caption = "Số Điện Thoại";
        //  gridView1.Red
        }

        private void KhachHangc_Load(object sender, EventArgs e)
        {
            txtMaKhachHang.Enabled = false;
            hienthi(false);
            loadview();
           // bind();
          

        }

        public void resetvalue()
        {
            txtMaKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtTenKhachHang.Text = "";
            txtTenKhachHang.Focus();

        }
        public void bind()
        {
           
            txtMaKhachHang.DataBindings.Clear();
            txtMaKhachHang.DataBindings.Add("Text", dskhachang.DataSource, "MAKH");
            txtTenKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Add("Text", dskhachang.DataSource, "TenKH");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dskhachang.DataSource, "DiaChi");
            txtSoDienThoai.DataBindings.Clear();
            txtSoDienThoai.DataBindings.Add("Text", dskhachang.DataSource, "SDT");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            rs = XtraMessageBox.Show("Bạn Có Muốn Xóa Không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (rs == DialogResult.Yes)
            {
                if (BUS.KhachHangBUS.Instance.xoamotkhachang(txtMaKhachHang.Text))
                {
                    XtraMessageBox.Show("Thành Công");
                    KhachHangc_Load(sender, e);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            hienthi(true);
            txtMaKhachHang.Enabled = false;
            add = false;
            update = true;
            bind();
        }
        public bool kiemtraso(string x)
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
        private void Btnluu_Click(object sender, EventArgs e)
        {
            if (add)
            {
                //DialogResult rs;
                //rs = XtraMessageBox.Show("Bạn Có Muốn Thêm Không", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


                if (txtTenKhachHang.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Không Được Bỏ Trống Tên Khách Hàng");

                }
                else if (txtSoDienThoai.Text.Length<=0)
                {
                    XtraMessageBox.Show("Không Được Bỏ Trống SĐT");
                }
                else if (!kiemtraso(txtSoDienThoai.Text))
                {
                    XtraMessageBox.Show("Bạn phải nhập số tại mục số điện thoại");
                }
                else
                {
                    //if (rs == DialogResult.Yes)

                        if (BUS.KhachHangBUS.Instance.themmotkhachhang(txtMaKhachHang.Text, txtTenKhachHang.Text, txtDiaChi.Text, txtSoDienThoai.Text))
                        {
                            XtraMessageBox.Show("Thêm Thành Công");
                            KhachHangc_Load(sender, e);

                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm  Thất Bại");
                        }
                }
            }
            if (update)
            {
                if (txtTenKhachHang.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Không Được Bỏ Trống Tên Khách Hàng");

                }
                else if (txtSoDienThoai.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Không Được Bỏ Trống SĐT");
                }
                else if (!kiemtraso(txtSoDienThoai.Text))
                {
                    XtraMessageBox.Show("Bạn phải nhập số tại mục số điện thoại");
                }
                else
                {
                    DialogResult rs;
                    rs = XtraMessageBox.Show("Bạn có muốn sửa  không", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (rs == DialogResult.Yes)
                    {
                        if (BUS.KhachHangBUS.Instance.suamotkhachang(txtMaKhachHang.Text, txtTenKhachHang.Text, txtDiaChi.Text, txtSoDienThoai.Text))
                        {
                            XtraMessageBox.Show("Thành Công");
                            KhachHangc_Load(sender, e);
                        }
                        else
                        {
                            XtraMessageBox.Show("Thất Bại");
                        }
                    }
                }

            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            KhachHangc_Load(sender, e);
        }

        private void txtSoDienThoai_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTenKhachHang_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            resetvalue();
         //   txtMaKhachHang.Enabled = true;
            hienthi(true);
            if (gridView1.DataRowCount <= 0)
            {
                txtMaKhachHang.Text = "KH001";
            }
            else
            {
                txtMaKhachHang.Text = BUS.KhachHangBUS.Instance.NextID();
            }

        

        }
    }
}
