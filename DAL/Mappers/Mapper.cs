using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class Mapper
    {
        public static DALSection ToDalSection(this Section ormSection)
        {
            DALSection dalSection = new DALSection()
            {
                Id = ormSection.Id,
                Name = ormSection.Name,
                Topics = new List<DALTopic>()
            };

            var topics = ormSection.Topics;

            foreach (var topic in topics)
            {
                dalSection.Topics.Add(topic.ToDalTopic());
            }
            return dalSection;
        }

        public static Section ToOrmSection(this DALSection dalSection)
        {
            Section section = new Section()
            {
                Id = dalSection.Id,
                Name = dalSection.Name
            };
            return section;
        }

        public static DALTopic ToDalTopic(this Topic ormTopic)
        {
            DALTopic dalTopic = new DALTopic()
            {
                Id = ormTopic.Id,
                SectionId = ormTopic.SectionId,
                Title = ormTopic.Title,
                UserId = ormTopic.UserId,
                Date = ormTopic.Date,
                Description = ormTopic.Description,
                LastUpdatedDate = ormTopic.LastUpdatedDate,
                Posts = new List<DALPost>(),
                User=ormTopic.User.ToDalUser()
            };

            var posts = ormTopic.Posts.Select(post =>post.ToDALPost());

            foreach (var post in posts)
            {
                dalTopic.Posts.Add(post);
            }
            return dalTopic;
        }

        public static DALPost ToDALPost(this Post post)
        {
            DALPost dalPost = new DALPost()
            {
                Id = post.Id,
                TopicId = post.TopicId,
                Text = post.Text,
                UserId = post.UserId,
                Date = post.Date,
                User = post.User.ToDalUser(),
                StateId = post.StateId,
                State =post.State.ToDALState()
            };
            return dalPost;
        }

        public static DALState ToDALState(this State state)
        {
            DALState dalState = new DALState()
            {
                Id = state.Id,
                State = state.State1,
            };
            return dalState;
        }

        public static Topic ToOrmTopic(this DALTopic dalTopic)
        {
            Topic topic = new Topic()
            {
                Id = dalTopic.Id,
                SectionId = dalTopic.SectionId,
                Title = dalTopic.Title,
                UserId = dalTopic.UserId,
                Date = dalTopic.Date,
                Description = dalTopic.Description,
                LastUpdatedDate = dalTopic.LastUpdatedDate,
            };
            return topic;
        }

        public static DALUser ToDalUser(this User ormUser)
        {
            DALUser dalUser = new DALUser()
            {
                Id = ormUser.Id,
                Password = ormUser.Password,
                Email = ormUser.Email,
                CreationDate = ormUser.CreationDate,
                RoleId = ormUser.RoleId,
            };
            if (ormUser.Profiles != null)
                dalUser.Profile = ormUser.Profiles.FirstOrDefault().ToDalProfile();
            return dalUser;
        }

        public static DALProfile ToDalProfile(this Profile ormProfile)
        {
            DALProfile dalProfile = new DALProfile()
            {
                Id = ormProfile.Id,
                Login = ormProfile.Login,
                UserId = ormProfile.UserId,
                LastUpdateDate = ormProfile.LastUpdateDate,
                Image = ormProfile.Image,
                ImageMimeType = ormProfile.ImageMimeType
            };
            return dalProfile;
        }
    }
}
