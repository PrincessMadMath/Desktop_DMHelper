using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DmHelperGui.ModelView;
using DmHelperGui.ViewLogic;
using Helper;

namespace DmHelperGui.Panels
{
    /// <summary>
    /// Interaction logic for EncounterSelector.xaml
    /// </summary>
    public partial class EncounterSelector : UserControl
    {


        public EncounterSelector()
        {
            InitializeComponent();
        }

        private void btnOpenEncounterFile_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialogHelper.GetFileFromDialog("Choose an encounter file");
            EncounterManager.Instance.SetEncounterPath(path);
            txtEncounterName.Text = Path.GetFileName(path);
        }

        private void btnOpenPartyFile_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialogHelper.GetFileFromDialog("Choose a party file");
            EncounterManager.Instance.SetPartyPath(path);
            txtPartyName.Text = Path.GetFileName(path);
        }
    }
}
