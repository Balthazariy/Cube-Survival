using RGD.Core.Ticks;

namespace RGD.Core.Entries
{
    [UnityEngine.Scripting.Preserve]
    public class BootUsage :  IStartable, IDisposable
    {
        private readonly ISceneSystem _sceneSystem;
        private readonly TickSystem _tickSystem;
        
        [UnityEngine.Scripting.Preserve]
        public BootUsage(ISceneSystem sceneSystem, TickSystem tickSystem)
        {
            _sceneSystem = sceneSystem;
            _tickSystem = tickSystem;
        }

        public void Start()
        {
            _sceneSystem.LoadScene(SceneIds.SplashSceneId);
        }

        public void Dispose()
        {
        }
    }
}
