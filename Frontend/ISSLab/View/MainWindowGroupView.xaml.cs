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
using ISSLab.Model.Entities;
using ISSLab.ViewModel;

namespace ISSLab.View
{
    /// <summary>
    /// Interaction logic for GroupView.xaml
    /// </summary>
    public partial class MainWindowGroupView : Window
    {
        public MainWindowGroupView()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GroupListListBox.SelectedIndex = 0;
        }

        private void GroupListListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedGroup = listBox.SelectedItem as GroupNonMarketplace;

            if (selectedGroup != null)
            {
                // Ensure that DataContext is MainViewModel
                if (DataContext is MainWindowViewModel mainViewModel)
                {
                    mainViewModel.CurrentlySelectedGroupMarketplace = selectedGroup;
                    GroupViewModel viewModelForSelectedGroup = new GroupViewModel(selectedGroup);
                    viewModelForSelectedGroup.PropertyChanged += GroupViewModel_PropertyChanged;
                    mainViewModel.ViewModelCorrespondingToTheCurrentlySelectedGroup = viewModelForSelectedGroup;
                }
            }
        }

        private void GroupViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }

        private void CreateGroupButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement CreateGroupButton_Click
        }
    }
}
