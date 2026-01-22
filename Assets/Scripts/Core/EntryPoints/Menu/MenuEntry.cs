using RGD.Gameplay.UI.Pages.MainMenuPage;

namespace RGD.Core.Entries
{
    public class MenuEntry : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterUI(builder);
            builder.RegisterEntryPoint<MenuUsage>();
        }

        private void RegisterUI(IContainerBuilder builder)
        {
            RegisterMainMenuPage(builder);
            
            builder.RegisterBuildCallback(container =>
            {
                var uiSystem = container.Resolve<UISystem>(); 
                
                var mainMenuPage = container.Resolve<MainMenuPageView>(); // TODO: Replace
                
                uiSystem.RegisterPage(mainMenuPage);

                uiSystem.ShowPage<MainMenuPageView>(mainMenuPage);
            });
        }

        private void RegisterMainMenuPage(IContainerBuilder builder)
        {
            builder.Register<MainMenuPageViewModel>(Lifetime.Singleton);
            builder.Register<MainMenuPageView>(Lifetime.Singleton).WithParameter("MainMenuPage");
        }
    }
}
