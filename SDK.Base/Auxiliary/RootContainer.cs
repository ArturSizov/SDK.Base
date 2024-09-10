namespace SDK.Base.Auxiliary
{
    /// <summary>
    /// Root container
    /// </summary>
    public class RootContainer
    {
        private static readonly object _lock = new();
        private static RootContainer? _container = null;

        private IServiceProvider? _serviceProvider;

        public static RootContainer Container
        {
            get
            {
                if (_container == null)
                {
                    lock (_lock)
                    {
                        _container ??= new RootContainer();
                    }
                }
                return _container;
            }
        }

        public void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>() where T : notnull
            => _serviceProvider!.GetRequiredService<T>();
    }
}

