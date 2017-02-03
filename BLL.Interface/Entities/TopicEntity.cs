using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class TopicEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int ForumId { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public ICollection<PostEntity> Posts { get; set; }
        public UserEntity User { get; set; }
        public int StateId { get; set; }
    }
}
