using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCPanel.Entities.Models;

namespace MVCPanel.DAL.Mapping
{
    public class UserMap : BaseMap<User>
    {

        public UserMap()
        {

            Property(x => x.FirstName).HasColumnName("Adi");
            Property(x => x.LastName).HasColumnName("Soyadi");
            Property(x => x.Email).HasColumnName("Email");
            Property(x => x.Tel).HasColumnName("Telefon");

            Property(x => x.PasswordHash).HasColumnName("Sifre");
            Property(x => x.PasswordHash).IsRequired();
            //Property(x => x.PasswordHash).HasColumnType("varbinary(500)");

            
        }
     
    }
}
