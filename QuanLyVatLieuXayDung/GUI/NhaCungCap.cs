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

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class NhaCungCap : DevExpress.XtraEditors.XtraUserControl
    {
        
        bool add = false, update = false;
        public NhaCungCap()
        {
            InitializeComponent();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            hienthi(true);
            loadnhacc();
            bind();
            Error.Clear();
        }
        public void hienthi(bool t)
        {
            if(t)
            {
                txtMaNhaCC.Enabled = false;
                txtDiaChi.Enabled = false;
                txtSDT.Enabled = false;
                txtTenNCC.Enabled = false;
                btnLuu.Enabled = false;
            }
            else
            {
               
                txtDiaChi.Enabled = true;
                txtSDT.Enabled =true;
                txtTenNCC.Enabled = true;
                btnLuu.Enabled = true;
            }
        }
        public void loadnhacc()
        {
            
            BUS.NhaCcBUS.Instance.laydulieunhacc(dsNhacc);
            gridView1.Columns[0].Caption = "Mã Nhà Cung Cấp";
            gridView1.Columns[1].Caption = "Tên Nhà Cung Cấp";
            gridView1.Columns[2].Caption = "Địa Chỉ Nhà Cung Cấp";
            gridView1.Columns[3].Caption = "Số Điện Thoại";
           
        }
        public void bind()
        {
            txtMaNhaCC.DataBindings.Clear();
            txtMaNhaCC.DataBindings.Add("Text", dsNhacc.DataSource, "MaNC");
            txtTenNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Add("Text", dsNhacc.DataSource, "TenNCC");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dsNhacc.DataSource, "DIACHI");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dsNhacc.DataSource, "SDT");

        }
        public void resetvalues()
        {
            txtMaNhaCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTenNCC.Focus();
            Error.Clear();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            NhaCungCap_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Error.Clear();
            update = true;
            add = false;
            hienthi(false);
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult rs;
            rs = XtraMessageBox.Show("ban có muôn xóa không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (rs == DialogResult.Yes)
            {
                if (BUS.NhaCcBUS.Instance.kiemtrangoangoaincc(txtMaNhaCC.Text))
                {
                    XtraMessageBox.Show("Không được phép xóa MaNhaC:" + txtMaNhaCC.Text);
                }
                else
                {
                    if (BUS.NhaCcBUS.Instance.xoancc(txtMaNhaCC.Text))
                    {
                        XtraMessageBox.Show("thành Công");
                        NhaCungCap_Load(sender, e);
                    }
                }
            }
            
        }

        public bool kiemtradulieuso(string x)
        {
            int a = 0;
            bool t = int.TryParse(x, out a);
            if(t)
            {
                return true;
            }
            return false;
        }
        public bool kiemtradulieu()
        {
            if (txtTenNCC.Text.Length <= 0)
            {
                XtraMessageBox.Show("Không Được Để Trống Tên Nhà Cung Cấp");
                return false;
            }
            else if (txtSDT.Text.Length <= 0)
            {
                XtraMessageBox.Show("Không Được Để Trống Số Điện Thoại");
                return false;
            }
            else if (!kiemtradulieuso(txtSDT.Text))
            {
                XtraMessageBox.Show("Số Điện Thoại Phải Nhập Số");
                return false;
            }
            else
                return true;
                    
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (add)
            {
                DialogResult rs;
                rs = XtraMessageBox.Show("Bạn Có Muốn Thêm Không", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (rs == DialogResult.Yes)
                {
                    if (kiemtradulieu())
                    {


                        if (BUS.NhaCcBUS.Instance.them1ncc(txtMaNhaCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text))
                        {
                            XtraMessageBox.Show("Thành Công ");
                            NhaCungCap_Load(sender, e);
                        }
                    }


                }
            }
            if (update)
            {
                DialogResult rs;
                rs = XtraMessageBox.Show("Bạn Có Muốn Xóa Không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (kiemtradulieu())
                {

                    if (rs == DialogResult.Yes)
                    {
                        if (BUS.NhaCcBUS.Instance.suancc(txtMaNhaCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text))
                        {
                            XtraMessageBox.Show("Thành Công ");
                            NhaCungCap_Load(sender, e);
                        }
                    }
                }
            }
        }

        private void txtSDT_EditValueChanged(object sender, EventArgs e)
        {
            if(kiemtradulieuso(txtSDT.Text))
            {
                Error.Clear();
            }
            else
            {
                Error.SetError(txtSDT, "Bạn Phải Nhập Số");
            }
           
        }

        private void txtDiaChi_EditValueChanged(object sender, EventArgs e)
        {

        }
        public void timkiemnhacungcap(string x)
        {
            BUS.NhaCcBUS.Instance.timkiemnhacuncap(x,dsNhacc);
        }
        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length > 0)
            {
                timkiemnhacungcap(txtTimKiem.Text);
            }
            else
            {
                NhaCungCap_Load(sender, e);
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            update = false;
            resetvalues();
            hienthi(false);
            if (gridView1.DataRowCount <= 0)
            {
                txtMaNhaCC.Text = "NC001";
            }
            else
            {
                txtMaNhaCC.Text = BUS.NhaCcBUS.Instance.NextID();
            }


        }
    }
}
