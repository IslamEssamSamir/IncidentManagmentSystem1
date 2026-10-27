using IncidentManagmentSystem1.API.Core.DTOs.GenericDTOs;

namespace IncidentManagmentSystem1.API.ExtensionMethods;

public static class PaginationExtension
{

    public static async Task<PaginationResponseResult<T>> ToPaginatedListAsync<T> (this IQueryable<T> source, int pageNumber, int pageSize)
    {
        if (source is null) throw new ArgumentNullException("source");



        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        pageSize = pageSize <= 0 ? 50 : pageSize;

        int recordsCount = await source.CountAsync();

        if (recordsCount == 0)
            return PaginationResponseResult<T>.Success(new List<T>(), recordsCount, pageNumber, pageCount:1 , pageSize);


        int pageCount = (int)Math.Ceiling(recordsCount / (double) pageSize);

        if (pageNumber > pageCount)
            pageNumber = pageCount;




        var itemsList = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return PaginationResponseResult<T>.Success(itemsList, recordsCount, pageNumber, pageCount, pageSize);

    }





    public static PaginationResponseResult<T> ToPaginatedList<T>(this IQueryable<T> source, int pageNumber, int pageSize)
    {
        if (source is null) throw new ArgumentNullException("source");



        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        pageSize = pageSize <= 0 ? 50 : pageSize;

        int recordsCount =  source.Count();

        if (recordsCount == 0)
            return PaginationResponseResult<T>.Success(new List<T>(), recordsCount, pageNumber, pageCount: 1, pageSize);


        int pageCount = (int)Math.Ceiling(recordsCount / (double)pageSize);

        if (pageNumber > pageCount)
            pageNumber = pageCount;




        var itemsList =  source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return PaginationResponseResult<T>.Success(itemsList, recordsCount, pageNumber, pageCount, pageSize);

    }


}
