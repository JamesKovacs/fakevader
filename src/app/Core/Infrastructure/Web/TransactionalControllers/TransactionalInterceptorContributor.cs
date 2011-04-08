using System.Web.Mvc;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;
using FakeVader.Core.Extensions;

namespace FakeVader.Core.Infrastructure.Web.TransactionalControllers {
    public class TransactionalInterceptorContributor : IContributeComponentModelConstruction {
        public void ProcessModel(IKernel kernel, ComponentModel model) {
            if(model.Service.Implements<IController>()) {
                model.Interceptors.Add(new InterceptorReference(typeof(TransactionalInterceptor)));
            }
        }
    }
}