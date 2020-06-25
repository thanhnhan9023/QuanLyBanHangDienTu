using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT0;
using System.Drawing;

namespace DAO
{
 public   class HangHoaDao
    {

        private static HangHoaDao instance;

        public static HangHoaDao Instance
        {
            get
            {
                if (instance == null) instance = new HangHoaDao();
                return instance;
            }
            private set { instance = value; }
        }
        private HangHoaDao() { }
        public DataTable laydulieuhanghoa()
        {
            string sql = "select TenLoai,MaHH,TenHH,DonViTinh,XuatXu,Duongdan from HangHoa,LoaiHang where HangHoa.MaLoai=LoaiHang.MaLoai";
            return Dataprovider.Instance.laydulieutubang(sql);
        }
        public DataTable loadmaloaicombox()
        {
            string sql = "select * from LoaiHang";
            return Dataprovider.Instance.laydulieutubang(sql);
        }

      
        public bool them1hanghoa(HangHoa hanghoa)
        {
            string sql = "insert into HangHoa values('"+hanghoa.Mahh+"','"+hanghoa.Maloai+"',N'"+hanghoa.Duongdan+"',N'"+hanghoa.Tenhh+"',N'"+hanghoa.Dvt+"',N'"+hanghoa.Xuatxu+"')";
            return Dataprovider.Instance.thucthicaulenhsql(sql);

        }
        public bool sua1hanghoa(HangHoa hanghoa)
        {
            string sql = "update HangHoa set MaLoai = '"+hanghoa.Maloai+"',DuongDan = N'"+hanghoa.Duongdan+"',TenHH = N'"+hanghoa.Tenhh+"',DonViTinh =N'"+hanghoa.Dvt+"',XuatXu = N'"+hanghoa.Xuatxu+"' where MaHH = '"+hanghoa.Mahh+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);

        }
      public bool xoa1hanghoa(HangHoa hanghoa)
        {
            string sql = "delete from HangHoa where MaHH='"+hanghoa.Mahh+"'";
            return Dataprovider.Instance.thucthicaulenhsql(sql);
        }
        public bool kiemtrakhoangoaikho(HangHoa hanghoa)
        {
            string sql = "select * from Kho,HangHoa where HangHoa.MaHH=Kho.MAHH and HangHoa.MAHH='"+hanghoa.Mahh+"'";
            if(Dataprovider.Instance.laydulieutubang(sql).Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool kiemtrakhoangoaihoadonhap(HangHoa hanghoa)
        {
            string sql = "select * from HangHoa,ChiTietHD_Nhap where HangHoa.MaHH=ChiTietHD_Nhap.MAHH and HangHoa.MaHH='"+hanghoa.Mahh+"'";
            if (Dataprovider.Instance.laydulieutubang(sql).Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
