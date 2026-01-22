using RGD.Gameplay.Actors._Core;
using RGD.Gameplay.Actors.Core;

namespace RGD.Core.Entries
{
    public class GameEntry : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ActorsFactory>(Lifetime.Singleton)
                .As<IActorsFactory>()
                .As<IInitializable>()
                .As<IDisposable>();
            
            builder.RegisterEntryPoint<GameUsage>();
        }
    }
}
