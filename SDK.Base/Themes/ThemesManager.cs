using SDK.Base.Abstractions;
using SDK.Base.Extensions;

namespace SDK.Base.Themes
{
    public class ThemesManager : IThemesManager
    {
        #region Private property
        /// <summary>
        /// App settings
        /// </summary>
        private readonly IAppSettings _settings;

        #endregion

        #region Public property

        /// <inheritdoc/>
        public List<AppTheme> Themes { get; } = new() 
        {
           AppTheme.Dark, AppTheme.Light, AppTheme.Unspecified
        };

        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="settings"></param>
        public ThemesManager(IAppSettings settings)
        {
            _settings = settings;
        }

        #region Methods
        /// <inheritdoc/>
        public string GetSelectedTheme()
        {
            if (Application.Current == null)
                return "Unspecified";

            string selectedTheme = "Unspecified";

            switch (_settings.SelectTheme)
            {
                case "Dark":
                    Application.Current.UserAppTheme = AppTheme.Dark;
                    selectedTheme = "Dark";
                    break;
                case "Light":
                    Application.Current.UserAppTheme = AppTheme.Light;
                    selectedTheme = "Light";
                    break;
                case "Unspecified":
                    Application.Current.UserAppTheme = AppTheme.Unspecified;
                    selectedTheme = "Unspecified";
                    break;
            }

            return selectedTheme;
        }

        /// <inheritdoc/>
        public string SetTheme(AppTheme theme)
        {
            if (Application.Current == null)
                return "Unspecified";

            Application.Current.UserAppTheme = theme;

           return _settings.SelectTheme = theme.ToString();
        }

        #endregion
    }
}
