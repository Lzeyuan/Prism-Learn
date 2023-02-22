using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism_Learn.Models;
using System.Collections.ObjectModel;

namespace Prism_Learn.ViewModels {
    public class MainViewModel : BindableBase {

        public MainViewModel(IRegionManager regionManager) {
            menuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);

            GoBackCommand = new DelegateCommand(() => {
                if (regionNavigationJournal != null && regionNavigationJournal.CanGoBack) {
                    regionNavigationJournal.GoBack();
                }
            });

            GoForwardCommand = new DelegateCommand(() => {
                if (regionNavigationJournal != null && regionNavigationJournal.CanGoForward) {
                    regionNavigationJournal.GoForward();
                }
            });
        }

        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal regionNavigationJournal;
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }
        private void Navigate(MenuBar menuBar) {
            if (menuBar == null || string.IsNullOrWhiteSpace(menuBar.NameSpace)) { return; }
            regionManager.Regions[Extends.PrismManager.MainViewRegionName].RequestNavigate(menuBar.NameSpace, back => {
                regionNavigationJournal = back.Context.NavigationService.Journal;
            });

        }

        private ObservableCollection<MenuBar> menuBars;

        public ObservableCollection<MenuBar> MenuBars {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }
        void CreateMenuBar() {
            menuBars.Add(new MenuBar() { Icon = "Home", Title = "首页", NameSpace = "HomeView" });
            menuBars.Add(new MenuBar() { Icon = "NotebookOutline", Title = "待办事项", NameSpace = "TodoView" });
            menuBars.Add(new MenuBar() { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemorandumView" });
            menuBars.Add(new MenuBar() { Icon = "Cog", Title = "设置", NameSpace = "SettingView" });
        }
    }
}
