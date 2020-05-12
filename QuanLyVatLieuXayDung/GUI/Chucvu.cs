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
    public partial class Chucvu : DevExpress.XtraEditors.XtraForm
    {
        bool add = false, update = false;
        ChucVucc cv;
        
        public Chucvu()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
        public void laydulieuchucvu()
        {
            BUS.ChucVuBus.Instance.laydulieuchucvu(dschucvu);
        }
        private void Chucvu_Load(object sender, EventArgs e)
        {
            hienthi(true);
            laydulieuchucvu();
            if (!add && !update)
            {
                bind();
            }
           

        }
        public void khoitao()
        {
            cv = new ChucVucc();
            cv.Tenchucvu = txtTencV.Text;
            cv.Machucvu = txtMaCv.Text;
            cv.Lcb =double.Parse(txtLCB.Text);
         
        }

        public void hienthi(bool t)
        {
            if (t)
            {
                txtMaCv.Enabled = false;
                BtnLuu.Enabled = false;
                txtTencV.Enabled = false;
                txtLCB.Enabled = false;
            }
            else
            {
                txtMaCv.Enabled = true;
                BtnLuu.Enabled = true;
                txtTencV.Enabled = true;
                txtLCB.Enabled = true;
            }
        }
        public bool kiemtraso(string x)
        {
            double a = 0;

            bool t = double.TryParse(x,out a );
            if(t)
            {
                return true;
            }
            else
            return false;
        }
            public bool kiemtradulieu()
           {
                if(txtTencV.Text.Length<=0)
                {
                XtraMessageBox.Show("Chưa nhập tên chức vụ");
                return false;
                 }
             if (txtLCB.Text.Length <= 0)
             {
                XtraMessageBox.Show("Chưa nhập Lương Cơ Bản");
                return false;
             }
            if (!kiemtraso(txtLCB.Text))
            {
                XtraMessageBox.Show("Bạn Phải Nhập Số");
                return false;
            }
          
            return true;

        }

        
        private void simpleButton6_Click(object sender, EventArgs e)
        {
           
          if(add)
            {
                if (kiemtradulieu())

                {
                    khoitao();

                    if (ChucVuBus.Instance.them1chucvu(cv))
                    {
                        XtraMessageBox.Show("Thành Công");
                        Chucvu_Load(sender, e);
                    }
                }


            }
            if (update)
            {

                if (kiemtradulieu())

                {
                    khoitao();
                    if (ChucVuBus.Instance.sua1chucvu(cv))
                    {
                        XtraMessageBox.Show("Thành Công");
                        Chucvu_Load(sender, e);
                    }
                }



            }
        }

        public void bind()
        {
            txtTencV.DataBindings.Clear();
            txtTencV.DataBindings.Add("Text", dschucvu.DataSource, "TenCv");
            txtMaCv.DataBindings.Clear();
            txtMaCv.DataBindings.Add("Text", dschucvu.DataSource, "MaCv");
            txtLCB.DataBindings.Clear();
            txtLCB.DataBindings.Add("Text", dschucvu.DataSource, "LCB");

        }
        public void resetvalues()
        {
            txtLCB.Text = "";
            txtMaCv.Text = "";
            txtTencV.Text = "";
        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            add = false;
            update = true;
            hienthi(false);
        }

        private void simpleButton6_Click_1(object sender, EventArgs e)
        {
            Chucvu_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            khoitao();
            if(!BUS.ChucVuBus.Instance.kiemtradulieucnhanvien(cv) && !BUS.ChucVuBus.Instance.kiemtradulieunguoidung(cv))
            {
                if (BUS.ChucVuBus.Instance.xoa1chucvu(cv))
                {

                    XtraMessageBox.Show("Xóa Thành Công");
                    Chucvu_Load(sender, e);
                }
            }
           else
            {
                XtraMessageBox.Show("Không được Xóa");
            }
        }

        private void dschucvu_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            resetvalues();
            hienthi(false);
            add = true;
            update = false;
            txtMaCv.Text = BUS.ChucVuBus.Instance.NextID();
        }
    }
}