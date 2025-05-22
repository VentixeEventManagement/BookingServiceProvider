namespace Data.Models;

public class RepositoryResponse
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}

public class RepositoryResponse<T> : RepositoryResponse
{
    public T? Response { get; set; }
}
