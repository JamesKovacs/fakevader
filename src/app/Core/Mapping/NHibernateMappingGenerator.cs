using System.Reflection;
using FakeVader.Core.Extensions;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;

namespace FakeVader.Core.Mapping {
    public class NHibernateMappingGenerator {
        private readonly IPersistenceConfigurer databaseConfig;

        public NHibernateMappingGenerator(IPersistenceConfigurer databaseConfig) {
            this.databaseConfig = databaseConfig;
        }

        public Configuration Generate() {
            var model = new AutoPersistenceModel()
                                .AddEntityAssembly(Assembly.GetExecutingAssembly())
                                .Where(x => x.Namespace.IsNotNullOrEmpty() 
                                    && x.Namespace.StartsWith("FakeVader.Core.Domain"))
                                .Conventions.AddFromAssemblyOf<HasManyConvention>();
            return Fluently.Configure()
                            .Database(databaseConfig)
                            .Mappings(
                                configuration => configuration.AutoMappings.Add(model)
                            ).BuildConfiguration();
        }
    }
}