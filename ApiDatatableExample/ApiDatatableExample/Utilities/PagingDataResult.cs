
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace ApiDatatableExample.Utilities
{
    public static class PagingDataResult
    {

        public static PagingResponse<T> GetPagingResponse<T>(IEnumerable<T> data, PagingRequest paging)
        {
            var pagingResponse = new PagingResponse<T>()
            {
                Draw = paging.Draw
            };

            var recordsTotal = data.Count();
            pagingResponse.SerchData = data.Skip(paging.Start).Take(paging.Length).ToArray();
            pagingResponse.RecordsTotal = recordsTotal;
            pagingResponse.RecordsFiltered = recordsTotal;
            return pagingResponse;

        }
        public static PagingResponse<T> GetPagingResponse<T>(IEnumerable<T> data,int draw)
        {
            var pagingResponse = new PagingResponse<T>()
            {
                Draw = draw
            };
        
            var recordsTotal = data.Count();
            pagingResponse.SerchData = data.ToArray();
            pagingResponse.RecordsTotal = recordsTotal;
            pagingResponse.RecordsFiltered = recordsTotal;
            return pagingResponse;

        }

        public static TResult Get<TResult>(this object @this, string propertyName)
        {
            return (TResult)@this.GetType().GetProperty(propertyName).GetValue(@this, null);
        }
        public static PagedResult<T> GetCustomPageResult<T>(IEnumerable<T> data, PagingRequest paging)
        {
            var skip = (paging.Start == 0 ? 0 : paging.Start - 1) * paging.Length;          
            var pagingResponse = new PagedResult<T>();
            var recordsTotal = data.Count();
            pagingResponse.Data = data.Skip(skip).Take(paging.Length).ToArray();
            pagingResponse.RecordsTotal = recordsTotal;           
            return pagingResponse;

        }
        public static IQueryable<t> OrderByDynamic<t>(this IQueryable<t> query, string? sortColumn, bool descending)
        {
            // Dynamically creates a call like this: query.OrderBy(p =&gt; p.SortColumn)
            var parameter = Expression.Parameter(typeof(t), "p");

            string command = "OrderBy";

            if (descending)
            {
                command = "OrderByDescending";
            }

            Expression resultExpression = null;

            var property = typeof(t).GetProperty(sortColumn);
            // this is the part p.SortColumn
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            // this is the part p =&gt; p.SortColumn
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            // finally, call the "OrderBy" / "OrderByDescending" method with the order by lamba expression
            resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { typeof(t), property.PropertyType },
               query.Expression, Expression.Quote(orderByExpression));

            return query.Provider.CreateQuery<t>(resultExpression);
        }
    }

    
}
