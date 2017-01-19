using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repository
{
    public interface IProfileRepository
    {
        DALProfile GetByUserId(int key);
        void CreateProfile(DALProfile profile);
        void Update(DALProfile profile);
        DALProfile GetByUserEmail(string email);
    }
}
