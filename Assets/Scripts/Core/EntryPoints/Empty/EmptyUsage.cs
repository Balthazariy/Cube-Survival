using UnityEngine;

namespace RGD.Core.Entries
{
    [UnityEngine.Scripting.Preserve]
    public class EmptyUsage : IStartable, IDisposable
    {
        [UnityEngine.Scripting.Preserve]
        public EmptyUsage()
        {
        }

        public void Start()
        {
        }

        public void Dispose()
        {
        }
    }
}
