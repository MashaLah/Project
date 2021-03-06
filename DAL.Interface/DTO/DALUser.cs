﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DALUser : IEntity 
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public DALProfile Profile { get; set; }
        public DALRole Role { get; set; }
    }
}
