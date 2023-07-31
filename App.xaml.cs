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
            MessageBoxManager.OK = "Save";
            MessageBoxManager.No = "Don't Save";
            MessageBoxManager.Register();
        }

    }
}