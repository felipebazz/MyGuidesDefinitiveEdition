using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using MyGuides.Notifications.Context;
using MyGuides.Notifications.Result;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace MyGuides.Notifications.Filters
{
    [ExcludeFromCodeCoverage]
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotificationContext _notificationContext;

        public NotificationFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (await CheckForNotificationsAsync(context)) return;
            await next();
        }

        private async Task<bool> CheckForNotificationsAsync(ResultExecutingContext context)
        {
            if (!_notificationContext.HasNotifications) return false;

            SetErrorCode(context);
            var requestResult = new RequestResult
            {
                Success = false,
                Messages = _notificationContext.Notifications.ToList()
            };

            await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(requestResult));
            return true;
        }

        private void SetErrorCode(ResultExecutingContext context)
        {
            if (_notificationContext.Notifications.Any(x => x.Type == NotificationType.Validation))
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (_notificationContext.Notifications.Any(x => x.Type == NotificationType.InternalError))
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (_notificationContext.Notifications.Any(x => x.Type == NotificationType.NoContent))
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;

            if (_notificationContext.Notifications.Any(x => x.Type == NotificationType.Unauthorized))
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            if (_notificationContext.Notifications.Any(x => x.Type == NotificationType.NotFound))
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

            if (_notificationContext.Notifications.Any(x => x.Type == NotificationType.Conflict))
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;

            context.HttpContext.Response.ContentType = "application/json";
        }
    }
}
