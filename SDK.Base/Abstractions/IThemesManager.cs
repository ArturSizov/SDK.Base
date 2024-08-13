namespace SDK.Base.Abstractions
{
    public interface IThemesManager
    {
        /// <summary>
        /// Returns the selected topic
        /// </summary>
        public string GetSelectedTheme();

        /// <summary>
        /// Applies a theme
        /// </summary>
        /// <param name="theme"></param>
        public string SetTheme(AppTheme theme);

        /// <summary>
        /// Themes collection
        /// </summary>
        List<AppTheme> Themes { get; }
    }
}
