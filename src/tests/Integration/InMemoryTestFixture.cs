using System;
using FakeVader.Core.Mapping;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace FakeVader.Tests.Integration {
    [TestFixture]
    public abstract class InMemoryDatabaseTest {
        [SetUp]
        public void SetUp() {
            NHibernateProfiler.Initialize();

            if(configuration == null) {
                configuration = new NHibernateMappingGenerator(SQLiteConfiguration.Standard.InMemory()).Generate();

                sessionFactory = configuration.BuildSessionFactory();
            }

            Session = sessionFactory.OpenSession();

            new SchemaExport(configuration).Execute(true, true, false, Session.Connection, Console.Out);
        }

        [TearDown]
        public void TearDown() {
            Session.Dispose();
        }

        private static Configuration configuration;
        private static ISessionFactory sessionFactory;
        protected ISession Session;
    }
}