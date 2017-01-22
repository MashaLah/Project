using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DALSection : IEntity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DALTopic> Topics { get; set; }
    }
}
