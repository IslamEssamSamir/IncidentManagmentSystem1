using System.Net;

namespace IncidentManagmentSystem1.API.Core.DTOs.GenericDTOs;

public class ResponseResult<DataType>
{
    public DataType? Data { get; private set; }

    public bool IsSuccess => (int) StatusCode >= 200 && (int) StatusCode < 300;

    public string? ErrorMessage { get; private set; } = string.Empty;
    public IDictionary<string, string[]> Errors { get; private set; }


    public HttpStatusCode StatusCode { get; protected set; }
    public string StatusType => StatusCode.ToString();
    public DateTime ResponseTime { get; } = DateTime.Now;









    public static ResponseResult<DataType> Success(DataType? data , HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new ResponseResult<DataType> { Data = data , StatusCode = statusCode };
    }



    public static ResponseResult<DataType> FailureError(string errorMessage, HttpStatusCode statusCode)
    {
        return new ResponseResult<DataType> { ErrorMessage = errorMessage, StatusCode = statusCode }; 
    }

    public static ResponseResult<DataType> FailureErrors(IDictionary<string, string[]> errors, HttpStatusCode statusCode)
    {
        return new ResponseResult<DataType> { Errors = errors, StatusCode = statusCode };
    }



}
