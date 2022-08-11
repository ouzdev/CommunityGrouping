using StackExchange.Redis;

namespace CommunityGrouping.WebAPI.Extension.StartupExtension
{
    public static class RedisExtension
    {
        public static void AddRedisDependecyInjection(this IServiceCollection services, IConfiguration Configuration)
        {
            var configurationOptions = new ConfigurationOptions();
            configurationOptions.EndPoints.Add(Configuration["Redis:Host"], Convert.ToInt32(Configuration["Redis:Port"]));
            int.TryParse(Configuration["Redis:DefaultDatabase"], out int defaultDatabase);
            configurationOptions.DefaultDatabase = defaultDatabase;
            services.AddStackExchangeRedisCache(options =>
            {
                options.ConfigurationOptions = configurationOptions;
                options.InstanceName = Configuration["Redis:InstanceName"];
            });
        }
    }
}
