using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Web.Common;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Interface.IRepositories;
using DAL.Repositories;
using System.Data.Entity;
using ORM;
using BLL.Interface.Entities;

namespace DependencyResolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Configure(kernel, true);
        }
        private static void Configure(IKernel kernel, bool isWeb)
        {
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IService<PrivateMessageEntity>>().To<PrivateMessageService>();
            kernel.Bind<IMessageService>().To<MessageService>();
            kernel.Bind<ISectionService>().To<SectionService>();
            kernel.Bind<ITopicService>().To<TopicService>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IPrivateMessageRepository> ().To<PrivateMessageRepository>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<ISectionRepository>().To<SectionRepository>();
            kernel.Bind<ITopicRepository>().To<TopicRepository>();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();
        }
    }
}
