using System;

namespace Aplicacao.Infraestrutura.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {

            if (query == null)
                throw new ArgumentNullException("query");
            try
            {
                var handler = (IQueryHandler<TQuery, TResult>)_serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>));

                return handler.Execute(query);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can not resolve handler for IQueryHandler<{0}>", typeof(TQuery).Name), ex);
            }
        }
    }
}