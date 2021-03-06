﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DALForum : IEntity 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int SectionId { get; set; }
        public ICollection<DALTopic> Topics { get; set; }
    }
}
