using SDK.Base.Abstractions;

namespace SDK.Base.Themes
{
    public class ThemesManager : IThemesManager
    {
        /// <summary>
        /// Themes dictionary
        /// </summary>
        private readonly IDictionary<string, ResourceDictionary> _themes = new Dictionary<string, ResourceDictionary>
        {
            [nameof(Light)] = new Light(),
            [nameof(Dark)] = new Dark()
        };

        /// <inheritdoc/>
        public string SelectedTheme { get; set; } = nameof(Light);

        /// <inheritdoc/>
        public List<string> Themes => _themes.Keys.ToList();

        /// <inheritdoc/>
        public void SetTheme(string themeName)
        {
            if (SelectedTheme == themeName)
                return;

            var theme = _themes[themeName];

            Application.Current?.Resources.MergedDictionaries.Clear();
            Application.Current?.Resources.MergedDictionaries.Add(theme);

            SelectedTheme = themeName;
        }
    }
}
