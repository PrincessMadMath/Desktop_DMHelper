using Microsoft.Win32;

namespace Helper
{
    public static class FileDialogHelper
    {
        public static string GetFileFromDialog(string title)
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
    }
}