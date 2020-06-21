using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapCuoiKi.DTO
{
    public class cbbIteam
    {
        public int id { get; set; }
        public String loai { get; set; }
        public int soGhe { get; set; }

        public override string ToString()
        {
            return loai;
        }
    }
}
