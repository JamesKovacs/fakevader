using System.Transactions;
using Castle.Core.Interceptor;

namespace FakeVader.Core.Infrastructure.NHibernateSupport {
    public class TransactionalInterceptor : IInterceptor {
        public void Intercept(IInvocation invocation) {
            using(var scope = new TransactionScope()) {
                invocation.Proceed();
                scope.Complete();
            }
        }
    }
}