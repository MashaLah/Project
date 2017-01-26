using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class StateRepository:IStateRepository
    {
        private readonly DbContext context;

        public StateRepository(DbContext uow)
        {
            context = uow;
        }

        public IEnumerable<DALState> GetAll()
        { 
            var allStates = context.Set<State>();
            List<DALState> states = new List<DALState>();
            foreach (var state in allStates)
            {
                states.Add(state.ToDALState());
            }
            return states;
        }

        public DALState GetById(int key)
        {
            return context.Set<State>().FirstOrDefault(state => state.Id == key).ToDALState();
            //return state;
        }
    }
}
