[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DTS.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DTS.App_Start.NinjectWebCommon), "Stop")]

namespace DTS.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using Ninject.Modules;
    using System.Collections.Generic;
    using RepositryLayer.Interfaces;
    using RepositryLayer.Repositries;
    using ServiceLayer.Interfaces;
    using ServiceLayer.Services;
    using DATALayer.Infrastucture;
    using DATALayer.Domain;
    using System.Data.Entity;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        
        {

            kernel.Bind<DbContext>().To<EmahaSchoolEntities>().InRequestScope();
            kernel.Bind<IUserRepositry>().To<UserRepositry>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>();
        
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IDbFactory>().To<DbFactory>();

            kernel.Bind(typeof(IEntityBaseRepositry<>)).To(typeof(EntityBaseRepositry<>));

            kernel.Bind<IProjectService>().To<ProjectService>();
            kernel.Bind<IDefectService>().To<DefectService>();

            kernel.Bind<IStatusService>().To<StatusService>();

            kernel.Bind<IPriorityService>().To<PriorityService>();

            kernel.Bind<ISaleWithUsService>().To<SaleWithUsService>();

        }
    }
}
