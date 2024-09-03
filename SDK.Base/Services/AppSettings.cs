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
            get => Preferences.Get(nameof(Time), DateTime.Now);
            set => Preferences.Set(nameof(Time), value);
        }
    }
}
