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
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private string _currentFile; //Path to file that is currently opened

        //Functionality for Open menu button
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            //Open file explorer when button is pressed
            //Set filter so user only sees txt files unless otherwise specified
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _currentFile = openFileDialog.FileName;
                TextMain.Text = File.ReadAllText(_currentFile);
            }
        }

        //Functionality for Save As menu button
        private void SaveAsButton_click(object sender, RoutedEventArgs e)
        {
            //Write all text to created file when user clicks SAVE
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                _currentFile = saveFileDialog.FileName;
                File.WriteAllText(_currentFile, TextMain.Text);
            }
        }

        private void NewWindowButton_click(object sender, RoutedEventArgs e)
        {
            Process newWindow = new Process();
            newWindow.StartInfo.FileName = System.Reflection.Assembly.GetEntryAssembly().Location;
            newWindow.Start();
        }
        
        //Exits the application
        //Need to implement function that asks user to save before exiting
        private void ExitButton_click(object sender, RoutedEventArgs e) 
        {
            this.Close();
        }
        
        private void SaveButton_click(object sender, RoutedEventArgs e)
        {
            FileSave(_currentFile, TextMain.Text);
        }
    }
}