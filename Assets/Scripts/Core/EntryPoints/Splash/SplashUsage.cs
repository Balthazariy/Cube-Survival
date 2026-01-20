namespace RGD.Core.Entries
{
    [UnityEngine.Scripting.Preserve]
    public class SplashUsage:    IStartable, IDisposable
    {
        private readonly ISceneSystem _sceneSystem;
        
        [UnityEngine.Scripting.Preserve]
        public SplashUsage(ISceneSystem sceneSystem)
        {
            _sceneSystem = sceneSystem;
        }

        public void Start()
        {
            _sceneSystem.LoadScene(SceneIds.LoadingSceneId);
        }

        public void Dispose()
        {
        }
    }
}
