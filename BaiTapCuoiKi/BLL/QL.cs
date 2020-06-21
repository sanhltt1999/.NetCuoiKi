using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapCuoiKi.BLL
{
    public class QL
    {
        private static QL _Instance;

        public delegate bool typeSort(int x1, int x2);
        public static bool increase(int x1, int x2)
        {
            return x1 > x2;
        }
        public static bool decrease(int x1, int x2)
        {
            return x1 < x2;
        }
        public typeSort TypeSort { get; set; }
        private DTO.Model1 db;
        public QL()
        {
            typeSort than = new typeSort(increase);
            typeSort less = new typeSort(decrease);
            db = new DTO.Model1();
        }

        public static QL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

       
        public List<DTO.Xe> getAllXe()
        {
            var xes = db.Xes.Select(p => p);
            return xes.ToList();
        }

        public List<DTO.Xe> getAllXeList()
        {
            List<DTO.Xe> xes = (from p in db.Xes
                                 select new DTO.Xe()
                                 {
                                     Id_Xe = p.Id_Xe,
                                     BienSo = p.BienSo,
                                     GiaThue = p.GiaThue,
                                     ChuXe = p.ChuXe,
                                     SoDienThoai = p.SoDienThoai,
                                     Id_LoaiXe = p.Id_LoaiXe
                                 }).ToList();
            return xes;
        }

        public List<DTO.Xe2> sortListXe(List<DTO.Xe> data, typeSort typeSort)
        {
            int tg;
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (typeSort(data[i].GiaThue, data[j].GiaThue))
                    {
                        tg = data[i].GiaThue;
                        data[i].GiaThue = data[j].GiaThue;
                        data[j].GiaThue = tg;
                    }
                }
            }
            return convertXeToX2(data);
        }

        public List<DTO.LoaiXe> getLoaiXe()
        {
            return db.LoaiXes.ToList();
        }

        public List<DTO.Xe> searchXebyChuXe_BLL(String chuxe)
        {
            try
            {
                List<DTO.Xe> xes = db.Xes.Where(p => p.ChuXe.Contains(chuxe))
                    .Select(p => p).ToList();
                return xes;
            }
            catch
            {
                return null;
            }

        }

        public List<DTO.Xe> getXebyID_BLL(int id)
        {
            List<DTO.Xe> xes = db.Xes.Where(p => p.Id_Xe == id)
                    .Select(p => p).ToList();
            return xes;
            
        }
        public bool addXe_BLL(DTO.Xe xe)
        {
            try
            {
                db.Xes.Add(xe);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool updateXe_BLL(DTO.Xe xe)
        {
            try
            {
                DTO.Xe xe1 = db.Xes.Where(p => p.Id_Xe == xe.Id_Xe).FirstOrDefault();
                xe1.BienSo = xe.BienSo;
                xe1.ChuXe = xe.ChuXe;
                xe1.Id_LoaiXe = xe.Id_LoaiXe;
                xe1.BienSo = xe.BienSo;
                xe1.GiaThue = xe.GiaThue;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }


        public void deleteXe_BLL(DataGridViewSelectedRowCollection r)
        {
            foreach(DTO.Xe i in db.Xes.ToList())
            {
                foreach(DataGridViewRow j in r)
                {
                    if (i.Id_Xe == Convert.ToInt32(j.Cells["Id_Xe"].Value.ToString()))
                    {
                        DTO.Xe temp = i;
                        db.Xes.Remove(i);
                        db.SaveChanges();
                    }
                }
            }
        }
        public List<DTO.Xe2> convertXeToX2(List<DTO.Xe> data)
        {
            List<DTO.Xe2> xe2s = new List<DTO.Xe2>();
            foreach(DTO.Xe i in data)
            {
                xe2s.Add(new DTO.Xe2()
                {
                    Id_Xe = i.Id_Xe,
                    BienSo = i.BienSo,
                    GiaThue = i.GiaThue,
                    ChuXe = i.ChuXe,
                    SoDienThoai = i.SoDienThoai,
                    Id_LoaiXe = i.Id_LoaiXe,
                });
            }
            return xe2s;
        }
    }
}
