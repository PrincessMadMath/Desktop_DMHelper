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

            var playerFile = Properties.Settings.Default["PlayersPath"] as string;
            SetPlayersToLoad(playerFile);
        }

        private void btnOpenPartyFile_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialogHelper.GetFileFromDialog("Choose a party file");

            if (path != null)
            {
                SetPlayersToLoad(path);
            }
        }

        private void SetPlayersToLoad(string path)
        {
            if (path == null)
            {
                return;
            }

            txtPartyName.Text = Path.GetFileName(path);

            Properties.Settings.Default["PlayersPath"] = path;
            Properties.Settings.Default.Save();

            EncounterManager.Instance.SetPartyPath(path);
        }

        private void btnOpenEncounterFile_Click(object sender, RoutedEventArgs e)
        {
            string path = FileDialogHelper.GetFileFromDialog("Choose an encounter file");

            EncounterManager.Instance.SetEncounterPath(path);
            txtEncounterName.Text = Path.GetFileName(path);
        }
    }
}
