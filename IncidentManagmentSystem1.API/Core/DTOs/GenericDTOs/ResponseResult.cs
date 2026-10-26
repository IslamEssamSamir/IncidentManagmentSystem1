using System.Net;

namespace IncidentManagmentSystem1.API.Core.DTOs.GenericDTOs;

public class ResponseResult<DataType>
{
    public DataType Data { get; set; }

    public bool IsSuccess => String.IsNullOrEmpty(ErrorMessage) || Errors.Any();


    public string? ErrorMessage { get; init; } 
    public IDictionary<string, string[]> Errors { get; init; }



    public HttpStatusCode StatusCode { get; set; }
    public string StatusType => StatusCode.ToString();
    public DateTime ResponseTime { get; set; } = DateTime.Now;

    public static ResponseResult<DataType> Success(DataType data, HttpStatusCode statusCode = HttpStatusCode.OK)
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
