namespace RGD.Core.Entries
{
    [UnityEngine.Scripting.Preserve]
    public class MenuUsage : IStartable, IDisposable
    {
        private readonly ISceneSystem _sceneSystem;
        
        [UnityEngine.Scripting.Preserve]
        public MenuUsage(ISceneSystem sceneSystem)
        {
            _sceneSystem = sceneSystem;
        }

        public void Start()
        {
        }

        public void Dispose()
        {
        }
    }
}
