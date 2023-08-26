using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using static CSharpNotepad.FileFunctions;

namespace CSharpNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string _currentFile; //Path to file that is currently opened
        private string _savedText; //Contains text of loaded file
        
        public MainWindow()
        {
            _savedText = ""; //This is the default value of the textbox
            InitializeComponent();
        }

        private void NewWindowButton_click(object sender, RoutedEventArgs e)
        {
            Process newWindow = new Process();
            newWindow.StartInfo.FileName = System.Reflection.Assembly.GetEntryAssembly().Location;
            newWindow.Start();
        }
        
        private void NewButton_click(object sender, RoutedEventArgs e)
        {
            //Open message box asking if user wants to save if they haven't
            if (CheckIfSaved(_savedText, TextMain.Text) == false)
            {
                switch (SaveWarning())
                {
                    case MessageBoxResult.Yes:
                        FileSave(_currentFile, TextMain.Text);
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                }
            }

            _currentFile = "";
            _savedText = "";
            TextMain.Text = "";
        }
        
        //Functionality for Open menu button
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            //Open file explorer when button is pressed
            //Set filter so user only sees txt files unless otherwise specified
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
            
            //Open message box asking if user wants to save if they haven't
            if (CheckIfSaved(_savedText, TextMain.Text) == false)
            {
                switch (SaveWarning())
                {
                    case MessageBoxResult.Yes:
                        FileSave(_currentFile, TextMain.Text);
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                }
            }
            if (openFileDialog.ShowDialog() == true)
            {
                _currentFile = openFileDialog.FileName;
                TextMain.Text = File.ReadAllText(_currentFile);
                _savedText = TextMain.Text;
            }
        }
        
        private void SaveButton_click(object sender, RoutedEventArgs e)
        {
            _currentFile = FileSave(_currentFile, TextMain.Text);
            _savedText = TextMain.Text;
        }

        //Functionality for Save As menu button
        private void SaveAsButton_click(object sender, RoutedEventArgs e)
        {
            //Run FileSaveAs and write to created file
            string outputString = FileSaveAs(TextMain.Text);
            if (outputString != "")
            {
                _currentFile = outputString;
                _savedText = TextMain.Text;
            }
            else
            {
                return;
            }
        }

        //Exits the application
        //Need to implement function that asks user to save before exiting
        private void ExitButton_click(object sender, RoutedEventArgs e) 
        {
            if (CheckIfSaved(_savedText, TextMain.Text) == false)
            {
                switch (SaveWarning())
                {
                    case MessageBoxResult.Yes:
                        FileSave(_currentFile, TextMain.Text);
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                }
            }
            this.Close();
        }
    }
}