using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FakeVader.Core.Mapping;
using FakeVader.Core.Repositories;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace FakeVader.Core.Infrastructure.DataLayer {
    public class RepositoryInstaller : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            var cfg = new NHibernateMappingGenerator(
                MsSqlConfiguration.MsSql2008
                    .ConnectionString(builder =>
                                      builder.FromConnectionStringWithKey("default"))).Generate();

            var sessionFactory = cfg.BuildSessionFactory();

            container.Register(Component.For<Configuration>().Instance(cfg));

            var nhSession = Component.For<ISession>()
                                     .UsingFactoryMethod(_ => sessionFactory.OpenSession());
            var repository = Component.For(typeof(IRepository<>))
                                      .ImplementedBy(typeof(Repository<>));
            if(HttpContext.Current != null) {
                container.Register(
                    nhSession.LifeStyle.PerWebRequest,
                    repository.LifeStyle.PerWebRequest
                    );
            } else {
                container.Register(
                    nhSession.LifeStyle.PerThread,
                    repository.LifeStyle.PerThread
                    );
            }
        }
    }
}