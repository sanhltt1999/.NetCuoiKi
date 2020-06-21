using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapCuoiKi.DTO
{
    public class LoaiXe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_LoaiXe { get; set; }
        public String Loai { get; set; }
        public int SoGhe { get; set; }
        public virtual ICollection<Xe> Xes { get; set; }
        public LoaiXe()
        {
            this.Xes = new HashSet<Xe>();
        }
    }
}
