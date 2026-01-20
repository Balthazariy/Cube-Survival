namespace RGD.Core.Entries
{
    public class LoadingEntry : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LoadingUsage>();
        }
    }
}
