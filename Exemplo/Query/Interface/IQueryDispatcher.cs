namespace Exemplo.Query.Interface
{
    public interface IQueryDispatcher
    {
        TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}