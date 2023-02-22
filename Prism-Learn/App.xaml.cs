using Prism.Ioc;
using Prism.Unity;
using Prism_Learn.ViewModels;
using Prism_Learn.Views;
using System.Windows;

namespace Prism_Learn {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication {
        protected override Window CreateShell() {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
            containerRegistry.RegisterForNavigation<TodoView, TodoViewModel>();
            containerRegistry.RegisterForNavigation<MemorandumView, MemorandumViewModel>();
            containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>();
        }
    }
}
