using RGD.Core.UI;

namespace RGD.Core.Entries
{
    public class BootEntry : LifetimeScope
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ISceneSystem, SceneSystem>(Lifetime.Scoped);
            builder.Register<IUISystem, UISystem>(Lifetime.Scoped);
            builder.RegisterEntryPoint<BootUsage>();
        }
    }
}
