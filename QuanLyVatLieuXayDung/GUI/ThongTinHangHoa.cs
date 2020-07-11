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
using System.IO;


namespace QuanLyVatLieuXayDung.GUI
{
 
    public partial class ThongTinHangHoa : XtraUserControl
    {
        bool add = false, update = false;
        OpenFileDialog open;
        bool saveanh=false;
        

        HangHoa hh;
    
        public ThongTinHangHoa()
        {
            InitializeComponent();
        }
        public void ThongTinHangHoa_Load(object sender, EventArgs e)
        {
            hienthi(true);
            loadcombox();
            //pictureEdit1.Image = Image.FromFile(@"C:\Lap Trinh HUFI\Công Nghệ.Net\doan\QuanLyVatLieuXayDung\QuanLyVatLieuXayDung\Images\download.jpg");
            laydulieuhanghoa();
           databind();
            
           
            

        }
        public string catfile(string x)
        {
            string filename = "";
            string x2 = "";
            
         filename=x.Substring(x.LastIndexOf("\\"));

            x2 = filename.Substring(1, filename.Length-1);

            return x2;
        }
        public void khoitao()
        {
            hh = new HangHoa();
            hh.Mahh = txtMaHH.Text;
            hh.Tenhh = txtTenHH.Text;
            hh.Maloai = cboMaLoai.SelectedValue.ToString();
            hh.Duongdan = txtFild.Text;
            hh.Xuatxu = txtXuatXu.Text;
            hh.Dvt = txtDvt.Text;
        }
        public void laydulieuhanghoa()
        {
            BUS.HangHoaBUS.Instance.laydulieuhanghoa(dshang);

        }
        
         

        

        public void loadcombox()
        {
            BUS.HangHoaBUS.Instance.loadmaloaicombox(cboMaLoai);
        }
        public void hienthi(bool t)
        {
            if (t)
            {
                txtMaHH.Enabled = false;
                txtDvt.Enabled = false;
                txtXuatXu.Enabled = false;
                txtFild.Enabled = false;
                btnLuu.Enabled = false;
                txtTenHH.Enabled = false;
                cboMaLoai.Enabled = false;

            }
            else
            {

                txtDvt.Enabled = true;
                txtXuatXu.Enabled = true;
                txtTenHH.Enabled = true;
                cboMaLoai.Enabled = true;
                btnLuu.Enabled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                
                this.txtFild.Text = open.FileName;
            }
        }
        public bool kiemtradulieu()
        {
            if(txtTenHH.Text.Length<=0)
            {
              
                XtraMessageBox.Show("Tên Hàng Hóa Chưa Được Nhập");
                return false;
            }
            if(txtDvt.Text.Length<=0)
            {
                XtraMessageBox.Show("Đơn Vị Tính Chưa Được Nhập");
                return false;
            }
            if(txtXuatXu.Text.Length<0)
            {
                XtraMessageBox.Show("Tên Xuất Xứ Chưa Được Nhập");
                return false;
            }
            if (txtFild.Text.Length <= 0)
            {
                XtraMessageBox.Show("Hình Ảnh Hàng Hóa Chưa Được Chọn");
                return false;
            }
            else
                return true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            khoitao();
            if (add)
            {
                if (kiemtradulieu())
                {
                    if (BUS.HangHoaBUS.Instance.them1hanghoa(hh))
                    {
                        XtraMessageBox.Show("Thanh Cong");
                        ThongTinHangHoa_Load(sender, e);
                    }
                }
            }
            if(update)
            {
                if (kiemtradulieu())
                {
                    if (BUS.HangHoaBUS.Instance.sua1hanghoa(hh))
                    {
                        XtraMessageBox.Show("Thanh Cong");
                        ThongTinHangHoa_Load(sender, e);
                    }
                }
            }

        }


