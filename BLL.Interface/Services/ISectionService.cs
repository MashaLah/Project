using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface ISectionService
    {
        SectionEntity GetSectionEntity(int id);
        IEnumerable<SectionEntity> GetAllSectionEntities();
        IEnumerable<SectionEntity> GetSectionsByPredicate(Expression<Func<SectionEntity, bool>> f);
        void CreateSection(SectionEntity section);
        void DeleteSection(SectionEntity section);
        void UpdateSection(SectionEntity section);

        /*void MakeOrder(OrderDTO orderDto);
        PhoneDTO GetPhone(int? id);
        IEnumerable<PhoneDTO> GetPhones();
        void Dispose();*/

    }
}
