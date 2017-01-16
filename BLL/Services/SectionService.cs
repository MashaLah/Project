using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork uow;
        private readonly ISectionRepository sectionRepository;

        public SectionService(IUnitOfWork uow, ISectionRepository repository)
        {
            this.uow = uow;
            sectionRepository = repository;
        }

        public SectionEntity GetSectionEntity(int id)
        {
            return sectionRepository.GetById(id).ToBllSection();
        }

        public IEnumerable<SectionEntity> GetAllSectionEntities()
        {
            return sectionRepository.GetAll().Select(section => section.ToBllSection());
        }

        public IEnumerable<SectionEntity> GetSectionsByPredicate(Expression<Func<SectionEntity, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void CreateSection(SectionEntity section)
        {
            sectionRepository.Create(section.ToDalSection());
            uow.Commit();
        }

        public void DeleteSection(SectionEntity section)
        {
            sectionRepository.Delete(section.ToDalSection());
            uow.Commit();
        }

        public void UpdateSection(SectionEntity section)
        {
            sectionRepository.Update(section.ToDalSection());
            uow.Commit();
        }
    }
}
