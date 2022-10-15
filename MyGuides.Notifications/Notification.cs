namespace MyGuides.Notifications
{
    public class Notification
    {
        public Notification() { }

        public Notification(string property, string message)
        {
            Message = message;
            Property = property;
            Type = NotificationType.Validation;
        }

        public Notification(string message, NotificationType type = NotificationType.InternalError)
        {
            Property = null;
            Message = message;
            Type = type;
        }

        public string Message { get; set; }
        public string Property { get; set; }
        public NotificationType Type { get; set; }
    }
}