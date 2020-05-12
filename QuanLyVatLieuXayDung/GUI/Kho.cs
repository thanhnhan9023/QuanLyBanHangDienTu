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
using DT0;
using BUS;

namespace QuanLyVatLieuXayDung.GUI
{
    public partial class Kho : DevExpress.XtraEditors.XtraUserControl
    {
        public Kho()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        public void laydulieukho()
        {
            BUS.KhoBUS.Instance.laydulieukho(dskho);
        }
        public void Kho_Load(object sender,EventArgs e)
        {
            loadcomboxhh();
            laydulieukho();
        }
        public void loadcomboxhh()
        {
            BUS.KhoBUS.Instance.laydulieuhh(cboHangHoa);
        }
        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Kho_Load(sender, e);
        }

        private void cboHangHoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BUS.KhoBUS.Instance.loadulieutheocombox(dskho, cboHangHoa.SelectedValue.ToString());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(BUS.KhoBUS.Instance.xoa1kho(gridView1.GetFocusedRowCellValue("IDKho").ToString()))
                {
                XtraMessageBox.Show("Thành Công");
                Kho_Load(sender, e);

                }
        }
    }
}
