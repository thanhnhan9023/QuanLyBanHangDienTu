using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DT0;
using DevExpress.XtraGrid;

namespace BUS
{
    public class ChucVuBus
    {


        private static ChucVuBus instance;
        public static ChucVuBus Instance
        {
            get
            {
                if (instance == null) instance = new ChucVuBus();
                return instance;
            }
            private set { instance = value; }
        }

        public bool them1chucvu(ChucVucc cv)
        {
            return ChucvuDao.Instance.them1machucvu(cv);
        }
        public bool sua1chucvu(ChucVucc cv)
        {
            return ChucvuDao.Instance.sua1chucvu(cv);
        }
        public void laydulieuchucvu(GridControl data)
        {
            data.DataSource = ChucvuDao.Instance.laydulieuchucvu();
        }

        public bool xoa1chucvu(ChucVucc cv)
        {
            return ChucvuDao.Instance.xoa1chucvu(cv);
        }
        public bool kiemtradulieucnhanvien(ChucVucc cv)
        {
            return ChucvuDao.Instance.kiemtradulieucnhanvien(cv);
        }
        public bool kiemtradulieunguoidung(ChucVucc cv)
        {
            return ChucvuDao.Instance.kiemtradulieuquantringuoidug(cv);
        }
        public string NextID()
        {
            return Utilities.Instance.NextID(Dataprovider.Instance.GetLastID("ChucVu", "MaCv"), "LC");

        }
    }
}