        public void databind()
        {

        
                txtFild.DataBindings.Clear();
                txtFild.DataBindings.Add("Text", dshang.DataSource, "Duongdan");
                txtMaHH.DataBindings.Clear();
                txtMaHH.DataBindings.Add("Text", dshang.DataSource, "MaHH");
                txtTenHH.DataBindings.Clear();
                txtTenHH.DataBindings.Add("Text", dshang.DataSource, "TenHH");
                txtXuatXu.DataBindings.Clear();
            cboMaLoai.DataBindings.Clear();
            cboMaLoai.DataBindings.Add("Text", dshang.DataSource, "TenLoai");
                txtXuatXu.DataBindings.Add("Text", dshang.DataSource, "XuatXu");
                txtDvt.DataBindings.Clear();
                txtDvt.DataBindings.Add("Text", dshang.DataSource, "DonViTinh");
            
          

        }

   

        private void txtFiled_EditValueChanged(object sender, EventArgs e)
           
        {
            string saveanhluu = "";
            if (gridView1.RowCount > 0)
            {
                 saveanhluu = Application.StartupPath + "\\Images\\" + gridView1.GetFocusedRowCellValue("Duongdan").ToString();
            }
            else
            {
                saveanhluu = Application.StartupPath + "\\Images\\" + txtFild.Text;
            }
            


            if (saveanh)
            {
                if (txtFild.Text.Length > 0 && File.Exists(saveanhluu))
                {
                    pictureEdit1.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + txtFild.Text);

                }
                else if (!File.Exists(saveanhluu))
                {
                    pictureEdit1.Image = null;
                    XtraMessageBox.Show("Ảnh này đã bị xóa");
                }
            }
            if (!saveanh)
            {
                if (txtFild.Text.Length > 0 && File.Exists(saveanhluu))                
                    {
                        pictureEdit1.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + txtFild.Text);

                    }
                else if(!File.Exists(saveanhluu))
                {
                    pictureEdit1.Image=null;
                    XtraMessageBox.Show("Ảnh này đã bị xóa");
                }
                
        
            }

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

            open = new OpenFileDialog();
            Image img;
            open.InitialDirectory = @"C:\";
            open.Title = "Select Picture";
            open.Filter = "Windows Bitmap|*.bmp|JPEG Image|*.jpg|All Files|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                
                img = Image.FromFile(open.FileName);
                pictureEdit1.Image = img;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = @""+Application.StartupPath+"\\Images\\";
            save.RestoreDirectory = true;
            save.FileName = ".jpg";
            save.Filter ="Windows Bitmap|*.bmp|JPEG Image|*.jpg|All Files|*.*";
           
            if(save.ShowDialog()==DialogResult.OK)
            {
                if (catfile(save.FileName) != catfile(open.FileName))
                {
                    pictureEdit1.Image.Save(save.FileName);
                    txtFild.Text = catfile(save.FileName);
                    XtraMessageBox.Show("Lưu Thành Công");
                    saveanh = true;
                }
               else {
                   
                    XtraMessageBox.Show("Ảnh này đã Lưu");
                    txtFild.Text = catfile(open.FileName);
                }

            }
        }

        public void resetvalues()
        {
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtXuatXu.Text = "";
            txtDvt.Text="";
            txtFild.Text = "";
           
           

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            ThongTinHangHoa_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            update = true;
            add = false;
            hienthi(false);
        }

        private void dshang_Click(object sender, EventArgs e)
        {
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            khoitao();
            if (BUS.HangHoaBUS.Instance.kiemtrakhoangoaikho(hh) || BUS.HangHoaBUS.Instance.kiemtrakhoangoaihoadonhap(hh))
            {
                XtraMessageBox.Show("Không Được Phép Xóa");
            }
            else
            {
                BUS.HangHoaBUS.Instance.xoa1hanghoa(hh);
                ThongTinHangHoa_Load(sender, e);
            }
        }

        private void cboMaLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            add = true;
            resetvalues();
            txtFild.Text = null;
            
            hienthi(false);
            if (gridView1.DataRowCount <= 0)
            {
                txtMaHH.Text = "HH001";
            }
            else
            {
                txtMaHH.Text = BUS.HangHoaBUS.Instance.NextID();
            }

        }
    }
    }
      
    
