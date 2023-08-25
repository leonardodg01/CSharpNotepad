using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace CSharpNotepad
{
    //Contains functions used by File menu buttons
    public static class FileFunctions
    {
        //Creates new file and saves
        public static string FileSaveAs(string text)
        {
            string fileName = "";
            
            //Write all text to created file when user clicks SAVE
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                fileName = saveFileDialog.FileName;
                File.WriteAllText(fileName, text);
                return fileName;
            }
            else
            {
                return fileName;
            }
            
        }

        //Saves current text to open file
        //Returns filename
        public static string FileSave(string filename, string text)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                FileStream fWrite = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                byte[] writeArr = Encoding.UTF8.GetBytes(text);
                fWrite.Write(writeArr, 0, text.Length);
                fWrite.Close();
            }
            //If file does not exist, save as
            else
            {
                filename = FileSaveAs(text);
            }

            return filename;
        }

        //Displays a message box if user tries to perform action without saving
        public static MessageBoxResult SaveWarning()
        {
            string boxText = "Do you want to save changes?";
            MessageBoxButton boxButtons = MessageBoxButton.YesNoCancel;
            MessageBoxResult boxResult;

            boxResult = MessageBox.Show(boxText, "Notepad", boxButtons, MessageBoxImage.None, MessageBoxResult.Cancel);
            return boxResult;
        }

        //Check if user has saved file before performing an action
        public static bool CheckIfSaved(string savedText, string currentText)
        {
            if (savedText == currentText)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}