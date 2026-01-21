using RGD.Core.Ticks;
using RGD.Core.UI;

namespace RGD.Core.Entries
{
    public class BootEntry : LifetimeScope
    {
        protected override void Awake()
        {
            DontDestroyOnLoad(gameObject);
            base.Awake();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneSystem>(Lifetime.Singleton).As<ISceneSystem>().AsSelf();
            builder.Register<TickSystem>(Lifetime.Singleton).As<ITickSystem>().AsSelf();
            builder.Register<UISystem>(Lifetime.Singleton).As<IUISystem>().AsSelf();
            builder.RegisterEntryPoint<BootUsage>();
        }
    }
}
