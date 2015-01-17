using System;
using Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MapEditor.Dialogs;

namespace MapEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string defaultName;

        private Map map;

        private void addNameToTitle(string name)
        {
            if (defaultName == null)
            {
                defaultName = Title;
            }
            Title = defaultName + " - " + name;
        }

        private void createMap(string name, int width, int height)
        {
            map = new Map(width, height, name);            
        }

        private void newMapButton_Click(object sender, RoutedEventArgs e)
        {
            NewMapDialog dialog = new NewMapDialog();
            if ((bool) dialog.ShowDialog())
            {
                addNameToTitle(dialog.mapName);
                createMap(dialog.mapName, dialog.mapWidth, dialog.mapHeight);
            }
        }

        private void generateMapButton_Click(object sender, RoutedEventArgs e)
        {
            MapFieldsType[,] mapFields = new MapFieldsType[160, 120];
            for (int i = 0; i < 160; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    if (i < 25 && j < 19)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Jawa");
                    }
                    else if (i < 12 && j > 50 && j < 60)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Pixel");
                    }
                    else if (i < 28 && j > 102 && j < 120)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Gigabajt");
                    }
                    else if (i > 58 && i < 58 + 18 && j > 21 && j < 35)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Ksero");
                    }
                    else if (i > 61 && i < 88 && j > 48 && j < 57)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Wafelek");
                    }
                    else if (i > 86 && i < 103 && j > 34 && j < 57)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Toffi");
                    }
                    else if (i > 62 && i < 72 && j > 83 && j < 93)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Mars");
                    }
                    else if (i > 49 && i < 58 && j > 72 && j < 79)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Snickers");
                    }
                    else if (i > 76 && i < 89 && j > 96 && j < 102)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Lewy_Twix");
                    }
                    else if (i > 79 && i < 86 && j > 73 && j < 89)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Prawy_Twix");
                    }
                    else if (i > 119 && i < 139 && j > 75 && j < 92)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Miki");
                    }
                    else if (i > 124 && i < 135 && j > 12 && j < 20)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Sylwia");
                    }
                    else if (i > 136 && i < 160 && j > 50 && j < 58)
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.LAND, "Kasia");
                    }
                    else
                    {
                        mapFields[i, j] = new MapFieldsType(FieldType.WATER, "");
                    }
                }
            }
            System.IO.StreamWriter writer = new System.IO.StreamWriter("map.pmapx");

            int landIndex = -1;
            Dictionary<string, int> names = new Dictionary<string, int>();

            for (int i = 0; i < 160; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    if (!names.ContainsKey(mapFields[i,j].name)) {
                        names.Add(mapFields[i,j].name, ++landIndex);
                    }
                    writer.Write(string.Format("{0}:{1}#", landIndex, (int) mapFields[i,j].type));                    
                }
                writer.Write("\n");
            }
            foreach (string s in names.Keys) 
            {
                int t = 0;
                names.TryGetValue(s, out t);
                writer.WriteLine(String.Format("{0}: {1}", t, s));
            }
            writer.Close();            
        }
    }
}
