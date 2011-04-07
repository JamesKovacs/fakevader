using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace FakeVader.Core.Infrastructure {
    public class ApplicationBootstrapper {
        private WindsorContainer container;

        public WindsorContainer Configure() {
            container = new WindsorContainer();
//            container.Install(FromAssembly.This());
            RegisterFacilityStartupTasks();
            ExecuteFacilityStartupTasks();
            RegisterContainerStartupTasks();
            ExecuteContainerStartupTasks();
            RegisterStartupTasks();
            ExecuteStartupTasks();
            return container;
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