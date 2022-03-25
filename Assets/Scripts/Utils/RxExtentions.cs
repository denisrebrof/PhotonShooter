using System;
using UniRx;

namespace Utils
{
    public static class RxExtentions
    {
        public static IObservable<TResult> CombineWithPrevious<TSource,TResult>(
            this IObservable<TSource> source,
            Func<TSource, TSource, TResult> resultSelector)
        {
            return source.Scan(
                    Tuple.Create(default(TSource), default(TSource)),
                    (previous, current) => Tuple.Create(previous.Item2, current))
                .Select(t => resultSelector(t.Item1, t.Item2));
        }
    }
}