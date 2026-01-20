namespace RGD.Core.Entries
{
    public class SplashEntry : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<SplashUsage>();
        }
    }
}
