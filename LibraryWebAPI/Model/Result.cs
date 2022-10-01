namespace LibraryWebAPI.Model
{
    public class Result<TData>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; } = 200;
        public TData? Data { get; set; } = default(TData);
    }
}
