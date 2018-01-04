namespace TeamManager.Views.Loader
{
    /// <summary>
    /// Defines the loader type to use as a selector when we call the <see cref="Loaders"/> class with the <see cref="Loaders.StartLoader"/> method.
    /// </summary>
    public enum LoaderType
    {
        /// <summary>
        /// The normal process loader.
        /// </summary>
        Loader = 0,

        /// <summary>
        /// The splash screen loader.
        /// </summary>
        SplashScreen = 1
    }
}
