namespace CLOUPARD.Api.Models;

public class ApiResponse
{
    public bool Success { get; init; }
    public string Message { get; init; }
    public object? Data { get; init; }

    public ApiResponse(bool success, string message, object? data)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}
