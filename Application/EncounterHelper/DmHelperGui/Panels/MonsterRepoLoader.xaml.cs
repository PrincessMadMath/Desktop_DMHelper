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
using EncounterHelper;
using Helper;
using Path = System.IO.Path;

namespace DmHelperGui.Panels
{
    /// <summary>
    /// Interaction logic for MonsterRepoLoader.xaml
    /// </summary>
    public partial class MonsterRepoLoader : UserControl
    {
        private string _folderToLoad = null;

        public MonsterRepoLoader()
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
                MonsterRepository.Load(_folderToLoad);
                txtStatus.Text = "Load Complete";
            }
            catch (Exception exception)
            {
                txtStatus.Text = "Load fail" + exception.Message;
            }
        }
    }
}
