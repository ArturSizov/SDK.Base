using Plugin.LocalNotification;
using SDK.Base.Abstractions;
using SDK.Base.Extensions;
using System.Runtime;

namespace SDK.Base.Services
{
    /// <summary>
    /// Notification services
    /// </summary>
    public class UserNotificationServices : IUserNotificationServices
    {
        #region Private property

        /// <summary>
        /// App settins
        /// </summary>
        private readonly IAppSettings _settings;

        /// <summary>
        /// Are alerts enabled?
        /// </summary>
        private bool _isEnabled;

        #endregion

        /// <inheritdoc/>
        public INotificationService NotificationService { get; set; }


        /// <inheritdoc/>
        public bool IsEnabled
        {
            get
            {
                _isEnabled = _settings.IsChecked;
                return _isEnabled;
            }

            set
            {
                _settings.IsChecked = value;
                _isEnabled = value;
            }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="notificationService"></param>
        public UserNotificationServices(INotificationService notificationService, IAppSettings settings)
        {
            NotificationService = notificationService;
            _settings = settings;
        }

        /// <inheritdoc/>
        public async Task AddNotificationAsync(int notificationId, string? title, string? description, DateTime date, DateTime time)
        {
            if (!IsEnabled)
                return;

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
