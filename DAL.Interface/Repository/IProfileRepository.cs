﻿using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repository
{
    public interface IProfileRepository
    {
        void CreateProfile(DALProfile profile);
        void Update(DALProfile profile);
        DALProfile GetByUserEmail(string email);
        DALProfile GetById(int key);
        DALProfile GetByUserId(int key);
    }
}
