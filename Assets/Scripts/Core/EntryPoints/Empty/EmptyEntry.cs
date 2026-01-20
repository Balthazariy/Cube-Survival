using UnityEngine;

namespace RGD.Core.Entries
{
    public class EmptyEntry : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EmptyUsage>();
        }
    }
}
