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
    public class StateService : IStateService 
    {
        private readonly IUnitOfWork uow;
        private readonly IStateRepository stateRepository;

        public StateService(IUnitOfWork uow, IStateRepository repository)
        {
            this.uow = uow;
            stateRepository = repository;
        }

        public StateEntity GetStateEntity(int id)
        {
            return stateRepository.GetById(id).ToBllState();
        }

        public IEnumerable<StateEntity> GetAllStateEntities()
        {
            return stateRepository.GetAll().Select(state => state.ToBllState());
        }
    }
}
