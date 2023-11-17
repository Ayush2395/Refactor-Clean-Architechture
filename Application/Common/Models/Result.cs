namespace Application.Common.Models
{
    public class Result<T>
    {
        public bool Succeed { get; private set; }
        public string[]? Errors { get; private set; }
        public T? Data { get; private set; }
        public string? Message { get; private set; }

        internal Result(bool succeed, IEnumerable<string>? errors = default, T? data = default, string? message = default)
        {
            Succeed = succeed;
            Errors = errors?.ToArray();
            Data = data;
            Message = message;
        }

        public static Result<T> Success() => new(true);
        public static Result<T> Success(string? message = default, T? data = default) => new(true, message: message, data: data);

        public static Result<T> Failure(IEnumerable<string> errors) => new(false, errors);
        public static Result<T> Failure(string message) => new(false, message: message);
    }
}
