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
                Login = ormProfile.Login,
                UserId = ormProfile.UserId,
                LastUpdateDate = ormProfile.LastUpdateDate,
                Image = ormProfile.Image
            };
        }

        public DALProfile GetByUserEmail(string email)
        {
            int ormUserId = context.Set<User>().FirstOrDefault(u => u.Email == email).Id;
            var ormProfile = context.Set<Profile>().FirstOrDefault(p => p.UserId == ormUserId);
            return new DALProfile()
            {
                Id = ormProfile.Id,
                Login = ormProfile.Login,
                UserId = ormProfile.UserId,
                LastUpdateDate = ormProfile.LastUpdateDate,
                Image = ormProfile.Image
            };
        }

        public void CreateProfile(DALProfile profile)
        {
            var profileNew = new Profile()
            {
                Id = profile.Id,
                Login = profile.Login,
                UserId = profile.UserId,
                LastUpdateDate = profile.LastUpdateDate,
                Image = profile.Image
            };
            context.Set<Profile>().Add(profileNew);
        }

        public void Update(DALProfile profile)
        {
            var newProfile = context.Set<Profile>().Single(p => p.Id == profile.Id);
            newProfile.Login = profile.Login;
            newProfile.UserId = profile.UserId;
            newProfile.LastUpdateDate = profile.LastUpdateDate;
            newProfile.Image = profile.Image;
        }
    }
}
