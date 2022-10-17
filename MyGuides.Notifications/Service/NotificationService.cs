using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Notifications.Context
{
    [ExcludeFromCodeCoverage]
    public class NotificationContext : INotificationService
    {
        private readonly List<Notification> _notifications;

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public bool HasNotifications => _notifications?.Any() ?? false;

        public Task<bool> isEmptyAsync => Task.FromResult(!HasNotifications);

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void AddNotification(string message, NotificationType type = NotificationType.Validation)
        {
            _notifications.Add(new Notification(message, type));
        }

        public void AddNotification(string propertyName, string message)
        {
            _notifications.Add(new Notification(propertyName, message));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotification(Exception exception)
        {
            _notifications.Add(new Notification(exception.InnerException?.Message ?? exception.Message));
        }

        public void AddNotification(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotification(IEnumerable<string> messages)
        {
            foreach (var error in messages)
            {
                AddNotification(error);
            }
        }

        public void AddNotification(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
