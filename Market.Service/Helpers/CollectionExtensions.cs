using Market.Domain.Configurations;

namespace Market.Service.Helpers
{
    public static class CollectionExtensions
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> sourse,PaginationParams @params)
        {
            return @params.PageIndex > 0 && @params.PageSize >= 0 
                ? sourse.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
                : sourse;
        } 
    }
}
