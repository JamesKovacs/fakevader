using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace FakeVader.Core.Infrastructure.Web {
    /// <summary>
    /// Controller Factory class for instantiating controllers using the Windsor IoC container.
    /// </summary>
    public class WindsorControllerFactory : DefaultControllerFactory {
        private readonly IWindsorContainer container;

        /// <summary>
        /// Creates a new instance of the <see cref="WindsorControllerFactory"/> class.
        /// </summary>
        /// <param name="container">The Windsor container instance to use when creating controllers.</param>
        public WindsorControllerFactory(IWindsorContainer container) {
            if(container == null) {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext context, Type controllerType) {
            if(controllerType == null) {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found or it does not implement IController.", context.HttpContext.Request.Path));
            }

            return (IController) container.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller) {
            var disposable = controller as IDisposable;

            if(disposable != null) {
                disposable.Dispose();
            }

            container.Release(controller);
        }
    }
}