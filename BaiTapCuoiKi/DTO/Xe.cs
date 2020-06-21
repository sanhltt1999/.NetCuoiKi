using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapCuoiKi.DTO
{
    public class Xe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Xe { get; set; }
        public String BienSo { get; set; }
        public int GiaThue { get; set; }
        public String ChuXe { get; set; }
        public String SoDienThoai { get; set; }
        public int Id_LoaiXe { get; set; }
        [ForeignKey("Id_LoaiXe")]
        public virtual LoaiXe LoaiXe { get; set; }

    }
}
