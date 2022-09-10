using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Implementations;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Interfaces;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Paginacao.Factories
{
    public static class CustomPagedListFactory<T>
    {
        public static async Task<ICustomPagedList<T>> CreateAsync(
            IQueryable<T> source,
            int pageNumber,
            int pageSize,
            Func<IQueryable<T>, Task<List<T>>> getList = null)
        {
            var totalRecords = source.Count();
            ICollection<T> source1 = await EnumerateWithPaginateAsync(source, pageNumber, pageSize, getList);
            return new CustomPagedList<T>(source1.Take(pageSize), pageNumber, pageSize, source1.Count > pageSize, totalRecords);
        }

        private static async Task<ICollection<TSource>> EnumerateWithPaginateAsync<TSource>(
            IQueryable<TSource> source,
            int pageNumber,
            int pageSize,
            Func<IQueryable<TSource>, Task<List<TSource>>> getList)
        {
            IQueryable<TSource> source1 = Queryable.Take(Queryable.Skip(source, pageSize * (pageNumber - 1)), pageSize + 1);
            return getList != null ? await getList(source1) : source1.ToList();
        }
    }
}