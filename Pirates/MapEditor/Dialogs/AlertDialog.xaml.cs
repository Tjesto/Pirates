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
using System.Windows.Shapes;

namespace MapEditor.Dialogs
{
    /// <summary>
    /// Interaction logic for AlertDialog.xaml
    /// </summary>
    public partial class AlertDialog : Window
    {
        public AlertDialog()
        {
            InitializeComponent();
        }

        public AlertDialog(String title, String message)
        {
            InitializeComponent();
            Title = title;
            Message.Content = message;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public static void show(String title, String message) 
        {
            new AlertDialog(title, message).ShowDialog();
        }
    }
}
