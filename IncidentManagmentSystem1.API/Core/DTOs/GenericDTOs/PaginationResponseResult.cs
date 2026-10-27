namespace IncidentManagmentSystem1.API.Core.DTOs.GenericDTOs;

public class PaginationResponseResult<T> : ResponseResult<T>
{

    public new IEnumerable<T> Data { get; private set; }
    public int CurrentPage { get; private set; }
    public int PagesCount { get; private set; }
    public int PagesSize { get; private set; }


    public int RecordsCount { get;  private set; }
    public bool HasNextPage => CurrentPage < PagesCount;
    public bool HasPreviousPage => CurrentPage > 1;
    public object? MetaData { get; private set; }






    public static PaginationResponseResult<T> Success(List<T> data, int recordsCount, int pageNumber, int pageCount, int PageSize, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new PaginationResponseResult<T> 
        {
            Data = data,
            StatusCode = statusCode ,
            CurrentPage = pageNumber,
            PagesSize = PageSize,
            PagesCount = pageCount,
            RecordsCount = recordsCount,  
            
        };
    }

}
