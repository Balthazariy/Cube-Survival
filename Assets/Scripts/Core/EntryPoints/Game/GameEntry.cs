using UnityEngine;

namespace RGD.Core.Entries
{
    public class GameEntry : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameUsage>();
        }
    }
}
