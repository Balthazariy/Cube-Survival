namespace RGD.Gameplay.UI.Pages.MainMenuPage
{
    public class MainMenuPageView : BaseUIView<MainMenuPageViewModel>
    {
        private Button _startButton;
        private Button _settingsButton;
        private Button _quitButton;
        
        public MainMenuPageView(string elementName, MainMenuPageViewModel viewModel) : base(elementName, viewModel)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            
            Transform containerButtons = SelfObject.transform.Find("Panel_Controls/Container_Buttons");
            
            RegisterButtons(containerButtons);
        }

        public override void Dispose()
        {
            base.Dispose();
            UnregisterButtons();
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }

        private void RegisterButtons(Transform containerButtons)
        {
            _startButton = containerButtons.Find("Button_StartGame").GetComponent<Button>();
            _settingsButton = containerButtons.Find("Button_Settings").GetComponent<Button>();
            _quitButton = containerButtons.Find("Button_Quit").GetComponent<Button>();
            
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            _quitButton.onClick.AddListener(OnQuitButtonClicked);
        }
        
        private void UnregisterButtons()
        {
            _startButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _quitButton.onClick.RemoveAllListeners();
        }

        public void OnStartButtonClicked()
        {
            ViewModel.OnStartButtonClicked();
        }
        
        public void OnSettingsButtonClicked()
        {
            ViewModel.OnSettingsButtonClicked();
        }
        
        public void OnQuitButtonClicked()
        {
            ViewModel.OnQuitButtonClicked();
        }
    }
}