﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCPanel.Entities.Enums;

namespace MVCPanel.Entities.Models
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;

        }

    }

}
