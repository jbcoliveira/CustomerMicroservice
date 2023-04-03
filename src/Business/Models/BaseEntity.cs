﻿using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        
    }
}
