namespace RGD.Core.Entries
{
    [UnityEngine.Scripting.Preserve]
    public class GameUsage :  IStartable, IDisposable
    {
        private readonly ISceneSystem _sceneSystem;
        
        [UnityEngine.Scripting.Preserve]
        public GameUsage(ISceneSystem sceneSystem)
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
