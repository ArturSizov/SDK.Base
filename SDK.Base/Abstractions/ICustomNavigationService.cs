namespace SDK.Base.Abstractions
{
    public interface ICustomNavigationService
    {
        /// <summary>
        /// Navigate page
        /// </summary>
        /// <param name="route"></param>
        /// <param name="routeParameters"></param>
        /// <returns></returns>
        Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null);

        /// <summary>
        /// Navigate pop
        /// </summary>
        /// <returns></returns>
        Task PopAsync();
    }
}
