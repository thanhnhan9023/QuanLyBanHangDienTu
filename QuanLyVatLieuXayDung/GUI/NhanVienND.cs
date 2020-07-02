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

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class NhanVienND : DevExpress.XtraEditors.XtraForm
    {
        bool add = false, update = false;
        AccoutQuanTri accountqt;
        string username="";
        public NhanVienND(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {
        }

        public void laydulieuquantri()
        {
            BUS.QuanTriBUS.Instance.laydulieuquantri(dsquantri);
        }
           
        public void loaddulieuusername()
        {
            QuanTriBUS.Instance.laydulieuusername(cboUserName);
        }
        public void loaddulieutennv()
        {
            BUS.QuanTriBUS.Instance.laydulieutennv(cboNhanVien);
        }
       
        public void khoitao()
        {
            accountqt = new AccoutQuanTri();
            accountqt.Manv = cboNhanVien.SelectedValue.ToString();
            accountqt.Macv = BUS.QuanTriBUS.Instance.laydulieumachucvu(txtChucVu.Text);
            accountqt.Username = cboUserName.SelectedValue.ToString();
            accountqt.ID_quantri1 = lblQuanTri.Text;

            
        }
        public void bind()
        {
            cboUserName.DataBindings.Clear();
            cboUserName.DataBindings.Add("Text", dsquantri.DataSource, "UserName");
            txtChucVu.DataBindings.Clear();
            txtChucVu.DataBindings.Add("Text", dsquantri.DataSource, "TenCv");
            cboNhanVien.DataBindings.Clear();
           cboNhanVien.DataBindings.Add("Text", dsquantri.DataSource, "TenNV");
            lblQuanTri.DataBindings.Clear();
            lblQuanTri.DataBindings.Add("Text", dsquantri.DataSource, "ID_I");


        }

        private void NhanVienND_Load(object sender, EventArgs e)
        {
            
            hienthi(true);
            loaddulieuusername();
            cboUserName.SelectedValue =username;
            loaddulieutennv();
            
            laydulieuquantri();
            bind();
        }
        public void hienthi(bool t)
        {
                if(t)
                {
                   btnLuu.Enabled = false;
                  
                }
                else
            {
                btnLuu.Enabled = true;
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            khoitao();
            if (add)
            {
                if (QuanTriBUS.Instance.kiemtrausernamektrung(accountqt.Username))
                {
                    XtraMessageBox.Show("Đã Kích Hoạt UserName Này");
                }
               else if(BUS.AcountcsBUS.Instance.kiemtratrungtennhanvien(accountqt.Manv))
                {
                    XtraMessageBox.Show("Đã Tồn Tại 1  tài khoản trên nhân viên này");

                }
                else
                {
                    if (QuanTriBUS.Instance.them1quantringuoidung(accountqt))
                    {
                        XtraMessageBox.Show("Thành Công");
                        NhanVienND_Load(sender, e);
                    }
                }
            }
            if(update)
            {
                if (BUS.AcountcsBUS.Instance.kiemtratrungtennhanvien( accountqt.Manv))
                {
                    XtraMessageBox.Show("Đã Tồn Tại 1  tài khoản trên nhân viên này");

                }
                else
                {

                    if (QuanTriBUS.Instance.sua1quantringuoidung(accountqt))
                    {
                        XtraMessageBox.Show("Thành Công");
                        NhanVienND_Load(sender, e);
                    }
                }

            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void cboNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtChucVu.Text = QuanTriBUS.Instance.laydulieuchucvu(cboNhanVien.SelectedValue.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            khoitao();
            if(QuanTriBUS.Instance.xoa1quantringuoidung(accountqt))
                {
                XtraMessageBox.Show("Thành Công");
                NhanVienND_Load(sender, e);
                }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            add = false;
            update = true;
            hienthi(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hienthi(false);
            add = true;
            update = false;
            if (gridView1.DataRowCount <= 0)
            {
                lblQuanTri.Text = "ID_ND001";
            }
            else
                lblQuanTri.Text = QuanTriBUS.Instance.NextID();
        }
    }
}