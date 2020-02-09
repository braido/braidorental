using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;


namespace BraidoRental.Core.Infrastructure.Repository.Extensions
{
    public static class QueryExtension
    {
        public static IList<T> ToNoTrackingList<T>(this IQueryable<T> query)
            where T : class
        {
            return query.AsNoTracking().ToList();
        }
    }
}
