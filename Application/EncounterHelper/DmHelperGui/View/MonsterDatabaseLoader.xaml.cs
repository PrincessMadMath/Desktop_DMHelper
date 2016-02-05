using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Controller;
using EncounterHelper;
using Helper;
using Path = System.IO.Path;

namespace DmHelperGui.View
{
    /// <summary>
    /// Interaction logic for MonsterRepoLoader.xaml
    /// </summary>
    public partial class MonsterDatabaseLoader : UserControl
    {
        private string _folderToLoad = null;

        public MonsterDatabaseLoader()
        {
            InitializeComponent();

            var folder = Properties.Settings.Default["MonsterRepoPath"] as string;
            SetFolderToLoad(folder);

        }

        private void btnOpenMonsterRepo_Click(object sender, RoutedEventArgs e)
        {
            var fileInFolder = FileDialogHelper.GetFileFromDialog("Choose a file in the monster repository");
            if (fileInFolder != null)
            {
                var folder = Path.GetDirectoryName(fileInFolder);
                SetFolderToLoad(folder);
            }
        }

        private void SetFolderToLoad(string path)
        {
            if (path == null)
            {
                return;
            }

            _folderToLoad = path;
            txtMonsterRepo.Text = _folderToLoad.Split('\\').Last();

            Properties.Settings.Default["MonsterRepoPath"] = _folderToLoad;
            Properties.Settings.Default.Save();
        }

        private void btnLoadMonster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtStatus.Text = "Load starting";
                DatabaseController.Instance.LoadMonster(_folderToLoad);
                txtStatus.Text = "Load Complete";
            }
            catch (Exception exception)
            {
                txtStatus.Text = "Load fail" + exception.Message;
            }
        }
    }
}
