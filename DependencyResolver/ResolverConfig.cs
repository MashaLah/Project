using BLL.Interface.Services;
using BLL.Services;
using DAL;
using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Configure(kernel);
        }

        private static void Configure(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<ForumEntities6>().InRequestScope();
            kernel.Bind<ISectionService>().To<SectionService>();
            kernel.Bind<ITopicService>().To<TopicService>();
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IStateService>().To<StateService>();
            kernel.Bind<IProfileService>().To<ProfileService>();
            kernel.Bind<ISectionRepository>().To<SectionRepository>();
            kernel.Bind<ITopicRepository>().To<TopicRepository>();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IProfileRepository>().To<ProfileRepository>();
            kernel.Bind<IStateRepository>().To<StateRepository>();
        }
    }
}
