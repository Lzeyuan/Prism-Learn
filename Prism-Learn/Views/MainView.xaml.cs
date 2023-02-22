using System.Windows;
using System.Windows.Input;

namespace Prism_Learn.Views {
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window {
        public MainView() {
            InitializeComponent();
            InitUi();
        }

        private void InitUi() {
            navigationBar.MouseMove += (s, e) => {
                if (e.LeftButton == MouseButtonState.Pressed) {
                    DragMove();
                }
            };

            menuBar.SelectionChanged += (s, e) => {
                drawerHost.IsLeftDrawerOpen = false;
            };
        }

        private void minimumButton_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

        private void maximumButton_Click(object sender, RoutedEventArgs e) {
            if (WindowState == WindowState.Normal) WindowState = WindowState.Maximized;
            else WindowState = WindowState.Normal;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
