using RGD.Core.UI;

namespace RGD.Core.Entries
{
    [UnityEngine.Scripting.Preserve]
    public class MenuUsage : IStartable, IDisposable
    {
        private readonly ISceneSystem _sceneSystem;
        private readonly IUISystem _uiSystem;
        
        [UnityEngine.Scripting.Preserve]
        public MenuUsage(ISceneSystem sceneSystem, IUISystem uiSystem)
        {
            _sceneSystem = sceneSystem;
            _uiSystem = uiSystem;
        }

        public void Start()
        {
        }

        public void Dispose()
        {
        }
    }
}
