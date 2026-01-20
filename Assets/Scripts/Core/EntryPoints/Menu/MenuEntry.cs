namespace RGD.Core.Entries
{
    public class MenuEntry : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MenuUsage>();
        }
    }
}
