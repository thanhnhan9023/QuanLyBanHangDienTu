using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using DAO;
using DevExpress.XtraGrid;

namespace BUS
{
  public  class NhaCcBUS
    {
        private static NhaCcBUS instance;
        public static NhaCcBUS Instance
        {
            get
            {
                if (instance == null) instance = new NhaCcBUS();
                return instance;
            }
            private set { instance = value; }
        }

        public void laydulieunhacc(GridControl data)
        {
            data.DataSource = NhaCungCapDao.Instance.laydulieunhacc();
        }
        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("NhaCungCap", "MaNC"), "NC");

        }
        public bool them1ncc(string mancc,string tenncc,string diachi,string sdt)
        {
            NhaCungCap ncc = new NhaCungCap(mancc, tenncc, diachi, sdt);
            return NhaCungCapDao.Instance.them1nhacc(ncc);
        }
        public bool xoancc(string mancc)
        {
            NhaCungCap ncc = new NhaCungCap(mancc,"","","");
            return NhaCungCapDao.Instance.xoancc(ncc);
        }
        public bool suancc(string mancc, string tenncc, string diachi, string sdt)
        {
            NhaCungCap ncc = new NhaCungCap(mancc, tenncc, diachi, sdt);
            return NhaCungCapDao.Instance.suanhacuncap(ncc);

        }
        public bool kiemtrangoangoaincc(string mancc)
        {
            NhaCungCap ncc = new NhaCungCap(mancc, "", "","");
            return NhaCungCapDao.Instance.kiemtrangoangoaincc(ncc);
        }
        public void timkiemnhacuncap(string tim,GridControl data)
        {
           data.DataSource=NhaCungCapDao.Instance.timkiemnhacungcap(tim);
        }

        
    }
}
