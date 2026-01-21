using UnityEngine;

namespace RGD.Gameplay.UI.Pages.MainMenuPage
{
    public class MainMenuPageViewModel : BaseUIViewModel
    {
        private ISceneSystem _sceneSystem;
        
        public MainMenuPageViewModel(ISceneSystem sceneSystem)
        {
            _sceneSystem = sceneSystem;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Dispose()
        {
            _sceneSystem = null;
            
            base.Dispose();
        }
        
        public void OnStartButtonClicked()
        {
            _sceneSystem.LoadScene(SceneIds.GameSceneId);
        }
        
        public void OnSettingsButtonClicked()
        {
        }
        
        public void OnQuitButtonClicked()
        {
        }
    }
}