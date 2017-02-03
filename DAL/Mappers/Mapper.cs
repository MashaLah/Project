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
                Forums = new List<DALForum>()
            };

            var forums = ormSection.Forums;

            foreach (var forum in forums)
            {
                dalSection.Forums.Add(forum.ToDalForum());
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


        public static DALForum ToDalForum(this Forum ormForum)
        {
            DALForum dalForum = new DALForum()
            {
                Id = ormForum.Id,
                SectionId = ormForum.SectionId,
                Title = ormForum.Title,
                Description = ormForum.Description,
                LastUpdatedDate = ormForum.LastUpdatedDate,
                Topics = new List<DALTopic>(),
            };

            var topics = ormForum.Topics.Select(topic => topic.ToDalTopic());

            foreach (var topic in topics)
            {
                dalForum.Topics.Add(topic);
            }
            return dalForum;
        }

        public static Forum ToOrmForum(this DALForum dalForum)
        {
            Forum forum = new Forum()
            {
                Id = dalForum.Id,
                Title = dalForum.Title,
                Description=dalForum.Description,
                SectionId=dalForum.SectionId,
                LastUpdatedDate=dalForum.LastUpdatedDate
            };
            return forum;
        }

        public static DALTopic ToDalTopic(this Topic ormTopic)
        {
            DALTopic dalTopic = new DALTopic()
            {
                Id = ormTopic.Id,
                ForumId = ormTopic.ForumId,
                Title = ormTopic.Title,
                UserId = ormTopic.UserId,
                Date = ormTopic.Date,
                Description = ormTopic.Description,
                LastUpdatedDate = ormTopic.LastUpdatedDate,
                Posts = new List<DALPost>(),
                User=ormTopic.User.ToDalUser(),
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
                State =post.State.ToDALState(),
            };
            return dalPost;
        }

        public static Post ToOrmPost(this DALPost dalPost)
        {
            Post post = new Post()
            {
                Id = dalPost.Id,
                TopicId = dalPost.TopicId,
                Text = dalPost.Text,
                UserId = dalPost.UserId,
                Date = dalPost.Date,
                StateId = dalPost.StateId,
            };
            return post;
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
                ForumId = dalTopic.ForumId,
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
                IsBanned=ormUser.IsBanned
            };
            if (ormUser.Profiles != null)
                dalUser.Profile = ormUser.Profiles.FirstOrDefault().ToDalProfile();
            return dalUser;
        }

        public static User ToOrmUser(this DALUser dalUser)
        {
            User user = new User()
            {
                Id = dalUser.Id,
                Password = dalUser.Password,
                Email = dalUser.Email,
                CreationDate = dalUser.CreationDate,
                RoleId = dalUser.RoleId,
                IsBanned = dalUser.IsBanned
            };
            return user;
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

        public static Profile ToOrmProfile(this DALProfile dalProfile)
        {
            Profile profile = new Profile()
            {
                Id = dalProfile.Id,
                Login = dalProfile.Login,
                UserId = dalProfile.UserId,
                LastUpdateDate = dalProfile.LastUpdateDate,
                Image = dalProfile.Image,
                ImageMimeType = dalProfile.ImageMimeType
            };
            return profile;
        }
    }
}
