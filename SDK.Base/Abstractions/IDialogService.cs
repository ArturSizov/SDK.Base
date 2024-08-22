namespace SDK.Base.Abstractions
{
    public interface IDialogService
    {
        /// <summary>
        /// Messages for the user
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Task<bool?> ShowPopupAsync(string text);

        /// <summary>
        /// Show loading indicator
        /// </summary>
        /// <param name="text"></param>
        Task ShowLoadingAsync(string text);

        /// <summary>
        /// Close loading indicator
        /// </summary>
        void CloseLoadingPopup();
    }
}
