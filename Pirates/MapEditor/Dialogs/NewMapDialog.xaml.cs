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
    /// Interaction logic for NewMapDialog.xaml
    /// </summary>
    public partial class NewMapDialog : Window
    {

        public string mapName { set; get; }

        public int mapWidth { set; get; }

        public int mapHeight { set; get; }

        public NewMapDialog()
        {
            InitializeComponent();
        }

        private bool notCorrect() {
            bool result = true;
            result &= mapHeightValue.Text.Trim().Equals("");
            result &= mapWidthValue.Text.Trim().Equals("");
            result &= mapNameValue.Text.Trim().Equals("") || mapNameValue.Text.Equals("New Map");
            return result;
        }

        private void dialogCancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void dialogCreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (notCorrect())
            {
                //MessageBox.Show("Please, fill all the fields on dialog", "Not all fields filled up", MessageBoxButton.OK, MessageBoxImage.Error);
                AlertDialog.show("Not all fields filled up", "Please, fill all the fields on dialog");
                return;
            }
            DialogResult = true;
            mapWidth = Int32.Parse(mapWidthValue.Text);
            mapHeight = Int32.Parse(mapHeightValue.Text);
            mapName = mapNameValue.Text;
        }
    }
}
