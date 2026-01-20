using UnityEngine;
using UnityEngine.SceneManagement;

namespace RGD.Core.Scenes
{
    public class SceneIds
    {
        public static readonly int BootSceneId = SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/Boot.unity");
        public static readonly int SplashSceneId = SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/Splash.unity");
        public static readonly int LoadingSceneId = SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/Loading.unity");
        public static readonly int MenuSceneId = SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/Menu.unity");
        public static readonly int GameSceneId = SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/Game.unity");
        public static readonly int EmptySceneId = SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/Empty.unity");
    }
}
