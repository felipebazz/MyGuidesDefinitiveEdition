using FluentValidation.Results;

namespace MyGuides.Notifications.Context
{
    public interface INotificationService
    {
        bool HasNotifications { get; }

        Task<bool> isEmptyAsync { get; }

        IReadOnlyCollection<Notification> Notifications { get; }

        void AddNotification(string message, NotificationType type = NotificationType.Validation);

        void AddNotification(string propertyName, string message);

        void AddNotification(Notification notification);

        void AddNotification(Exception exception);

        void AddNotification(IEnumerable<Notification> notifications);

        void AddNotification(IEnumerable<string> messages);

        void AddNotification(ValidationResult validationResult);
    }
}
