using RGD.Core.ObjectsLoading;

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
            builder.Register<SceneSystem>(Lifetime.Singleton)
                .As<ISceneSystem>()
                .As<IInitializable>()
                .As<IDisposable>();
            
            builder.Register<TickSystem>(Lifetime.Singleton)
                .As<ITickSystem>()
                .As<IInitializable>()
                .As<IDisposable>()
                .As<ITickable>()
                .As<IFixedTickable>()
                .As<ILateTickable>();
            
            builder.Register<UISystem>(Lifetime.Singleton)
                .As<IUISystem>()
                .As<IInitializable>()
                .As<IDisposable>().AsSelf();
            
            builder.Register<ObjectsLoadingSystem>(Lifetime.Singleton)
                .As<IObjectsLoadingSystem>()
                .As<IDisposable>();
            
            builder.RegisterEntryPoint<BootUsage>();
        }
    }
}
