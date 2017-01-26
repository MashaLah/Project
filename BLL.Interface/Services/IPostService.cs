using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IPostService
    {
        PostEntity GetPostEntity(int id);
        IEnumerable<PostEntity> GetAllPostEntities();
        IEnumerable<PostEntity> GetPostsByPredicate(Expression<Func<PostEntity, bool>> f);
        void CreatePost(PostEntity post);
        void DeletePost(PostEntity post);
        void UpdatePost(PostEntity post);
        IEnumerable<PostEntity> GetApprovedPostEntities();
    }
}
