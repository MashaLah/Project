﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public int RoleId { get; set; }
        public ProfileEntity Profile { get; set; }
        public RoleEntity Role { get; set; }
        public bool IsBanned { get; set; }
    }
}
