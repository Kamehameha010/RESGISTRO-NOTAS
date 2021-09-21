namespace WsSchool.Core.Models
{
#nullable enable
    public class Response
    {
        public int Code { get; set; }
#pragma warning disable CS8618
        public string Message { get; set; }
#pragma warning restore CS8618
        public object? Data { get; set; }
    }
#nullable enable
}
