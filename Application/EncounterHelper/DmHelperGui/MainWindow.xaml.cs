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
using DmHelperGui.ModelView;
using EncounterHelper;
using Microsoft.Win32;
using System.IO;
using DmHelperGui.Properties;
using DmHelperGui.ViewLogic;
using Helper;
using Path = System.IO.Path;

namespace DmHelperGui
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

        private void btnGenerateEncounter_Click(object sender, RoutedEventArgs e)
        {
            var encounterInfo = EncounterManager.Instance.GetSimulation();
            txtEncounterDescription.Text = encounterInfo.EncounterDescription;
        }


    }

}
