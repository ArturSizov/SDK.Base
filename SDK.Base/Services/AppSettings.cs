using SDK.Base.Extensions;

namespace SDK.Base.Services
{
    public class AppSettings : IAppSettings
    {
        public string? SelectTheme 
        {
            get => Preferences.Get(nameof(SelectTheme), "Unspecified");
            set => Preferences.Set(nameof(SelectTheme), value);
        }

        public DateTime Time
        {
            get => Preferences.Get(nameof(Time), new DateTime(1989, 7, 29, 8, 00, 00));
            set => Preferences.Set(nameof(Time), value);
        }
    }
}
