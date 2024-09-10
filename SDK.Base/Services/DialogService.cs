using CommunityToolkit.Maui.Core;
using Controls.UserDialogs.Maui;
using SDK.Base.Abstractions;
using SDK.Base.ViewModels.Popup;

namespace SDK.Base.Services
{
    public class DialogService : IDialogService
    {

        #region Private property
        /// <summary>
        /// Popup service
        /// </summary>
        private readonly IPopupService _popup;

        /// <summary>
        /// User dialog
        /// </summary>
        private readonly IUserDialogs _userDialogs;
        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="popup"></param>
        public DialogService(IPopupService popup, IUserDialogs userDialogs)
        {
            _popup = popup;
            _userDialogs = userDialogs;
        }

        /// <inheritdoc/>
        public async Task<bool?> ShowPopupAsync(string text) => 
                                 (bool?)await _popup.ShowPopupAsync<UserDialogPopupViewModel>(onPresenting: viewModel => viewModel.Text = text);

        /// <inheritdoc/>
        public async Task<bool> ShowLoadingAsync(string text)
        {
             await Task.Delay(100);
            _userDialogs.Loading(text);

            return false;
        }

        /// <inheritdoc/>
        public void ShowErrorMessage(string text)
        {
            _userDialogs.ShowToast(new ToastConfig()
            {
                Icon = "error.png",
                Message = text,
                BackgroundColor = Colors.Red,
                Position = ToastPosition.Bottom
            });
        }

        /// <inheritdoc/>
        public bool CloseLoadingPopup()
        {
            _userDialogs.HideHud();
            return true;
        }
    }
}
