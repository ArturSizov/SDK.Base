using Plugin.LocalNotification;
using SDK.Base.Abstractions;

namespace SDK.Base.Services
{
    /// <summary>
    /// Notification services
    /// </summary>
    public class UserNotificationServices : IUserNotificationServices
    {
        public INotificationService NotificationService { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="notificationService"></param>
        public UserNotificationServices(INotificationService notificationService)
        {
            NotificationService = notificationService;
        }

        /// <inheritdoc/>
        public async Task AddNotificationAsync(int notificationId, string? title, string? description, DateTime date, DateTime time)
        {
            if (notificationId == 0 || title == null || description == null)
                return;

            var notification = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = title,
                Description = description,
                CategoryType = NotificationCategoryType.Reminder,

                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = new DateTime(DateTime.Now.Year, date.Month, date.Day, time.Hour, time.Minute, 0),
                    RepeatType = NotificationRepeat.TimeInterval,
                    NotifyRepeatInterval = date.AddYears(1) - date
                }
            };

           await NotificationService.Show(notification);
        }

        /// <inheritdoc/>
        public void Cancel(int notificationId) => NotificationService.Cancel(notificationId);

        /// <inheritdoc/>
        public void CancelAll() => NotificationService.CancelAll();
    }
}
