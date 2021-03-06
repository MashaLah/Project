﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DALProfile : IEntity 
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int UserId { get; set; }
        public byte[] Image { get; set; }
        public string ImageMimeType { get; set; }
    }
}
