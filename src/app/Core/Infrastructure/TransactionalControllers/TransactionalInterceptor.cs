using System.Transactions;
using Castle.DynamicProxy;

namespace FakeVader.Core.Infrastructure.TransactionalControllers {
    public class TransactionalInterceptor : IInterceptor {
        public void Intercept(IInvocation invocation) {
            using(var scope = new TransactionScope()) {
                invocation.Proceed();
                scope.Complete();
            }
        }
    }
}