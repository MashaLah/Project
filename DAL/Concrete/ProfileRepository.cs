using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class ProfileRepository : IProfileRepository 
    {
        private readonly DbContext context;

        public ProfileRepository(DbContext uow)
        {
            context = uow;
        }

        public DALProfile GetByUserId(int key)
        {
            var ormProfile = context.Set<Profile>().FirstOrDefault(p => p.Id == key);
            return new DALProfile()
            {
                Id = ormProfile.Id,
                Name = ormProfile.Login,
                UserId = ormProfile.UserId,
                LastUpdateDate = ormProfile.LastUpdateDate
            };
        }

        public void CreateProfile(DALProfile profile)
        {
            var profileNew = new Profile()
            {
                Id = profile.Id,
                Login = profile.Name,
                UserId = profile.UserId,
                LastUpdateDate = profile.LastUpdateDate
            };
            context.Set<Profile>().Add(profileNew);
        }
    }
}
