using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IProfileService
    {
        ProfileEntity GetById(int userId);
        ProfileEntity GetByUserId(int userId);
        ProfileEntity GetByUserEmail(string email);
        void CreateProfile(ProfileEntity profile);
        void UpdateProfile(ProfileEntity profile);
    }
}
