using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Notifications.Result
{
    [ExcludeFromCodeCoverage]
    public class RequestResult
    {
        public bool Success { get; set; }
        public ICollection<Notification> Messages { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RequestResult<TData> : RequestResult
    {
        public TData Data { get; set; }
    }
}
