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
        Task<bool> ShowLoadingAsync(string text);

        /// <summary>
        /// Show error message
        /// </summary>
        /// <param name="text"></param>
        void ShowErrorMessage(string text);

        /// <summary>
        /// Close loading indicator
        /// </summary>
        bool CloseLoadingPopup();
    }
}
