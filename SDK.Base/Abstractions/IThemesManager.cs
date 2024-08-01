namespace SDK.Base.Abstractions
{
    public interface IThemesManager
    {
        /// <summary>
        /// Selected topic
        /// </summary>
        public string SelectedTheme { get; set; }

        /// <summary>
        /// Applies a theme
        /// </summary>
        /// <param name="themeName"></param>
        public void SetTheme(string themeName);

        /// <summary>
        /// Themes collection
        /// </summary>
        List<string> Themes { get; }
    }
}
