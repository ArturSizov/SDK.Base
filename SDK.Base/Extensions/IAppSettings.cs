namespace SDK.Base.Extensions
{
    public interface IAppSettings
    {
        string? SelectTheme { get; set; }

        DateTime Time { get; set; }

        bool IsChecked { get; set; }
    }
}
