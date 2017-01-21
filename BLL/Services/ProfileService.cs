using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProfileService : IProfileService 
    {
        private readonly IUnitOfWork uow;
        private readonly IProfileRepository profileRepository;

        public ProfileService(IUnitOfWork uow, IProfileRepository repository)
        {
            this.uow = uow;
            profileRepository = repository;
        }

        public ProfileEntity GetById(int id)
        {
            return profileRepository.GetById(id).ToBllProfile();
        }

        public ProfileEntity GetByUserId(int id)
        {
            return profileRepository.GetByUserId(id).ToBllProfile();
        }

        public ProfileEntity GetByUserEmail(string email)
        {
            return profileRepository.GetByUserEmail(email).ToBllProfile();
        }

        public void CreateProfile(ProfileEntity profile)
        {
            profileRepository.CreateProfile(profile.ToDalProfile());
            uow.Commit();
        }

        public void UpdateProfile(ProfileEntity profile)
        {
            profileRepository.Update(profile.ToDalProfile());
            uow.Commit();
        }
    }
}
