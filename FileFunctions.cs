using System.IO;
using System.Text;
using System.Windows;

namespace CSharpNotepad
{
    //Contains functions used by File menu buttons
    public static class FileFunctions
    {
        //Saves current text to open file
        public static void FileSave(string filename, string text)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                FileStream fWrite = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                byte[] writeArr = Encoding.UTF8.GetBytes(text);
                fWrite.Write(writeArr, 0, text.Length);
                fWrite.Close();
            }
            
        }
        
        //Displays a message box if user tries to perform action without saving
        public static void SaveWarning()
        {


            string boxText = "Do you want to save changes?";
            MessageBoxButton boxButtons = MessageBoxButton.YesNoCancel;
            MessageBoxResult boxResult;

            boxResult = MessageBox.Show(boxText,  "Notepad", boxButtons, MessageBoxImage.None, MessageBoxResult.Yes);

            switch (boxResult)
            {
                case MessageBoxResult.Yes:
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }
    }
}