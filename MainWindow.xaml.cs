using System.IO;
using System.Windows;
using Microsoft.Win32;

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

        //Functionality for Open menu button
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            //Open file explorer when button is pressed
            //Set filter so user only sees txt files unless otherwise specified
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
            if(openFileDialog.ShowDialog() == true)
                TextMain.Text = File.ReadAllText(openFileDialog.FileName);
        }

        //Functionality for Save As menu button
        private void SaveAsButton_click(object sender, RoutedEventArgs e)
        {
            //Write all text to created file when user clicks SAVE
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, TextMain.Text);
        }
    }
}