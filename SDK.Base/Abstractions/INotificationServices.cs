namespace SDK.Base.Abstractions
{
    /// <summary>
    /// Notification service
    /// </summary>
    public interface INotificationServices
    {
       /// <summary>
       /// Adds a reminder
       /// </summary>
       /// <param name="notificationId">ID is needed to track reminders</param>
       /// <param name="title">Reminder title</param>
       /// <param name="description">Reminder body/description</param>
       /// <param name="date">Will fire on this date annually</param>
       /// <param name="time">Reminder trigger time</param>
       /// <returns></returns>
       Task AddNotificationAsync(int notificationId, string? title, string? description, DateTime date, DateTime time);

        /// <summary>
        /// Closes reminders by id
        /// </summary>
        /// <param name="notificationId"></param>
        void Cancel(int notificationId);

        /// <summary>
        /// Closes all reminders
        /// </summary>
        void CancelAll();
    }
}


