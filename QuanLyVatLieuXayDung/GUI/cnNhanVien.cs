using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DT0;
using BUS;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class cnNhanVien : UserControl
    {


        bool add = false, update = false, loai;
        NhanVienc nv;
   

        //Lấy Thông tin Thể loại
     

        public cnNhanVien()
        {
            InitializeComponent();
        }
        public void loaddulieunv()
        {
            NhanVienBUS.Instance.xem(dsNhanVien);
        }
        public void loadcomboxgioitinh()
        {
          
        }
        public void khoitao()
        {

            nv = new NhanVienc();
            nv.Manv = txtMaNV.Text;
            nv.Tennv = txtHoTenNV.Text;
            nv.Diachi = txtDiaChi.Text;
            nv.Ngaysinh = Convert.ToDateTime(dateNgaySinh.EditValue.ToString());
            nv.Gioitinh = cboGioiTinh.SelectedItem.ToString();
            nv.Sdt = txtSdt.Text;
            nv.Macv = cboChuVu.SelectedValue.ToString();
            nv.Ngayvaolam = DateTime.Parse(dateNgayVaoLam.EditValue.ToString());
            nv.Tinhtrang = loai;

        }
        public void hienthi(bool t)
        {
            if (t)
            {
                txtMaNV.Enabled = false;
                txtSdt.Enabled = false;
                dateNgaySinh.Enabled = false;
                txtDiaChi.Enabled = false;
                ckTrangthai.Enabled = false;
                txtHoTenNV.Enabled = false;
                dateNgayVaoLam.Enabled = false;
                btnLuu.Enabled = false;

            }
            else
            {
                

                    txtSdt.Enabled = true;
                    dateNgaySinh.Enabled = true;
                    txtDiaChi.Enabled = true;
                    ckTrangthai.Enabled = true;
                    txtHoTenNV.Enabled = true;
                    dateNgayVaoLam.Enabled = true;
                btnLuu.Enabled = true;
                
            }
        }
        public void loadcomboxchucvu()
        {
            NhanVienBUS.Instance.loadcomboxchucvu(cboChuVu);
        }

        private void ckTrangthai_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTrangthai.Checked)
            {
                loai = true;
            }
            else
                loai = false;
        }
        public void binds()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dsNhanVien.DataSource, "MANV");
            txtHoTenNV.DataBindings.Clear();
            txtHoTenNV.DataBindings.Add("Text", dsNhanVien.DataSource, "TenNV");
            cboGioiTinh.DataBindings.Clear();
            cboGioiTinh.DataBindings.Add("Text", dsNhanVien.DataSource, "GioiTinh");
            dateNgaySinh.DataBindings.Clear();
            dateNgaySinh.DataBindings.Add("Text", dsNhanVien.DataSource, "NgaySinh");
            cboChuVu.DataBindings.Clear();
            cboChuVu.DataBindings.Add("Text", dsNhanVien.DataSource, "TenCv");
            dateNgayVaoLam.DataBindings.Clear();
            dateNgayVaoLam.DataBindings.Add("Text", dsNhanVien.DataSource, "NgayVaoLam");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text",dsNhanVien.DataSource,"TenNV");
            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", dsNhanVien.DataSource, "SDT");




        }
        public void resetValues()
        {


            txtSdt.Text = "";
            cboGioiTinh.SelectedIndex = 0;
            cboChuVu.SelectedIndex = 0;
            txtHoTenNV.Text = "";
            txtMaNV.Text = "";
            txtDiaChi.Text = "";

            dateNgayVaoLam.EditValue = DateTime.Now.ToShortDateString();
            
        }
        public bool kiemtradulieuhop()
        {
            if(nv.Tennv==string.Empty)
            {
                XtraMessageBox.Show("Tên Nhân Viên Không Để Trống");
                return false;
            }
            if(nv.Diachi==string.Empty)
            {
                XtraMessageBox.Show("Địa Chỉ Không Để Trống");
                return false;
            }
            if(nv.Sdt==string.Empty)
            {

                XtraMessageBox.Show("Số Điện Thoại Không Để Trống");
                return false;
            }
            if(!kiemtrasso(nv.Sdt))
            {
                XtraMessageBox.Show("Nhập Số Cho Thông Tin Điện Thoại");
                return false;
            }
            return true;
        }
        public bool kiemtrasso(string x)
        {
            int a = 0;
            bool t = int.TryParse(x,out a);
            if (t)
            {
                return true;
            }
            else
                return false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            khoitao();
            if (add)
            {
                if (kiemtradulieuhop())
                {
                    if (BUS.NhanVienBUS.Instance.them1nhanvien(nv))
                    {
                        XtraMessageBox.Show("Thanh cong");
                        cnNhanVien_Load(sender, e);
                    }
                }

            }
            if (update)
            {
                if (kiemtradulieuhop())
                {
                    if (BUS.NhanVienBUS.Instance.sua1nhanvien(nv))
                    {
                        XtraMessageBox.Show("Thành công");
                        cnNhanVien_Load(sender, e);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
            add = false;
            hienthi(false);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            cnNhanVien_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            khoitao();
            if (!NhanVienBUS.Instance.kiemtrakhoangoaihoadonnhapnhanvien(nv) && !NhanVienBUS.Instance.kiemtrakhoangoainguoidung(nv) && !NhanVienBUS.Instance.kiemtrakhoangoaihoadonxuaatnhanvien(nv))
            {
                if (BUS.NhanVienBUS.Instance.xoa1nhanvien(nv))
                {
                    XtraMessageBox.Show("Thành công");
                    cnNhanVien_Load(sender, e);
                }
            }
            else
            {
                XtraMessageBox.Show("Không Được Phép Xóa");
            }

        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            string manv = gridView1.GetFocusedRowCellValue("MANV").ToString();
            string tennv = gridView1.GetFocusedRowCellValue("TenNV").ToString();
            string gioitinh = gridView1.GetFocusedRowCellValue("GioiTinh").ToString();
            string diachi = gridView1.GetFocusedRowCellValue("DiaChi").ToString();
            string ngayvaolam = gridView1.GetFocusedRowCellValue("NgayVaoLam").ToString();
            string chucvu = gridView1.GetFocusedRowCellValue("TenCv").ToString();
            LuongNV frm = new LuongNV(manv,tennv,gioitinh,ngayvaolam,diachi,chucvu);
            frm.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Chucvu cv = new Chucvu();
            cv.ShowDialog();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            resetValues();
            hienthi(false);
            loai = true;
            add = true;
            update = false;
            if (gridView1.DataRowCount <= 0)
            {
                txtMaNV.Text = "NV001";
            }
            else
                txtMaNV.Text = BUS.NhanVienBUS.Instance.NextID();
        }

        private void cnNhanVien_Load(object sender, EventArgs e)
        {
            //Load DataGrid
            loadcomboxgioitinh();
            loadcomboxchucvu();
            loaddulieunv();
            hienthi(true);
            dateNgaySinh.EditValue = DateTime.Now;
            binds();
        
           
        }

    

    

   

      

      

       
    }
}
