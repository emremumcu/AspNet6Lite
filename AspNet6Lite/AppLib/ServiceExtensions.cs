namespace AspNet6Lite.AppLib
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Ex: AppDbContext context = Services.GetServiceInstance<AppDbContext>();
        /// </summary>
        public static T GetServiceInstance<T>() where T : class
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<T>();
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            T service = provider.GetRequiredService<T>();
            return service;
        }
    }
}
