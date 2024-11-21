using Wisej.Web;

namespace AddressManagerApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.MainPage = new MainForm();
        }
    }
}
