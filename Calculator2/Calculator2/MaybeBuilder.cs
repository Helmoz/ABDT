using System;
using Neteril.ComputationExpression;
using Neteril.ComputationExpression.Instances;

namespace Calculator2
{
    public class MaybeBuilder : IMonadExpressionBuilder
    {
        IMonad<T> IMonadExpressionBuilder.Bind<TU, T> (IMonad<TU> m, Func<TU, IMonad<T>> f)
        {
            return (Option<TU>) m switch
            {
                Some<TU> some => f(some.Item),
                _ => None<T>.Value
            };
        }
        public IMonad<T> Return<T> (T v) => Some.Of (v);
        public IMonad<T> Zero<T> () => None<T>.Value;
        public IMonad<T> Combine<T> (IMonad<T> m, IMonad<T> n) => throw new NotSupportedException ();
    }
}