namespace RGD.Core.Entries
{
    [UnityEngine.Scripting.Preserve]
    public class LoadingUsage : IStartable, IDisposable
    {
        private readonly ISceneSystem _sceneSystem;
        
        [UnityEngine.Scripting.Preserve]
        public LoadingUsage(ISceneSystem sceneSystem)
        {
            _sceneSystem = sceneSystem;
        }

        public void Start()
        {
            _sceneSystem.LoadScene(SceneIds.MenuSceneId);
        }

        public void Dispose()
        {
        }
    }
}
