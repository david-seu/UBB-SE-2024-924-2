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
using ISSLab.Model;
using ISSLab.ViewModel;

namespace ISSLab.View
{
    /// <summary>
    /// Interaction logic for GroupView.xaml
    /// </summary>
    public partial class PollCreationView : UserControl
    {
        public PollCreationView()
        {
            InitializeComponent();
        }

        private void HasEndDateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            EndDatePicker.Visibility = Visibility.Visible;
        }

        private void HasEndDateCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            EndDatePicker.Visibility = Visibility.Collapsed;
        }
    }
}
