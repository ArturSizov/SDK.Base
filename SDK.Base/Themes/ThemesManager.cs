using SDK.Base.Abstractions;
using SDK.Base.Extensions;
using SDK.Base.ViewModels;

namespace SDK.Base.Themes
{
    public class ThemesManager : ViewModelBase ,IThemesManager
    {
        /// <summary>
        /// App settings
        /// </summary>
        private readonly IAppSettings _settings;

        /// <summary>
        /// Selected theme
        /// </summary>
        private string? _selectedTheme;

        /// <inheritdoc/>
        public string? SelectedTheme { get => _selectedTheme; set => SetProperty(ref _selectedTheme, value, () => _settings.SelectTheme = value); }


        /// <inheritdoc/>
        public List<AppTheme> Themes { get; } = new() 
        {
           AppTheme.Dark, AppTheme.Light, AppTheme.Unspecified
        };

        public ThemesManager(IAppSettings settings)
        {
            _settings = settings;

            switch (_settings.SelectTheme)
            {
                case "Dark":
                    SetTheme(AppTheme.Dark);
                    break;
                case "Light":
                    SetTheme(AppTheme.Light);
                    break;
                case "Unspecified":
                    SetTheme(AppTheme.Unspecified);
                    break;
            }
        }

        /// <inheritdoc/>
        public void SetTheme(AppTheme theme)
        {
            if (Application.Current == null)
                return;

            SelectedTheme = theme.ToString();

            Application.Current.UserAppTheme = theme;
        }
    }
}
