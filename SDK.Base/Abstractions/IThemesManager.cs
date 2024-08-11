namespace SDK.Base.Abstractions
{
    public interface IThemesManager
    {
        /// <summary>
        /// Selected topic
        /// </summary>
        public string? SelectedTheme { get; set; }

        /// <summary>
        /// Applies a theme
        /// </summary>
        /// <param name="theme"></param>
        public void SetTheme(AppTheme theme);

        /// <summary>
        /// Themes collection
        /// </summary>
        List<AppTheme> Themes { get; }
    }
}
