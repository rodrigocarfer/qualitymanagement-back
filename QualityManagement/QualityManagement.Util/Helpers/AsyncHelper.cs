using System.Threading.Tasks;
using AutoMapper;

namespace QualityManagement.Util.Helpers
{
    public static class AsyncHelper
    {
        public static Task<TResult> ResultadoAsync<TResult>(object retorno, params Task[] tasks)
        {
            return Task.WhenAll(tasks).ContinueWith(t => (TResult)retorno);
        }
    }

    public static class AsyncExtensions
    {
        public static Task<TTo> AsyncMap<TFrom, TTo>(this Task<TFrom> task, IMapper mapper)
        {
            return task.ContinueWith(t => mapper.Map<TTo>(t.Result));
        }
    }
}
