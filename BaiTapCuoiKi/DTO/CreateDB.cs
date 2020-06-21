using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapCuoiKi.DTO
{
    public class CreateDB
        : CreateDatabaseIfNotExists<Model1>
    {
        protected override void Seed(Model1 context)
        {
            context.Xes.Add(new DTO.Xe
            {
                BienSo = "43E1567",
                GiaThue = 100000,
                ChuXe = "Le Van Luyen",
                SoDienThoai = "0905678942",
                Id_LoaiXe = 1
            });
            context.LoaiXes.Add(new DTO.LoaiXe
            {
                Loai = "Bus",
                SoGhe = 16
            });
        }
    }
}
