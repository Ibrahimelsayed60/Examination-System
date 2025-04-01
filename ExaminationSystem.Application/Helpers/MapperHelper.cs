using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Helpers
{
    public static class MapperHelper
    {
        public static IMapper Mapper {  get; set; }

        public static IEnumerable<TResult> Map<TResult>(this IQueryable source)
        {
            return source.ProjectTo<TResult>(Mapper.ConfigurationProvider);
        }

        public static TResult Mapone<TResult>(this object source)
        {
            return Mapper.Map<TResult>(source);
        }

    }
}
