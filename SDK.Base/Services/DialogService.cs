using CommunityToolkit.Maui.Core;
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
        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="popup"></param>
        public DialogService(IPopupService popup)
        {
            _popup = popup;
        }

        /// <inheritdoc/>
        public async Task<bool?> ShowPopupAsync(string text) => 
                                 (bool?)await _popup.ShowPopupAsync<UserDialogPopupViewModel>(onPresenting: viewModel => viewModel.Text = text);
    }
}
