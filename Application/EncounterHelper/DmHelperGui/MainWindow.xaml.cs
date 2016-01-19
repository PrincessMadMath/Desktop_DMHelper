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
using Path = System.IO.Path;

namespace DmHelperGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private EncounterInfoStarter _info = new EncounterInfoStarter();
        private string _folderToLoad = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenMonsterRepo_Click(object sender, RoutedEventArgs e)
        {
            var fileInFolder = GetFileFromDialog("Choose a file in the monster repository");
            if (fileInFolder != null)
            {
                _folderToLoad = Path.GetDirectoryName(fileInFolder);
                txtMonsterRepo.Text = _folderToLoad;
            }
        }

        private void btnLoadMonster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtStatus.Text = "Load starting";
                MonsterRepository.Load(_folderToLoad);
                txtStatus.Text = "Load Complete";
            }
            catch (Exception)
            {
                txtStatus.Text = "Load fail";
            }
        }

        private void btnOpenEncounterFile_Click(object sender, RoutedEventArgs e)
        {
            _info.EncounterPath = GetFileFromDialog("Choose an encounter file");
            txtEncounterName.Text = Path.GetFileName(_info.EncounterPath);
        }

        private void btnOpenPartyFile_Click(object sender, RoutedEventArgs e)
        {
            _info.PartyPath = GetFileFromDialog("Choose a party file");
            txtPartyName.Text = Path.GetFileName(_info.PartyPath);
        }

        private string GetFileFromDialog(string title)
        {
            string path = null;

            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = title;

            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
            }

            return path;
        }

        private void btnGenerateEncounter_Click(object sender, RoutedEventArgs e)
        {
            var encounterInfo = EncounterFactory.CreateEncounter(_info);
            txtEncounterDescription.Text = encounterInfo.EncounterDescription;
        }


    }

}
