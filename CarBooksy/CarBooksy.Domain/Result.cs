namespace CarBooksy.Domain;

public record Result<T>(T? Value, bool IsSuccess, string? Error);