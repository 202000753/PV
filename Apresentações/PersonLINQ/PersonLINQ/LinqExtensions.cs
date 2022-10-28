using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonLINQ
{
    // Usando um delegate definido para este método
    //public delegate bool Function<T>(T value);

    //public static class LinqExtensions
    //{
    //    public static IEnumerable<T> Where<T>(this IEnumerable<T> source,
    //        Function<T> predicate)
    //    {
    //        foreach (T n in source)
    //            if (predicate(n))
    //                yield return n;
    //    }
    //}

    public static class LinqExtensions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            foreach (T n in source)
                if (predicate(n))
                    yield return n;
        }
    }
}
