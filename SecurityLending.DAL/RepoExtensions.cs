using SecurityLending.models;
using System.Collections.Generic;
using System.Linq;

namespace SecurityLending.DAL
{
    public static class RepoExtensions
    {
        //variable.function
        //class.funciom
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, string name, string currency) where T: Customer
            => list.Where(s =>
                (s.Name == name || string.IsNullOrWhiteSpace(name)) &&
                (s.Currency == currency || string.IsNullOrWhiteSpace(currency))
            );
    }
}
