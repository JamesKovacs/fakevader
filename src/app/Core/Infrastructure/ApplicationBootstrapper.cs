using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure {
    public class ApplicationBootstrapper {
        private WindsorContainer container;

        public void Configure() {
            container = new WindsorContainer();
            RegisterFacilityStartupTasks();
            ExecuteFacilityStartupTasks();
            RegisterContainerStartupTasks();
            ExecuteContainerStartupTasks();
            RegisterStartupTasks();
            ExecuteStartupTasks();
        }

        private void RegisterFacilityStartupTasks() {
            RegisterAllTypesBasedOn<IFacilityStartupTask>();
        }

        private void ExecuteFacilityStartupTasks() {
            var tasks = container.ResolveAll<IFacilityStartupTask>();
            tasks.ForEach(task => task.Execute(container));
        }

        private void RegisterContainerStartupTasks() {
            RegisterAllTypesBasedOn<IContainerStartupTask>();
        }

        private void ExecuteContainerStartupTasks() {
            var tasks = container.ResolveAll<IContainerStartupTask>();
            tasks.ForEach(task => task.Execute(container));
        }

        private void RegisterStartupTasks() {
            RegisterAllTypesBasedOn<IStartupTask>();
        }

        private void ExecuteStartupTasks() {
            var tasks = container.ResolveAll<IStartupTask>();
            tasks.ForEach(task => task.Execute());
        }

        private void RegisterAllTypesBasedOn<T>() {
            container.Register(
                AllTypes.FromAssembly(Assembly.GetExecutingAssembly())
                    .BasedOn<T>()
                    .WithService.FirstInterface()
                );
        }
    }
}