using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ISSLab;
using ISSLab.ViewModel;

namespace ISSLab.View
{
    /// <summary>
    /// Interaction logic for GroupView.xaml
    /// </summary>
        public partial class GroupView : UserControl
        {
        public GroupView()
        {
            InitializeComponent();
        }
        private void GroupSettingsButton_Click(object sender, RoutedEventArgs e)
            {
                GroupSettings.Visibility = Visibility.Visible;
                GroupFeed.Visibility = Visibility.Collapsed;
            }

            private void GroupPostsButton_Click(object sender, RoutedEventArgs e)
            {
                GroupFeed.Visibility = Visibility.Visible;
                PollsListBox.Visibility = Visibility.Collapsed;
                PostsListBox.Visibility = Visibility.Visible;
                GroupSettings.Visibility = Visibility.Collapsed;
            }

            private void CreatePollButton_Click(object sender, RoutedEventArgs e)
            {
                // TODO: Implement this
            }

            private void GroupPollsButton_Click(object sender, RoutedEventArgs e)
            {
                GroupFeed.Visibility = Visibility.Visible;
                PollsListBox.Visibility = Visibility.Visible;
                PostsListBox.Visibility = Visibility.Collapsed;
                GroupSettings.Visibility = Visibility.Collapsed;
            }

        private void MarketplaceButton_Click(object sender, RoutedEventArgs e)
        {
            // var mainWindowViewModel = new MainWindowViewModel();
            // var mainWindow = new MainWindow(mainWindowViewModel);
            // mainWindow.Show();
        }
    }
}
