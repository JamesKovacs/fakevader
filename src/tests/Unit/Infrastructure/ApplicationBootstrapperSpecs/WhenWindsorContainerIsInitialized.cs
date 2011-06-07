using System;
using System.Linq;
using System.Web.Mvc;
using Castle.Windsor;
using FakeVader.Core.Controllers;
using FakeVader.Core.Domain;
using FakeVader.Core.Infrastructure;
using FakeVader.Core.Repositories;
using FakeVader.Core.Services;
using NUnit.Framework;

namespace FakeVader.Tests.Infrastructure.ApplicationBootstrapperSpecs {
    public class WhenWindsorContainerIsInitialized : ConcernsFor<ApplicationBootstrapper>{
        [Test]
        public void ItShouldBeAbleToResolveAllConcreteDependencies() {
            foreach(var handler in container.Kernel.GetAssignableHandlers(typeof(object))) {
                var impl = handler.ComponentModel.Implementation;
                if(impl.IsAbstract || impl.IsGenericTypeDefinition) {
                    continue;
                }
                var dependency = container.Resolve(handler.Service);
                Assert.That(dependency, Is.Not.Null);
            }
        }


        [Test]
        public void ItShouldContainWithMvcControllers() {
            Assert.That(container.ResolveAll<Controller>().Count(), Is.GreaterThan(0));
        }

        [Test]
        public void TheControllersShouldBeTransient() {
            var homeController1 = container.Resolve<HomeController>();
            var homeController2 = container.Resolve<HomeController>();
            Assert.That(homeController1, Is.Not.SameAs(homeController2));
        }
        
        [Test]
        public void ShouldBeAbleToResolveClosedGenericFromOpenGenericRegistration() {
            var repository = container.Resolve<IRepository<Post>>();
            Assert.That(repository, Is.Not.Null);
        }

        [Test]
        public void RepositoryInstancesShouldBeSingletons() {
            var repository1 = container.Resolve<IRepository<Post>>();
            var repository2 = container.Resolve<IRepository<Post>>();
            Assert.That(repository1, Is.SameAs(repository2));
        }

        [Test]
        public void ShouldBeAbleToResolveServicesByDefaultInterface() {
            var viewModelMapper = container.Resolve<IViewModelMapper>();
            Assert.That(viewModelMapper, Is.TypeOf<ViewModelMapper>());
        }

        protected override void Context() {
        }

        protected override void Because() {
            container = Sut.Configure();
        }

        protected override ApplicationBootstrapper CreateSUT() {
            return new ApplicationBootstrapper();
        }

        private WindsorContainer container;
    }
}