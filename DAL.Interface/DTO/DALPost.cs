﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DALPost : IEntity 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int TopicId { get; set; }
        public DALUser User { get; set; }
        public int StateId { get; set; }
        public DALState State { get; set; }
    }
}
