namespace Business.Models;

public class BookingResponse
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}
public class BookingResponse<T> : BookingResponse
{
    public T? Response { get; set; }
}
