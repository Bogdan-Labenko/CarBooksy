namespace CarBooksy.Domain;

public record Result<T>(T? Value, bool IsSuccess, string? Error);
public record Result(bool IsSuccess, string? Error);