using System.Windows.Forms;

namespace CSharpNotepad
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            //Change button text for Message Box that asks if user wants to save
            MessageBoxManager.OK = "Save";
            MessageBoxManager.No = "Don't Save";
            MessageBoxManager.Register();
        }

    }
}