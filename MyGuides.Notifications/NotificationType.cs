using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGuides.Notifications
{
    public enum NotificationType
    {
        Validation = 1,
        InternalError = 2,
        NoContent = 3,
        Unauthorized = 4,
        NotFound = 5,
        Conflict = 6
    }
}
