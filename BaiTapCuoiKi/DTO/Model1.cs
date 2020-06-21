namespace BaiTapCuoiKi.DTO
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            Database.SetInitializer<Model1>(new CreateDB());
        }

        public virtual DbSet<DTO.Xe> Xes { get; set; }
        public virtual DbSet<DTO.LoaiXe> LoaiXes { get; set; }        
    }
}