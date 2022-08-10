using Serilog;

namespace CommunityGrouping.API.Extension.StartupExtension
{
    public static class SerilogExtension
    {
        public static void UseSerilogExtension(this IHostBuilder builder)
        {
            builder.UseSerilog((ctx, lc) => lc
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.File(@"logs\log.txt", rollingInterval: RollingInterval.Day));


        }
    }
}
