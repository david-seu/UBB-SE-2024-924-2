using System;
using System.Collections.Generic;
using System.Data;
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
            // throw new Exception();
            // var mainWindowViewModel = new MainWindowViewModel();
            // var mainWindow = new MainWindow(mainWindowViewModel);
            // mainWindow.Show();
            MainWindowGroupView parentWindow = (MainWindowGroupView)(Window.GetWindow(this));
            Guid userId = parentWindow.GetUserId();
            Guid groupId = parentWindow.GetGroupId();

            IChatFactory chatFactory = new ChatFactory();
            IMainWindowViewModel mainWindowViewModel = new MainWindowViewModel(userId, groupId, chatFactory);
            MainWindow mainWindow = new MainWindow(mainWindowViewModel);
            mainWindow.Show();

            parentWindow.Close();
        }
    }
}
