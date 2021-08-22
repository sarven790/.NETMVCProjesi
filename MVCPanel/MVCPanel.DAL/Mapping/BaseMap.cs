using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCPanel.Entities.Models;

namespace MVCPanel.DAL.Mapping
{

    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.CreatedDate).HasColumnName("Yaratma Tarihi");
            Property(x => x.UpdatedDate).HasColumnName("Güncelleme Tarihi");
            Property(x => x.DeletedDate).HasColumnName("Silme Tarihi");
            Property(x => x.Status).HasColumnName("Durumu");
        }
    }

}
