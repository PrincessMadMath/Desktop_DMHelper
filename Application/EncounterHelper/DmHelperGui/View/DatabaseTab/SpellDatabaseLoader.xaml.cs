using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Controller;
using Helper;
using Path = System.IO.Path;

namespace DmHelperGui.View.DatabaseTab
{
    /// <summary>
    /// Interaction logic for MonsterRepoLoader.xaml
    /// </summary>
    public partial class SpellDatabaseLoadder : UserControl
    {
        private string _folderToLoad = null;

        public SpellDatabaseLoadder()
        {
            InitializeComponent();

            var folder = Properties.Settings.Default["SpellDatabasePath"] as string;
            SetFolderToLoad(folder);

        }

        private void btnOpenSpellDatabase_Click(object sender, RoutedEventArgs e)
        {
            var fileInFolder = FileDialogHelper.GetFileFromDialog("Choose a file in the spell repository");
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
            TxtSpellDatabase.Text = _folderToLoad.Split('\\').Last();

            Properties.Settings.Default["SpellDatabasePath"] = _folderToLoad;
            Properties.Settings.Default.Save();
        }

        private void btnLoadSpells_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TxtStatus.Text = "Load starting";
                DatabaseController.Instance.LoadSpell(_folderToLoad);
                TxtStatus.Text = "Load Complete";
            }
            catch (Exception exception)
            {
                TxtStatus.Text = "Load fail" + exception.Message;
            }
        }
    }
}
