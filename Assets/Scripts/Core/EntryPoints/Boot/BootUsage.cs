using System;
using RGD.Core.Scenes;
using VContainer.Unity;

namespace RGD.Core.Entries
{
    [UnityEngine.Scripting.Preserve]
    public class BootUsage :  IStartable, IDisposable
    {
        private readonly ISceneSystem _sceneSystem;
        
        [UnityEngine.Scripting.Preserve]
        public BootUsage(ISceneSystem sceneSystem)
        {
            _sceneSystem = sceneSystem;
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
