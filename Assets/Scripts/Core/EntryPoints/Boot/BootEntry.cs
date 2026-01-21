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
            builder.Register<ISceneSystem, SceneSystem>(Lifetime.Scoped);
            builder.Register<UISystem>(Lifetime.Singleton).As<IUISystem>().AsSelf();
            builder.RegisterEntryPoint<BootUsage>();
        }
    }
}
